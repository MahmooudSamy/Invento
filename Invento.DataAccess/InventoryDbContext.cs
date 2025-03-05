using Invento.Model;
using Microsoft.EntityFrameworkCore;

namespace Invento.DataAccess
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = InventoDb; Integrated Security = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(cat =>
            {
                cat.HasKey(c => c.CategoryId);
            });

            modelBuilder.Entity<Item>()
        .HasOne(item => item.Category)
        .WithMany(category => category.Items)
        .HasForeignKey(item => item.CategoryId);

            modelBuilder.Entity<Inventory>(inventory =>
            {
                inventory.HasKey(i => i.InventoryId);
            });

            modelBuilder.Entity<InventoryItem>()
                .HasKey(ii => new { ii.ItemId, ii.InventoryId });


            modelBuilder.Entity<InventoryItem>()
               .HasOne(ii => ii.Item)
               .WithMany(i => i.InventoryItems)
               .HasForeignKey(ii => ii.ItemId);

            modelBuilder.Entity<InventoryItem>()
                .HasOne(ii => ii.Inventory)
                .WithMany(inv => inv.InventoryItems)
                .HasForeignKey(ii => ii.InventoryId);



            modelBuilder.Entity<Category>().HasData(
             new Category { CategoryId = 1, CategoryName = "Electronics" },
             new Category { CategoryId = 2, CategoryName = "Clothing" },
             new Category { CategoryId = 3, CategoryName = "Books" }
         );
            modelBuilder.Entity<Inventory>().HasData(
           new Inventory { InventoryId = 1, InventoryName = "Store A" }

       );
            modelBuilder.Entity<Item>().HasData(
                new Item { ItemId = 1, ItemName = "ASUS Vivobook", CategoryId = 1 },
                new Item { ItemId = 2, ItemName = "Huawei MatePad", CategoryId = 1 },
                new Item { ItemId = 3, ItemName = "Fit Polo Shirt", CategoryId = 2 },
                new Item { ItemId = 4, ItemName = "The North Face Jacket", CategoryId = 2 },
                new Item { ItemId = 5, ItemName = "The Art of Computer Programming", CategoryId = 3 },
                new Item { ItemId = 6, ItemName = "Programming C# 12", CategoryId = 3 },
                new Item { ItemId = 7, ItemName = "Samsung Galaxy S25 Ultra Dual SIM", CategoryId = 1 }

            );

            modelBuilder.Entity<InventoryItem>().HasData(
                new InventoryItem { ItemId = 1, InventoryId = 1, Quantity = 10, LastUpdate = DateTime.Now },
                new InventoryItem { ItemId = 2, InventoryId = 1, Quantity = 20, LastUpdate = DateTime.Now },
                new InventoryItem { ItemId = 3, InventoryId = 1, Quantity = 10, LastUpdate = DateTime.Now },
                new InventoryItem { ItemId = 4, InventoryId = 1, Quantity = 50, LastUpdate = DateTime.Now },
                new InventoryItem { ItemId = 5, InventoryId = 1, Quantity = 20, LastUpdate = DateTime.Now },
                new InventoryItem { ItemId = 6, InventoryId = 1, Quantity = 30, LastUpdate = DateTime.Now },
                new InventoryItem { ItemId = 7, InventoryId = 1, Quantity = 5,  LastUpdate = DateTime.Now }
            );
            base.OnModelCreating(modelBuilder);
        }




    }
}
