using Microsoft.EntityFrameworkCore;
using lab6.Models;

namespace lab6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ProductAndServiceType> ProductAndServiceTypes { get; set; }
        public DbSet<ProductAndService> ProductsAndServices { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentProductAndService> ShipmentProductsAndServices { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MovementLocation> MovementLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationType>().HasKey(ot => ot.OrganizationTypeCode);
            modelBuilder.Entity<Organization>().HasKey(o => o.OrganizationId);
            modelBuilder.Entity<ProductAndServiceType>().HasKey(pst => pst.ProductSvcTypeCode);
            modelBuilder.Entity<ProductAndService>().HasKey(ps => ps.ProductSvcId);
            modelBuilder.Entity<Shipment>().HasKey(s => s.ShipmentId);
            modelBuilder.Entity<ShipmentProductAndService>().HasKey(sp => new { sp.ShipmentId, sp.ProductSvcId });
            modelBuilder.Entity<Country>().HasKey(c => c.CountryCode);
            modelBuilder.Entity<LocationType>().HasKey(lt => lt.LocationTypeCode);
            modelBuilder.Entity<Location>().HasKey(l => l.LocationId);
            modelBuilder.Entity<MovementLocation>().HasKey(ml => ml.ShipmentLocationId);

            modelBuilder.Entity<Organization>()
                .HasOne(o => o.OrganizationType)
                .WithMany(ot => ot.Organizations)
                .HasForeignKey(o => o.OrganizationTypeCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductAndService>()
                .HasOne(ps => ps.ProductSvcType)
                .WithMany(pst => pst.ProductsAndServices)
                .HasForeignKey(ps => ps.ProductSvcTypeCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.FromOrganization)
                .WithMany(o => o.ShipmentsFrom)
                .HasForeignKey(s => s.FromOrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.ToOrganization)
                .WithMany(o => o.ShipmentsTo)
                .HasForeignKey(s => s.ToOrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShipmentProductAndService>()
                .HasOne(sp => sp.Shipment)
                .WithMany(s => s.ShipmentProducts)
                .HasForeignKey(sp => sp.ShipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ShipmentProductAndService>()
                .HasOne(sp => sp.ProductSvc)
                .WithMany(ps => ps.ShipmentProducts)
                .HasForeignKey(sp => sp.ProductSvcId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Location>()
                .HasOne(l => l.LocationType)
                .WithMany(lt => lt.Locations)
                .HasForeignKey(l => l.LocationTypeCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LocationType>()
                .HasOne(lt => lt.Country)
                .WithMany(c => c.LocationTypes)
                .HasForeignKey(lt => lt.CountryCode)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovementLocation>()
                .HasOne(ml => ml.Shipment)
                .WithMany(s => s.MovementLocations)
                .HasForeignKey(ml => ml.ShipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovementLocation>()
                .HasOne(ml => ml.FromLocation)
                .WithMany(l => l.MovementLocationsFrom)
                .HasForeignKey(ml => ml.FromLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovementLocation>()
                .HasOne(ml => ml.ToLocation)
                .WithMany(l => l.MovementLocationsTo)
                .HasForeignKey(ml => ml.ToLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Organization>().Property(o => o.OrganizationId).ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductAndService>().Property(ps => ps.ProductSvcId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Shipment>().Property(s => s.ShipmentId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>().Property(l => l.LocationId).ValueGeneratedOnAdd();
            modelBuilder.Entity<MovementLocation>().Property(ml => ml.ShipmentLocationId).ValueGeneratedOnAdd();
        }

        public void Seed()
        {

            if (!OrganizationTypes.Any())
            {
                var organizationTypes = new List<OrganizationType>
                {
            new OrganizationType
            {
                OrganizationTypeCode = "CRIME",
                OrganizationTypeDescription = "Criminal Organization"
            },
            new OrganizationType
            {
                OrganizationTypeCode = "LAW",
                OrganizationTypeDescription = "Law Enforcement"
            }
        };
                OrganizationTypes.AddRange(organizationTypes);
                SaveChanges();
            }

            if (!ProductAndServiceTypes.Any())
            {
                var productAndServiceTypes = new List<ProductAndServiceType>
        {
            new ProductAndServiceType
            {
                ProductSvcTypeCode = "DRUG",
                ProductSvcTypeDescription = "Drugs"
            },
            new ProductAndServiceType
            {
                ProductSvcTypeCode = "WEAP",
                ProductSvcTypeDescription = "Weapons"
            },
            new ProductAndServiceType
            {
                ProductSvcTypeCode = "HTRAF",
                ProductSvcTypeDescription = "Human Trafficking"
            }
        };
                ProductAndServiceTypes.AddRange(productAndServiceTypes);
                SaveChanges();
            }

            if (!Countries.Any())
            {
                var countries = new List<Country>
        {
            new Country
            {
                CountryCode = "USA",
                CountryName = "United States",
                CountryCurrency = "USD",
                LanguagesSpoken = "English",
                UsdExchangeRate = 1.0M,
                UsdExchangeDate = DateTime.UtcNow
            },
            new Country
            {
                CountryCode = "JPN",
                CountryName = "Japan",
                CountryCurrency = "JPY",
                LanguagesSpoken = "Japanese",
                UsdExchangeRate = 0.009M,
                UsdExchangeDate = DateTime.UtcNow
            }
        };
                Countries.AddRange(countries);
                SaveChanges();
            }

            if (!LocationTypes.Any())
            {
                var locationTypes = new List<LocationType>
        {
            new LocationType
            {
                LocationTypeCode = "CITY",
                CountryCode = "USA",
                LocationTypeDescription = "City"
            },
            new LocationType
            {
                LocationTypeCode = "REGION",
                CountryCode = "JPN",
                LocationTypeDescription = "Region"
            }
        };
                LocationTypes.AddRange(locationTypes);
                SaveChanges();
            }

            if (!Locations.Any())
            {
                var locations = new List<Location>
        {
            new Location
            {
                LocationTypeCode = "CITY",
                LocationAddress = "New York, NY",
                OtherDetails = "Major crime hotspot"
            },
            new Location
            {
                LocationTypeCode = "REGION",
                LocationAddress = "Osaka, Japan",
                OtherDetails = "Key smuggling hub"
            }
        };
                Locations.AddRange(locations);
                SaveChanges();
            }

            if (!Organizations.Any())
            {
                var organizations = new List<Organization>
        {
            new Organization
            {
                OrganizationTypeCode = "CRIME",
                OrganizationDetails = "Yakuza"
            },
            new Organization
            {
                OrganizationTypeCode = "LAW",
                OrganizationDetails = "FBI"
            }
        };
                Organizations.AddRange(organizations);
                SaveChanges();
            }

            if (!ProductsAndServices.Any())
            {
                var productsAndServices = new List<ProductAndService>
        {
            new ProductAndService
            {
                ProductSvcTypeCode = "DRUG",
                ProductSvcDetails = "Methamphetamine",
                Quantity = 100
            },
            new ProductAndService
            {
                ProductSvcTypeCode = "WEAP",
                ProductSvcDetails = "Automatic Rifles",
                Quantity = 50
            }
        };
                ProductsAndServices.AddRange(productsAndServices);
                SaveChanges();
            }

            if (!Shipments.Any())
            {
                var shipments = new List<Shipment>
        {
            new Shipment
            {
                FromOrganizationId = 1,
                ToOrganizationId = 2,
                ShipmentDetails = "Intercepted drug shipment"
            }
        };
                Shipments.AddRange(shipments);
                SaveChanges();
            }

            if (!ShipmentProductsAndServices.Any())
            {
                var shipmentProductsAndServices = new List<ShipmentProductAndService>
        {
            new ShipmentProductAndService
            {
                ShipmentId = 1,
                ProductSvcId = 1,
                Quantity = 50
            }
        };
                ShipmentProductsAndServices.AddRange(shipmentProductsAndServices);
                SaveChanges();
            }

            if (!MovementLocations.Any())
            {
                var movementLocations = new List<MovementLocation>
        {
            new MovementLocation
            {
                ShipmentId = 1,
                FromLocationId = 1,
                ToLocationId = 2,
                DateStarted = DateTime.UtcNow.AddDays(-5),
                DateCompleted = DateTime.UtcNow.AddDays(-3),
                OtherDetails = "Shipment tracked via satellite"
            }
        };
                MovementLocations.AddRange(movementLocations);
                SaveChanges();
            }
        }



    }


}
