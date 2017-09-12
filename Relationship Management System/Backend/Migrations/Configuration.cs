namespace Relationship_Management_System.Migrations {
	using Relationship_Management_System.Database;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Relationship_Management_System.Database.Database> {
		public Configuration() {
			AutomaticMigrationsEnabled = false;
			ContextKey = "Relationship_Management_System.Database.Database";
		}

		protected override void Seed(Relationship_Management_System.Database.Database context) {
			//This method will be called after migrating to the latest version.

			//You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//to avoid creating duplicate seed data. E.g.


			//TODO: Externalize this to avoid DOXing yourself
			context.Interests.AddOrUpdate(
				new Interest() { Name = "anime", Message = "I see that you like to watch anime, which shows are your favorite, I think mine is currently Spice and Wolf?" },
				new Interest() { Name = "Lord of the Rings", Message = "You like Lord of the Rings, I feel the movies didn't do the plot justice, so I want to read The Silmarillion some day" },
				new Interest() { Name = "volunteer", Message = "I volunteer at Mentorship Saturdays every Saturday where I help people learn to program and progess in there careers" }
			);

			//context.People.AddOrUpdate(
			//  p => p.FullName,
			//  new Person { FullName = "Andrew Peters" },
			//  new Person { FullName = "Brice Lambson" },
			//  new Person { FullName = "Rowan Miller" }
			//);

		}
	}
}
