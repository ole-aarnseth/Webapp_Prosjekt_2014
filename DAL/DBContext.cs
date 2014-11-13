namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Model;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class DBContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<FAQCategory> FAQCategories { get; set; }
        public DbSet<FAQQuestion> FAQQuestions { get; set; }
        public DbSet<EmailedFAQQuestion> EmailedFAQQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DBContext()
            : base("name=DBContext")
        {
            Database.CreateIfNotExists();
        }
    }
}