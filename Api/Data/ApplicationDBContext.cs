using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserWallets> UserWallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Currencie> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>().HasKey(u => u.Id);
            modelBuilder.Entity<Budget>(b =>
            {
                b.Property(x => x.StartDate).HasDefaultValueSql("NOW()");
            });
            modelBuilder.Entity<Transaction>(b =>
            {
                b.Property(x => x.Date).HasDefaultValueSql("NOW()");
            });
            modelBuilder.Entity<Attachment>(b =>
            {
                b.Property(x => x.UploadedAt).HasDefaultValueSql("NOW()");
            });
            modelBuilder.Entity<Currencie>(b =>
            {
                b.Property(x => x.UpdateAt).HasDefaultValueSql("NOW()");
            });

            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Budgets)
                .HasForeignKey(b => b.CategoryId);
            modelBuilder.Entity<Budget>()
                .HasOne(b => b.AppUser)
                .WithMany(u => u.Budgets)
                .HasForeignKey(b => b.UserId);
            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Currencie)
                .WithMany(u => u.Budgets)
                .HasForeignKey(b => b.CurrencyId);

            modelBuilder.Entity<UserWallets>()
                .HasOne(ua => ua.AppUser)
                .WithMany(u => u.UserAccounts)
                .HasForeignKey(ua => ua.WalletId);
            modelBuilder.Entity<UserWallets>()
                .HasOne(ua => ua.Currencie)
                .WithMany(u => u.UserAccounts)
                .HasForeignKey(ua => ua.CurrencieId);
            modelBuilder.Entity<UserWallets>()
                .Property(w => w.WalletId)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<SequentialGuidValueGenerator>();

            modelBuilder.Entity<Transaction>()
                .HasOne(a => a.AppUser)
                .WithMany(u => u.Transactions)
                .HasForeignKey(a => a.UserId);
            modelBuilder.Entity<Transaction>()
                .HasOne(a => a.Currencie)
                .WithMany(u => u.Transactions)
                .HasForeignKey(a => a.CurrencieId);
            modelBuilder.Entity<Transaction>()
                .Property(w => w.TransactionId)
                .ValueGeneratedOnAdd()
                .HasValueGenerator<SequentialGuidValueGenerator>();

            modelBuilder.Entity<Attachment>()
                .HasOne(a => a.Transaction)
                .WithMany(u => u.Attachments)
                .HasForeignKey(a => a.TransactionId);

            /*modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            );*/
        }
    }
}
