using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Core.Files;
using DormFinder.Web.Entities;
using DormFinder.Web.Rooms.Model;
using DormFinder.Web.Rooms.Models;
using DormFinder.Web.Services;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Http;

namespace DormFinder.Web.Rooms.Service
{
    public class RoomService
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IBedspaceRepository _bedspaceRepository;
        private readonly IRoomInclusionRepository _roomInclusionRepository;
        private readonly IFileEntryRepository _fileEntryRepository;
        public RoomService(IMapper mapper,IRoomRepository roomRepository,IBedspaceRepository bedspaceRepository,
            IRoomInclusionRepository roomInclusionRepository,
            IFileEntryRepository fileEntryRepository)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _bedspaceRepository = bedspaceRepository;
            _roomInclusionRepository = roomInclusionRepository;
            _fileEntryRepository = fileEntryRepository;
            
        }

        public async Task<RoomDto> AddRoom(CreateRoomDto _createRoomDto, int orgId)
        {
            var room = _mapper.Map<Room>(_createRoomDto);
            _createRoomDto.RoomInclusions.ToList().ForEach(t =>room.AddInclusion(t));

            room.OrganizationId = orgId;

            static decimal? truncate(decimal? value, int decimals = 6)
            {
                var factor = (decimal)Math.Pow(10, decimals);
                var result = Math.Truncate(factor * value.GetValueOrDefault()) / factor;
                return result;
            }
            if (_createRoomDto.BasicRent != null)
            {
                _createRoomDto.BasicRent= truncate(_createRoomDto.BasicRent);
                
            }else if (_createRoomDto.Area != null)
            {
                _createRoomDto.Area = truncate(_createRoomDto.Area);
            }
            bool getFirst= true;
            _createRoomDto.FileEntries.ToList().ForEach(t => {
                if (getFirst)
                {
                    room.addRoomPicAsThumbnail(t.Id);
                    getFirst = false;
                }
                else
                {
                    room.AddRoomPic(t.Id);
                }
            });

            await _roomRepository.Create(room);
            await _bedspaceRepository.AddBedspace(_createRoomDto.type, room.Id);

            return _mapper.Map<RoomDto>(room);

        }
        public async Task<RoomDto> UpdateRoom(int Id,CreateRoomDto _createRoomDto)
        {
            var room = _mapper.Map<Room>(_createRoomDto);
            var getRoom =await _roomRepository.GetRoom(Id);
            var map=_mapper.Map(_createRoomDto, getRoom);


            //if room type is change bedspace replaced
            if (getRoom.RoomType.Id != _createRoomDto.type)
            {
                
                await _bedspaceRepository.RemoveBedspace(Id);
                await _bedspaceRepository.AddBedspace(room.Type, Id);
               
            }

            await _roomInclusionRepository.RemoveInclusion(Id);
            foreach (var inclusion in _createRoomDto.RoomInclusions)
            {
                await _roomInclusionRepository.CreateInclusion(inclusion, Id);
            }
            foreach (var fileEntry in _createRoomDto.FileEntries)
            {   
                map.AddRoomPic(fileEntry.Id);
            }
            await _roomRepository.SaveChanges();
            return _mapper.Map<RoomDto>(room);

        }
       
    }
}
