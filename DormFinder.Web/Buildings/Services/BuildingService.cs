using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Buildings.Models;
using DormFinder.Web.Entities;
using DormFinder.Web.Services;

namespace DormFinder.Web.Buildings.Services
{
    public class BuildingService
    {
        private readonly IBuildingRepository _repository;
        private readonly IMapper _mapper;

        public BuildingService(IBuildingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BuildingDto> Create(CreateBuildingDto createDto, int orgId)
        {
            var building = _mapper.Map<Building>(createDto);
            createDto.FileEntries?.ToList().ForEach(t => building.AddBuildingPic(t.Id));
            createDto.FloorEntries?.ToList().ForEach(t => building.AddFloors(t));
            createDto.NearByEntries?.ToList().ForEach(t => building.AddNearbyPlace(t));


            await MapBuildingType(building, createDto.BuildingType);
            //await MapFloors(building, createDto.FloorNumber);
            MapGeolocation(building, building.Address.Latitude, building.Address.Longitude);

            building.OrganizationId = orgId;

            await _repository.Create(building);

            return _mapper.Map<BuildingDto>(building);
        }

        public async Task<BuildingDto> Update(int buildingId, UpdateBuildingDto updateDto)
        {
            await _repository.RemoveNearByPlace(buildingId);

            var building = await _repository.GetById(buildingId);

            _mapper.Map(updateDto, building);

            await MapBuildingType(building, updateDto.BuildingType);
            MapGeolocation(building, updateDto.Address.Latitude, updateDto.Address.Longitude);
           
            updateDto.FloorEntries.ToList().ForEach(x => building.AddFloors(x));
            updateDto.NearByEntries.ToList().ForEach(x => building.AddNearbyPlace(x));

            await _repository.SaveChanges();
            return _mapper.Map<BuildingDto>(building);
        }

        private async Task MapBuildingType(Building building, string buildingTypeDesc)
        {
            var buildingTypes = await _repository.TypeList();
            var buildingType = buildingTypes.FirstOrDefault(t => t.Description == buildingTypeDesc);

            building.BuildingType = buildingType;
        }

        private void MapGeolocation(Building building, decimal? latitude, decimal? longitude)
        {
            static decimal? truncate(decimal? value, int decimals = 6)
            {
                var factor = (decimal)Math.Pow(10, decimals);
                var result = Math.Truncate(factor * value.GetValueOrDefault()) / factor;
                return result;
            }

            if (building.Address is null)
            {
                return;
            }

            if (building.Address.Latitude == 0 || building.Address.Longitude == 0)
            {
                return;
            }

            building.Address.Latitude = truncate(latitude);
            building.Address.Longitude = truncate(longitude);
        }
        private void MapFloors(Building building, int floor)
        {
            
            for (int i= 0; i >= floor; ++i)
            {

            }
        }
    }
}
