using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wpfAPI.Models
{
    public class Things
    {
        [Key]
        public int ThingID { get; set; }
        public string Name { get; set; }
        public string ThingInfo { get; set; }
        public int Quantity { get; set; }

    }
}