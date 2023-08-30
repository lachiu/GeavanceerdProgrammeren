using examen_models;
using Microsoft.EntityFrameworkCore;

namespace examen_DAL
{
	public class TicketContext : DbContext
	{
		public DbSet<Location> Locations { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Stock> Stocks { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<TicketsProducts> TicketsProducts { get; set; }
		public DbSet<VatPercentage> VatPercentages { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TicketDB;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			/* Seeding */
			/* Creating general stores */
			builder.Entity<Store>().HasData(new Store { Id = 1, Name = "Lidl" });
			builder.Entity<Store>().HasData(new Store { Id = 2, Name = "Carrefour" });
			builder.Entity<Store>().HasData(new Store { Id = 3, Name = "Spar" });
			builder.Entity<Store>().HasData(new Store { Id = 4, Name = "Action" });
			builder.Entity<Store>().HasData(new Store { Id = 5, Name = "Aldi" });
			builder.Entity<Store>().HasData(new Store { Id = 6, Name = "Delhaize" });
			builder.Entity<Store>().HasData(new Store { Id = 7, Name = "Albert Heijn" });
			builder.Entity<Store>().HasData(new Store { Id = 8, Name = "Jumbo" });

			/* Creating general Vat Percentages */
			builder.Entity<VatPercentage>().HasData(new VatPercentage { Id = 1, Percentage = 0 });
			builder.Entity<VatPercentage>().HasData(new VatPercentage { Id = 2, Percentage = 6 });
			builder.Entity<VatPercentage>().HasData(new VatPercentage { Id = 3, Percentage = 11 });
			builder.Entity<VatPercentage>().HasData(new VatPercentage { Id = 4, Percentage = 21 });

			/* Creating general products */
			builder.Entity<Product>().HasData(new Product { Id = 1, Name = "Verse banaan", Description = "Verse banaan uit Colombia.", Barcode = "1" });
			builder.Entity<Product>().HasData(new Product { Id = 2, Name = "Crème brûlée", Description = "Glazen potje.", Barcode = "2" });
			builder.Entity<Product>().HasData(new Product { Id = 3, Name = "Taart", Description = "Taart.", Barcode = "3" });
			builder.Entity<Product>().HasData(new Product { Id = 4, Name = "Wit brood", Description = "Wit brood, 900g.", Barcode = "4" });
			builder.Entity<Product>().HasData(new Product { Id = 5, Name = "Brik halfvolle melk 1L", Description = "Halfvolle melk van de lokale boer.", Barcode = "5" });
			builder.Entity<Product>().HasData(new Product { Id = 6, Name = "Appel", Description = "Appel van de lokale boer zonder pesticide.", Barcode = "6" });
			builder.Entity<Product>().HasData(new Product { Id = 7, Name = "Koffie melk 330cl", Description = "Flesje koffie melk.", Barcode = "7" });
			builder.Entity<Product>().HasData(new Product { Id = 8, Name = "Dubbeldrank Ananas & guave", Description = "Een fruitdrink met de verrassende smaakcombinatie ananas en guave. Een fruitdrink met de verrassende smaakcombinatie ananas en guave.", Barcode = "8" });

			/* Creating general location */
			builder.Entity<Location>().HasData(new Location { Id = 1, Name = "Koelkast garage" });
			builder.Entity<Location>().HasData(new Location { Id = 2, Name = "Koelkast keuken" });
			builder.Entity<Location>().HasData(new Location { Id = 3, Name = "Bankje kelder links 1" });
			builder.Entity<Location>().HasData(new Location { Id = 4, Name = "Bankje kelder links 2" });

			/* Creating general stock  */
			builder.Entity<Stock>().HasData(new Stock { Id = 1, Qty = 1, LocationId = 1, ProductId = 1 });
			builder.Entity<Stock>().HasData(new Stock { Id = 2, Qty = 3, LocationId = 2, ProductId = 1 });
			builder.Entity<Stock>().HasData(new Stock { Id = 3, Qty = 1, LocationId = 1, ProductId = 3 });
			builder.Entity<Stock>().HasData(new Stock { Id = 4, Qty = 1, LocationId = 3, ProductId = 4 });

			/* Creating general tickets */
			builder.Entity<Ticket>().HasData(new Ticket { Id = 1, StoreId = 1, Total = 2.00, PurchaseDate = System.DateTime.Now });
			builder.Entity<Ticket>().HasData(new Ticket { Id = 2, StoreId = 7, Total = 7.00, PurchaseDate = System.DateTime.Now });

			/* Creating general products for tickets */
			builder.Entity<TicketsProducts>().HasData(new TicketsProducts { Id = 1, ProductId = 1, Qty = 2, UnitPrice = 1.00, TicketId = 1, VatPercentageId = 1 });
			builder.Entity<TicketsProducts>().HasData(new TicketsProducts { Id = 2, ProductId = 8, Qty = 5, UnitPrice = 1.40, TicketId = 2, VatPercentageId = 4 });
		}
	}
}