using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GymModel
{
    [Table("T_Area")]
    public class Area
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string BaiduInfo { set; get; }
    }
}
