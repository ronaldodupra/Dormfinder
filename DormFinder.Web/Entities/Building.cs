using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Humanizer;
namespace DormFinder.Web.Entities
{
    public class Building : BaseEntity
    {
        public int Id { get; private set; }

        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime AlertRentalEffectivityEndDate { get; set; }

        public DateTime AlertReservationExpirationDate { get; set; }

        public bool IsActive { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        public BuildingType BuildingType { get; set; }

        public ICollection<BuildingPic> BuildingPics { get; set; }

        public ICollection<BuildingAmenity> BuildingAmenities { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public ICollection<BuildingNearbyPlace> BuildingNearbyPlaces { get; set; }

        [NotMapped]
        public List<string> Inclusions { get; set; } = new List<string>();

        public ICollection<Floor> Floors { get; set; } = new List<Floor>();

        public Building()
        {
            IsActive = true;
            BuildingPics = new Collection<BuildingPic>();
            BuildingAmenities = new Collection<BuildingAmenity>();
            BuildingNearbyPlaces = new Collection<BuildingNearbyPlace>();
        }

        public void AddBuildingPic(int fileEntryId)
        {
            var buildingPic = new BuildingPic();
            buildingPic.BuildingId = Id;
            buildingPic.FileEntryId = fileEntryId;

            BuildingPics.Add(buildingPic);
        }
        public void AddFloors(int floorId)
        {
            var floor = new Floor();
            floor.BuildingId = Id;
            floor.Description = floorId.Ordinalize();

            Floors.Add(floor);
        }
        public void AddNearbyPlace(string place)
        {

            var nearByPlace = new BuildingNearbyPlace();
            nearByPlace.Place = place;
            BuildingNearbyPlaces.Add(nearByPlace);


        }
    }
}
