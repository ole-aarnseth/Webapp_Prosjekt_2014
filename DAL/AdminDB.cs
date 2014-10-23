namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Model;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class AdminDB : DbContext
    {
        // Your context has been configured to use a 'AdminDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.AdminDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AdminDB' 
        // connection string in the application configuration file.

        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public AdminDB()
            : base("name=AdminDB")
        {
            Database.CreateIfNotExists();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}