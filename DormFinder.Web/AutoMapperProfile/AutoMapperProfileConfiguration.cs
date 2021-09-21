using AutoMapper;
using DormFinder.Web.Buildings.Models;
using DormFinder.Web.Charges.Models;
using DormFinder.Web.ChargeTypes.Models;
using DormFinder.Web.Dashboard.Model;
using DormFinder.Web.Entities;
using DormFinder.Web.Entities.Identity;
using DormFinder.Web.Models;
using DormFinder.Web.Models.Request;
using DormFinder.Web.Rooms.Model;
using DormFinder.Web.Rooms.Models;
using DormFinder.Web.Users.Model;
using static DormFinder.Web.Buildings.Models.BuildingDto;

namespace DormFinder.Web.AutoMapperProfile
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("My Profile")
        {
        }

        private AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<Contract, AddContractModel>();
            CreateMap<AddContractModel, Contract>();
            CreateMap<Contract, UpdateContractModel>();
            CreateMap<UpdateContractModel, Contract>();
            CreateMap<Contract, ContractModel>();

            CreateMap<CreateBuildingDto, Building>()
                .ForMember(t => t.BuildingType, opts => opts.Ignore());
            CreateMap<CreateBuildingDto.AddressDto, Address>();
            CreateMap<string, BuildingNearbyPlace>()
                .ConstructUsing(str => new BuildingNearbyPlace { Place = str });

            CreateMap<int, ContractCharge>()
                .ConstructUsing(str => new ContractCharge { ChargeId = str });
            //CreateMap<UpdateBuildingDto, Building>()
            //    .ForMember(t => t.Amenities, opts => opts.Ignore());

            CreateMap<UpdateBuildingDto, Building>()
                .ForMember(t => t.BuildingType, opts => opts.Ignore());
            CreateMap<UpdateBuildingDto.AddressDto, Address>();

            CreateMap<Building, BuildingDto>()
                .ForMember(t => t.BuildingType, opts => opts.MapFrom(u => u.BuildingType.Description));
            CreateMap<Address, BuildingDto.AddressDto>();
            CreateMap<Floor, BuildingDto.FloorDto>();
            CreateMap<BuildingNearbyPlace, BuildingDto.NearByPlacesDto>();
            CreateMap<ContractCharge, ContractModel.ContractChargeDto>();

            CreateMap<BuildingType, BuildingTypeDto>();
            CreateMap<BuildingTypeDto, BuildingType>();

            CreateMap<Charge, ChargeDto>();
            CreateMap<CreateChargeDto, Charge>();

            CreateMap<ChargeType, ChargeTypeDto>();

            CreateMap<City, CityDto>();
            CreateMap<Province, ProvinceDto>();

            CreateMap<FileEntry, FileEntryDto>();

            CreateMap<Room, RoomDto>();
            CreateMap<RoomType, RoomDto.RoomTypeDto>();
            CreateMap<RoomInclusion, RoomDto.RoomInclusionDto>();
            CreateMap<Inclusion, RoomDto.RoomInclusionDto.InclusionDto>();
            CreateMap<RoomPic, RoomDto.RoomPicDto>();
            CreateMap<FileEntry, RoomDto.RoomPicDto.FileEntryDto>();

            CreateMap<User, RegisterModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<Address, UserModel.AddressDto>();
            CreateMap<User, UserModel>()
                .ForMember(t => t.Address, opts => opts.MapFrom(t => t.Address));
            CreateMap<User, UserDto>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<AddressDto, Address>();

            CreateMap<Room, RentRoomDto>();
            CreateMap<Building, RentRoomDto.RentBuildingDto>();
            CreateMap<Address, RentRoomDto.RentBuildingDto.RentAddressDto>();
            CreateMap<RoomPic, RentRoomDto.RoomPicDto>();

            CreateMap<Building, BuildingPropertyDto>();
            CreateMap<Room, BuildingPropertyDto.RoomDto>();
            CreateMap<RoomPic, BuildingPropertyDto.RoomDto.RoomPicDto>();
            CreateMap<Address, BuildingPropertyDto.PropertAddressDto>();

            CreateMap<Room, RoomPropertyDto>();
            CreateMap<RoomPic, RoomPropertyDto.RoomPicDto>();
            CreateMap<Building, RoomPropertyDto.BuildingDto>();
            CreateMap<BuildingPic, RoomPropertyDto.BuildingDto.BuildingPicDto>();
            CreateMap<BuildingAmenity, RoomPropertyDto.BuildingDto.BuildingAmenitiesDto>();
            CreateMap<Amenity, RoomPropertyDto.BuildingDto.BuildingAmenitiesDto.AmenityDto>();
            CreateMap<Address, RoomPropertyDto.BuildingDto.PropertAddressDto>();
            CreateMap<RoomInclusion, RoomPropertyDto.RoomInclusionDto>();
            CreateMap<Inclusion, RoomPropertyDto.RoomInclusionDto.InclusionDto>();
            CreateMap<RoomType, RoomPropertyDto.RoomTypeDto>();

            CreateMap<CreateRoomDto, Room>();
            CreateMap<UserModel, User>();
            CreateMap<UserModel, RegisterModel>();
            CreateMap<RegisterModel, UserModel>();

            CreateMap<Lead, AddLeadModel>();
            CreateMap<AddLeadModel, Lead>();
            CreateMap<Lead, LeadModel>();

            CreateMap<Building, DashboardDto>();
            CreateMap<Room, DashboardDto.RoomDto>();
            CreateMap<Floor, DashboardDto.RoomDto.FloorDtos>();
            CreateMap<Bedspace, DashboardDto.RoomDto.BedspaceDto>();
            CreateMap<Floor, DashboardDto.FloorDto>();
            CreateMap<Room, DashboardDto.FloorDto.RoomFloorDto>();
            CreateMap<Bedspace, DashboardDto.FloorDto.RoomFloorDto.BedspaceFloorDto>();

            CreateMap<User, TenantDto.UserDto>();
            CreateMap<Room, TenantDto.RoomDto>();
            CreateMap<Contract, TenantDto.ContractDto>();
            CreateMap<Building, TenantDto.BuildingDto>();
            CreateMap<Tenant, TenantDto>()
                .ForMember(t => t.User, opts => opts.MapFrom(t => t.User))
                .ForMember(t => t.Room, opts => opts.MapFrom(t => t.Room))
                .ForMember(t => t.Contract, opts => opts.MapFrom(t => t.Contract))
                .ForMember(t => t.Building, opts => opts.MapFrom(t => t.Room.Building))
                .ForPath(t => t.User.FullName, opts => opts.MapFrom(t => $"{t.User.FirstName} {t.User.LastName}"));

            CreateMap<CreateTenantDto, Tenant>();

            CreateMap<Bedspace, BedspaceViewModel>();

            CreateMap<Tenant, TenantContractDto>();
            CreateMap<Contract, TenantContractDto.ContractDto>();

            CreateMap<CreateBillingPeriodDto, BillingPeriod>();
            CreateMap<BillingPeriod,BillingPeriodDto>();
        }
    }
}
