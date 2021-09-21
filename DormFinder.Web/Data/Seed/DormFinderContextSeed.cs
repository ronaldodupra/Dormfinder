using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DormFinder.Web.Entities;

namespace DormFinder.Web.Data.Seed
{
    public class DormFinderContextSeed
    {
        public async Task Seed(DormFinderContext context)
        {
            context.Buildings.AddRange(GetBuildings());
            context.Leads.AddRange(GetLeads());
            context.BuildingTypes.AddRange(GetBuildingTypes());
            context.Contracts.AddRange(GetContracts());
            context.Tenants.AddRange(GetTenants());
            context.Charges.AddRange(GetCharges());
            context.Room.AddRange(GetRooms());
            context.Inclusions.AddRange(GetInclusions());
            context.RoomInclusions.AddRange(GetRoomInclusions());
            context.Cities.AddRange(GetCities());
            context.Provinces.AddRange(GetProvinces());

            await context.SaveChangesAsync();
        }

        public Collection<Building> GetBuildings()
        {
            return new Collection<Building>()
            {
                new Building()
                {
                    OrganizationId = 1,
                    Name = "Acme Tower",
                    Description = "The Tower named Acme",
                    Address = new Address()
                    {
                        Province = "Metro Manila",
                        City = "Mandaluyong",
                        AddressLine1 = "154 San Pedro St",
                        Latitude = 14.5794m,
                        Longitude = 121.0359m
                    }
                },
                new Building()
                {
                    OrganizationId = 1,
                    Name = "Acme Tower",
                    Description = "The Tower named Acme",
                    Address = new Address()
                    {
                        Province = "Metro Manila",
                        City = "Quezon City",
                        AddressLine1 = "312 Julio St",
                        Latitude = 14.676m,
                        Longitude = 121.0437m
                    }
                }
            };
        }

        public Collection<BuildingType> GetBuildingTypes()
        {
            return new Collection<BuildingType>()
            {
                new BuildingType("Condominium"),
                new BuildingType("Dormitory"),
            };
        }

        public Collection<Lead> GetLeads()
        {
            return new Collection<Lead>()
            {
                new Lead()
                {
                    OrganizationId = 1,
                    Email = "alice@example.com",
                    FirstName = "Alice",
                    LastName = "Wonderland",
                    Message = "Hello",
                    Number = "09199199910",
                    RoomId = 1
                },
                new Lead()
                {
                    OrganizationId = 1,
                    Email = "julius@example.com",
                    FirstName = "Julius",
                    LastName = "Caesar",
                    Message = "Vini, vidi vici",
                    Number = "09192010235",
                    RoomId = 2
                }
            };
        }

        public Collection<Contract> GetContracts()
        {
            return new Collection<Contract>()
            {
                new Contract()
                {
                    OrganizationId = 1,
                    RentalEffectivityDate = DateTime.Now,
                    RentalEndDate = DateTime.Now.AddMonths(3),
                    MoveInDate = DateTime.Now,
                    MoveOutDate = DateTime.Now.AddMonths(3),
                    ReservationStartDate = DateTime.Now,
                    ReservationExpirationDate = DateTime.Now.AddMonths(3),
                    AllowableReservationDays = 1,
                    EarlyTerminationFee = 1000,
                    TenantName = "Thor Odinson",
                    UnitNumber = "001",
                    BedSpaceNumber = "01",
                    SecurityDeposit = 1500,
                    RFIDDeposit = 1000,
                    BasicRent = 2500,
                    Status = "Reserved"
                },
                new Contract()
                {
                    OrganizationId = 1,
                    RentalEffectivityDate = DateTime.Now,
                    RentalEndDate = DateTime.Now.AddMonths(2),
                    MoveInDate = DateTime.Now,
                    MoveOutDate = DateTime.Now.AddMonths(2),
                    ReservationStartDate = DateTime.Now,
                    ReservationExpirationDate = DateTime.Now.AddMonths(2),
                    AllowableReservationDays = 2,
                    EarlyTerminationFee = 1200,
                    TenantName = "Loki Laufeyson",
                    UnitNumber = "002",
                    BedSpaceNumber = "02",
                    SecurityDeposit = 1200,
                    RFIDDeposit = 1200,
                    BasicRent = 2200,
                    Status = "Cancelled"
                }
            };
        }

