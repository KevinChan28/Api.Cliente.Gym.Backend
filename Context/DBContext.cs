using Aplication.Client.API.DTO;
using Aplication.Client.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Client.API.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<IncomeProduct>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<TrainingShift>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<Customer>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<Address>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<SocialMedia>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<IdentificationImage>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<SuscriptionToExpireData>(eb =>
            {
                eb.HasKey(c => new { c.SuscriptionId });
            });
            modelBuilder.Entity<Tutor>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<PoliticsType>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<Politics>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<TermsAndConditions>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<Kinship>(eb =>
            {
                eb.HasKey(c => new { c.KinshipId });
            });
            modelBuilder.Entity<CustomerPolitics>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<CustomerAnswerTest>(eb =>
            {
                eb.HasKey(c => new { c.Id });
            });
            modelBuilder.Entity<TestHealth>(eb =>
            {
                eb.HasKey(c => new { c.TestId });
                eb.HasKey(c => new { c.QuestionId });
                eb.HasKey(c => new { c.AnswerId });
            });
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<IncomeProduct> IncomeProduct { get; set; }
        public DbSet<TrainingShift> TrainingShift { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<IdentificationImage> IdentificationImage { get; set; }
        public DbSet<SuscriptionToExpireData> SuscriptionExpire { get; set; }
        public DbSet<Tutor> Tutor { get; set; }
        public DbSet<Kinship> Kinship { get; set; }
        public DbSet<CustomerPolitics> CustomerPolitics { get; set; }
        public DbSet<PoliticsType> PoliticsType { get; set; }
        public DbSet<Politics> Politics { get; set; }
        public DbSet<TermsAndConditions> TermsAndConditions { get; set; }
        public DbSet<CustomerAnswerTest> CustomerAnswerTests { get; set; }
        public DbSet<TestHealth> TestHealth { get; set; }
    }
}
