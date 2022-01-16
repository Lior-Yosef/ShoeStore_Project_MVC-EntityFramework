using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShoeStore_Project_MVC_EntityFramework.Models
{
    public partial class ShoeStoreDataContext : DbContext
    {
        public ShoeStoreDataContext()
            : base("name=ShoeStoreDataContext")
        {
        }
        public virtual DbSet<ElegantShoes> ElegantShoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
