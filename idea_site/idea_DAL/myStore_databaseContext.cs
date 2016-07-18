using idea_BLL.Model;
using idea_BLL.Model.Master;
using idea_BLL.Model.User;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace idea_DAL
{
    public class myStore_databaseContext : DbContext
    {
        public myStore_databaseContext() : base("name=myStoreDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        //base.OnModelCreating(modelBuilder);
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //use varchar for string types
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        #region DBSets

        public DbSet<City> Cities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<CustOrder> CustOrders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }

        #endregion DBSets
    }
}