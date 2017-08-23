namespace Relationship_Management_System.Database {
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class Database : DbContext {
		// Your context has been configured to use a 'Database' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'Relationship_Management_System.Database.Database' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'Database' 
		// connection string in the application configuration file.
		public Database()
			: base("name=Database") {
		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		public virtual DbSet<Interest> Interests { get; set; }
		public virtual DbSet<ContactedProfiles> ContactedProfiles { get; set; }
		public virtual DbSet<ProCon> ProsCons { get; set; }
		public virtual DbSet<Contact> Contacts { get; set; }
		public virtual DbSet<SocialLink> SocialLinks { get; set; }
		public DbSet<Location> Locations { get; set; }
		private DbSet<Setting> Settings { get; set; }


		public Setting Setting {
			get {
				if (!Settings.Any()) {
					Settings.Add(new Setting());
				}

				return Settings.FirstOrDefault();
			}
		}
	}
}