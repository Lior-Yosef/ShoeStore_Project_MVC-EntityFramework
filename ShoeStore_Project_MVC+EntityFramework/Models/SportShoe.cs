using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore_Project_MVC_EntityFramework.Models
{
    public class SportShoe
    {
        public int Id;
        public string CompanyName;
        public string ModelName;
        public int Size;
        public int Price;

        public SportShoe(int id, string companyName, string modelName, int size, int price)
        {
            this.Id = id;
            this.CompanyName = companyName;
            this.ModelName = modelName;
            this.Size = size;
            this.Price = price;
        }
    }
}