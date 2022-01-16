using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore_Project_MVC_EntityFramework.Models
{
    public class ElegantShoes
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Gender { get; set; }
        public bool hasHeel { get; set; }
        public bool inStock { get; set; }
        public int size { get; set; }
        public int price { get; set; }


    }
}