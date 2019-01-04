namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
		/// <summary>
		/// For those who are having this issue, "IDENTITY INSERT" 
		/// is a T-SQL setting which prevents you from supplying your own primary keys. 
		/// If you are using INT as your Genre.Id, you can just insert the movies like this:

		///Sql("INSERT INTO Genres (Name) VALUES ('Action')");
		/// </summary>
		public override void Up()
        {
			//Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
			//Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Thriller')");
			//Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Family')");
			//Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
			//Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");

			Sql("INSERT INTO Genres (Name) VALUES ('Action')");
			Sql("INSERT INTO Genres (Name) VALUES ('Thriller')");
			Sql("INSERT INTO Genres (Name) VALUES ('Family')");
			Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
			Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
		}

		public override void Down()
        {
        }
    }
}
