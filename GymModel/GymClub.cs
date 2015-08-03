using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GymModel
{
    [Table("T_GymClub")]
    public class GymClub
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        //public string[] Alias { set; get; }
        public string LinkUrl { set; get; }
        public string Address { set; get; }
        public string[] PhoneNo { set; get; }
        /// <summary>
        /// 星级
        /// </summary>
        public int ShopPower { set; get; }
        public string ShopPowerTilte { set; get; }
        /// <summary>
        /// 人均价格
        /// </summary>
        public int AvgPrice { set; get; }

        public double TotalLevel { set; get; }
        public double EquipmentLevel { set; get; }
        public double EnviromentLevel { set; get; }
        public double ServiceLevel { set; get; }
        public double GeoLat { set; get; }
        public double GeoLng { set; get; }

        public string DPInfo { set; get; }
        public DateTime DPLastUpdateTime { set; get; }

        public DateTime LastGrapTime { set; get; }
    }
}
