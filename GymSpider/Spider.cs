using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using GymModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GymSpider
{
    public class Spider
    {
        public string BaseUrl = "http://www.dianping.com/search/map/ajax/json";
        public string BaseShopUrl = "http://www.dianping.com/shop/";
        public GymContext Context = new GymContext();
        public bool GetShopListFromDitu()
        {
            var areaList = Context.Areas.ToList();
            var param = new NameValueCollection
            {
                {"cityId", "3"},
                {"cityEnName", "hangzhou"},
                {"promoId", "0"},
                {"shopType", "45"},
                {"categoryId", "147"},
                {"regionId", "0"},
                {"sortMode", "2"},
                {"shopSortItem", "1"},
                {"keyword", "健身"},
                {"searchType", "2"},
                {"branchGroupId", "0"},
                {"shippingTypeFilterValue", "0"},
                {"page", "1"},
            };
            var httpRet = new HttpHelper().GetHtml(new HttpItem()
            {
                URL = BaseUrl,
                Method = "POST",
                Postdata = HttpHelper.DataToString(param),
                ContentType = "application/x-www-form-urlencoded",
            });
            if (httpRet.StatusCode.Equals(HttpStatusCode.OK))
            {
                dynamic jsonObj = JsonConvert.DeserializeObject<JObject>(httpRet.Html);
                var code = jsonObj.code.Value;
                var pageCount = jsonObj.pageCount.Value;
                if (code.Equals(200))
                {
                    for (int i = 1; i <= pageCount; i++)
                    {
                        param.Remove("page");
                        param.Add("page",i.ToString());
                        httpRet = new HttpHelper().GetHtml(new HttpItem()
                        {
                            URL = BaseUrl,
                            Method = "POST",
                            Postdata = HttpHelper.DataToString(param),
                            ContentType = "application/x-www-form-urlencoded",
                        });
                        if (httpRet.StatusCode.Equals(HttpStatusCode.OK))
                        {
                            jsonObj = JsonConvert.DeserializeObject<JObject>(httpRet.Html);
                            code = jsonObj.code.Value;
                            if (code.Equals(200))
                            {
                                foreach (dynamic shop in jsonObj.shopRecordBeanList)
                                {
                                    string shopAddress = BaseShopUrl +  shop.shopId.Value;
                                    var existShop =
                                        Context.GymClubs.FirstOrDefault(c => c.LinkUrl.Equals(shopAddress));
                                    if (existShop != null)
                                        continue;
                                    var phoneNoList = new List<string>();
                                    string phoneNo = shop.shopRecordBean.phoneNo;
                                    if (!string.IsNullOrEmpty(phoneNo))
                                        phoneNoList.Add(phoneNo.Length < 11 ? "0574" + phoneNo : phoneNo);
                                    phoneNo = shop.shopRecordBean.phoneNo2;
                                    if (!string.IsNullOrEmpty(phoneNo))
                                        phoneNoList.Add(phoneNo.Length < 11 ? "0574" + phoneNo : phoneNo);
                                    phoneNo = shop.shopRecordBean.phoneNo3;
                                    if (!string.IsNullOrEmpty(phoneNo))
                                        phoneNoList.Add(phoneNo.Length < 11 ? "0574" + phoneNo : phoneNo);
                                    phoneNo = shop.shopRecordBean.phoneNo4;
                                    if (!string.IsNullOrEmpty(phoneNo))
                                        phoneNoList.Add(phoneNo.Length < 11 ? "0574" + phoneNo : phoneNo);
                                    phoneNo = shop.shopRecordBean.phoneNo5;
                                    if (!string.IsNullOrEmpty(phoneNo))
                                        phoneNoList.Add(phoneNo.Length < 11 ? "0574" + phoneNo : phoneNo);
                                    var club = new GymClub()
                                    {
                                        Id = Guid.NewGuid(),
                                        Name = shop.shopName.Value,
                                        Address = shop.address.Value,
                                        PhoneNo = phoneNoList.ToArray(),
                                        DPLastUpdateTime = Convert.ToDateTime(shop.addDate.Value),
                                        AvgPrice = (int) shop.avgPrice.Value,
                                        GeoLat = shop.geoLat.Value,
                                        GeoLng = shop.geoLng.Value,
                                        ShopPower = (int) shop.shopPower.Value,
                                        ShopPowerTilte = shop.shopPowerTitle.Value,
                                        TotalLevel = shop.shopRecordBean.displayScore,
                                        EquipmentLevel = shop.shopRecordBean.displayScore1,
                                        EnviromentLevel = shop.shopRecordBean.displayScore2,
                                        ServiceLevel = shop.shopRecordBean.displayScore3,
                                        LinkUrl = shopAddress,
                                        DPInfo = JsonConvert.SerializeObject(shop),
                                        LastGrapTime = DateTime.Now
                                    };
                                    Context.GymClubs.Add(club);
                                    Context.SaveChanges();

                                }
                          
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
