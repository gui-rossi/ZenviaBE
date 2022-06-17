using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDomain.Entities;

namespace UserRepository.DBContext
{
    public class UsersDBContext : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<TelephoneNumberEntity> TelephoneNumbers { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }

        public UsersDBContext(DbContextOptions<UsersDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            ConfigureUserTable(mb);
            ConfigureAddressTable(mb);
            ConfigureTelephoneNumbersTable(mb);

            //1:n relationship between User & TelephoneNumbers
            mb.Entity<TelephoneNumberEntity>()
                .HasOne(tn => tn.User)
                .WithMany(u => u.telephoneNumbers)
                .HasForeignKey(tn => tn.User);

            //1:n relationship between User & Addresses
            mb.Entity<AddressEntity>()
                .HasOne(a => a.User)
                .WithMany(u => u.addresses)
                .HasForeignKey(a => a.User);
        }

        private void ConfigureUserTable(ModelBuilder mb)
        {
            var user = mb.Entity<UserEntity>();

            user.HasKey(x => x.Id);
            user.Property(x => x.Name).HasField("nvarchar").HasMaxLength(100).IsRequired();
            user.Property(x => x.RG).HasField("nvarchar").HasMaxLength(14).IsRequired();
            user.Property(x => x.CPF).HasField("nvarchar").HasMaxLength(16).IsRequired();
            user.Property(x => x.Facebook).HasField("nvarchar").HasMaxLength(256);
            user.Property(x => x.Twitter).HasField("nvarchar").HasMaxLength(256);
            user.Property(x => x.Instagram).HasField("nvarchar").HasMaxLength(256);
            user.Property(x => x.LinkedIn).HasField("nvarchar").HasMaxLength(256);
        }

        private void ConfigureAddressTable(ModelBuilder mb)
        {
            var addresses = mb.Entity<AddressEntity>();

            addresses.HasKey(x => x.Id);
            addresses.Property(x => x.Alias).HasField("nvarchar").HasMaxLength(256).IsRequired();
            addresses.Property(x => x.Address).HasField("nvarchar").HasMaxLength(256).IsRequired();
            addresses.Property(x => x.Number).HasField("nvarchar").HasMaxLength(256).IsRequired();
            addresses.Property(x => x.Complemento).HasField("nvarchar").HasMaxLength(256).IsRequired();
        }

        private void ConfigureTelephoneNumbersTable(ModelBuilder mb)
        {
            var telehoneNumbers = mb.Entity<TelephoneNumberEntity>();

            telehoneNumbers.HasKey(x => x.Id);
            telehoneNumbers.Property(x => x.Alias).HasField("nvarchar").HasMaxLength(256).IsRequired();
            telehoneNumbers.Property(x => x.Number).HasField("nvarchar").HasMaxLength(256).IsRequired();
        }
    }
}