        public Collection<Tenant> GetTenants()
        {
            return new Collection<Tenant>()
            {
                new Tenant()
                {
                    OrganizationId = 1,
                    Id = 1,
                    ContractId = 1,
                    RoomId = 2,
                    UserId = 1,
                },
                new Tenant()
                {
                    OrganizationId = 1,
                    Id = 2,
                    ContractId = 2,
                    RoomId = 3,
                    UserId = 4,
                }
            };
        }
        
        public Collection<Charge> GetCharges()
        {
            return new Collection<Charge>()
            {
                new Charge()
                {
                    OrganizationId = 1,
                    Id = 1,
                    BillingStatementOrder = 1,
                    DefaultCharge = 100,
                    IsVat = true,
                    Amount = 100,
                    Comments = "Comment 1",
                    Date = DateTime.Now,
                    ChargeTypeId = 1,
                },
                new Charge()
                {
                    OrganizationId = 1,
                    Id = 2,
                    BillingStatementOrder = 2,
                    DefaultCharge = 200,
                    IsVat = false,
                    Amount = 200,
                    Comments = "Comment 2",
                    Date = DateTime.Now,
                    ChargeTypeId = 2,
                }
            };
        }

        public Collection<Room> GetRooms()
        {
            return new Collection<Room>()
            {
                new Room()
                {
                    OrganizationId = 1,
                    Id = 1,
                    RoomName = "Room 101",
                    Area = 75,
                    BuildingId = 1,
                    RoomType = new RoomType()
                    {
                        Id = 1,
                        AllowedPerson = 4,
                        RoomTypeName = "Four Person Room",
                    },
                    BasicRent = 7500,
                    AdvanceRent = 2000,
                    Description = "Acme Tower, Room 101",
                    RoomNumber = "101",
                    IsActive = true,
                },
                new Room()
                {
                    OrganizationId = 1,
                    Id = 2,
                    RoomName = "Room 201",
                    Area = 75,
                    BuildingId = 2,
                    RoomType = new RoomType()
                    {
                        Id = 2,
                        AllowedPerson = 2,
                        RoomTypeName = "Two Person Room",
                    },
                    BasicRent = 8500,
                    AdvanceRent = 2000,
                    Description = "Acme Tower, Room 201",
                    RoomNumber = "201",
                    IsActive = true,
                }
            };
        }

        public Collection<Inclusion> GetInclusions()
        {
            return new Collection<Inclusion>()
            {
                new Inclusion()
                {
                    OrganizationId = 1,
                    Id = 1,
                    InclusionName = "Wi-fi",
                },
                new Inclusion()
                {
                    OrganizationId = 1,
                    Id = 2,
                    InclusionName = "Parking",
                },
                new Inclusion()
                {
                    OrganizationId = 1,
                    Id = 3,
                    InclusionName = "Aircon"
                }
            };
        }

        public Collection<RoomInclusion> GetRoomInclusions()
        {
            return new Collection<RoomInclusion>()
            {
                new RoomInclusion()
                {
                    OrganizationId = 1,
                    Id = 1,
                    InclusionId = 1,
                    roomId = 1,
                },
                new RoomInclusion()
                {
                    OrganizationId = 1,
                    Id = 2,
                    InclusionId = 3,
                    roomId = 1,
                },
                new RoomInclusion()
                {
                    OrganizationId = 1,
                    Id = 3,
                    InclusionId = 2,
                    roomId = 2,
                },
                new RoomInclusion()
                {
                    OrganizationId = 1,
                    Id = 4,
                    InclusionId = 3,
                    roomId = 2
                }
            };
        }

        public Collection<City> GetCities()
        {
            return new Collection<City>()
            {
                new City()
                {
                    Description = "Mandaluyong"
                },
                new City()
                {
                    Description = "Quezon City"
                },
                new City()
                {
                    Description = "Taguig"
                }
            };
        }

        public Collection<Province> GetProvinces()
        {
            return new Collection<Province>()
            {
                new Province()
                {
                    Description = "Metro Manila"
                },
                new Province()
                {
                    Description = "Rizal"
                },
                new Province()
                {
                    Description = "Cavite"
                }
            };
        }
    }
}
