
using GoingTo_API_DP.Domain.Model;
using GoingTo_API_DP.Domain.Model.Accounts;
using GoingTo_API_DP.Domain.Model.Business;
using GoingTo_API_DP.Domain.Model.Geographic;
using GoingTo_API_DP.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GoingTo_API_DP.Domain.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Locatable> Locatables { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PlanUser> PlanUsers { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //City Entity

            builder.Entity<City>().ToTable("Cities");
            builder.Entity<City>().HasKey(p => p.Id);
            builder.Entity<City>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<City>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<City>().Property(p => p.CountryId).IsRequired();
            builder.Entity<City>().Property(p => p.LocatableId).IsRequired();
            builder.Entity<City>()
                .HasMany(p => p.Places)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId);

            //Country Entity

            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<Country>().HasKey(p => p.Id);
            builder.Entity<Country>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(p => p.ShortName).IsRequired().HasMaxLength(3);
            builder.Entity<Country>().Property(p => p.FullName).IsRequired().HasMaxLength(100);
            builder.Entity<Country>().Property(p => p.LocatableId).IsRequired();
            builder.Entity<Country>()
                .HasMany(p => p.Cities)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId);
            builder.Entity<Country>()
                .HasMany(p => p.Profiles)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId);


            //Locatable Entity

            builder.Entity<Locatable>().ToTable("Locatables");
            builder.Entity<Locatable>().HasKey(p => p.Id);
            builder.Entity<Locatable>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Locatable>().Property(p => p.Address).IsRequired().HasMaxLength(45);
            builder.Entity<Locatable>().Property(p => p.Description).HasMaxLength(100);
            builder.Entity<Locatable>().Property(p => p.Latitude);
            builder.Entity<Locatable>().Property(p => p.Longitude);

            builder.Entity<Locatable>()
                .HasOne(p => p.City)
                .WithOne(p => p.Locatable)
                .HasForeignKey<City>(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasOne(p => p.Country)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Country>(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasOne(p => p.Place)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Place>(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasMany(p => p.Visits)
                .WithOne(p => p.Locatable)
                .HasForeignKey(p => p.LocatableId);

            //Place Entity

            builder.Entity<Place>().ToTable("Places");
            builder.Entity<Place>().HasKey(p => p.Id);
            builder.Entity<Place>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Place>().Property(p => p.CityId).IsRequired();
            builder.Entity<Place>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Place>().Property(p => p.Stars);
            builder.Entity<Place>().Property(p => p.LocatableId).IsRequired();


            //Plan Entity

            builder.Entity<Plan>().ToTable("Plans");
            builder.Entity<Plan>().HasKey(p => p.Id);
            builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<Plan>()
                .HasMany(p => p.PlanUsers)
                .WithOne(p => p.Plan)
                .HasForeignKey(p => p.PlanId);




            //PlanUsers Entity

            builder.Entity<PlanUser>().ToTable("PlanUsers");
            builder.Entity<PlanUser>().HasKey(p => new { p.UserId, p.PlanId });
            builder.Entity<PlanUser>().Property(p => p.StartDate);
            builder.Entity<PlanUser>().Property(p => p.EndDate);



            //User Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(45);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(45);
            builder.Entity<User>()
                .HasOne(p => p.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);
            builder.Entity<User>()
                .HasMany(p => p.Trips)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);


            //UserProfile Entity

            builder.Entity<UserProfile>().ToTable("UserProfiles");
            builder.Entity<UserProfile>().HasKey(p => p.Id);
            builder.Entity<UserProfile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasMaxLength(11);
            builder.Entity<UserProfile>().Property(p => p.UserId).IsRequired();
            builder.Entity<UserProfile>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<UserProfile>().Property(p => p.Surname).IsRequired().HasMaxLength(45);
            builder.Entity<UserProfile>().Property(p => p.BirthDate);
            builder.Entity<UserProfile>().Property(p => p.Gender).HasMaxLength(6);
            builder.Entity<UserProfile>().Property(p => p.CreatedAt);
            builder.Entity<UserProfile>().Property(p => p.CountryId).IsRequired();

            // Trip Entity

            builder.Entity<Trip>().ToTable("Trips");
            builder.Entity<Trip>().HasKey(p => p.Id);
            builder.Entity<Trip>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Trip>().Property(p => p.UserId).IsRequired();
            builder.Entity<Trip>().Property(p => p.Name).IsRequired();
            builder.Entity<Trip>().Property(p => p.Description).IsRequired();
            builder.Entity<Trip>()
                .HasMany(p => p.Visits)
                .WithOne(p => p.Trip)
                .HasForeignKey(p => p.TripId);


            // Visit Entity

            builder.Entity<Visit>().ToTable("Visits");
            builder.Entity<Visit>().HasKey(p => p.Id);
            builder.Entity<Visit>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            

            ApplySnakeCaseNamingConvention(builder);
        }
        private void ApplySnakeCaseNamingConvention(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());
                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCase());
                foreach (var foreignKey in entity.GetForeignKeys())
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
                foreach (var index in entity.GetIndexes())
                    index.SetName(index.GetName().ToSnakeCase());
            }
        }
    }

}
