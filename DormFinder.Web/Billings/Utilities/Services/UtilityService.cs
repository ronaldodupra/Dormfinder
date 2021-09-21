using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Billings.Utilities.Model;
using DormFinder.Web.Core.Paging;
using DormFinder.Web.Entities;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DormFinder.Web.Billings.Utilities.Services
{
    public class UtilityService
    {
        private readonly IUtilityRepository _utilityRepository;
        private readonly IMapper _mapper;
        public UtilityService(IUtilityRepository utilityRepository,
            IMapper mapper)
        {
            _utilityRepository = utilityRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedList<UtilityReadingDto>> GetUtilitiesReadingsCurrAndPrevMonth(PageOptions options, int orgId, int utilityType)
        {
            var utilities = await _utilityRepository.GetUtilities(options, orgId, utilityType);

            List<UtilityReadingDto> utilitiesDto = new List<UtilityReadingDto>();

            foreach(var utility in utilities.Items)
            {
                var currentAndPreviousMonth = await _utilityRepository.GetReadingsCurrAndPrevMonth(utility.Id);

                utilitiesDto.Add(new UtilityReadingDto()
                {
                    Id = currentAndPreviousMonth.Where(x => x.CreatedAt.Month == DateTime.Now.Month).Select(x => x.Id).FirstOrDefault(),
                    MeterNumber = utility.MeterNumber,
                    UtilityId = utility.Id,
                    PreviousReading = currentAndPreviousMonth.Where(x => x.CreatedAt.Month != DateTime.Now.Month).Select(x => x.Reading).FirstOrDefault(),
                    CurrentReading = currentAndPreviousMonth.Where(x => x.CreatedAt.Month == DateTime.Now.Month).Select(x => x.Reading).FirstOrDefault()
                });
            }

            return new PaginatedList<UtilityReadingDto>(utilitiesDto, utilities.TotalCount);
        }

        public async Task SaveChanges(int orgId, IEnumerable<UtilityReadingDto> readingDto)
        {
            var newReading = readingDto.Where(x => x.Id == 0).Select(x => new UtilityReading
            {
                OrganizationId = orgId,
                UtilityId = x.UtilityId,
                Reading = x.CurrentReading.Value,
            });

            foreach (var reading in newReading)
            {
                await _utilityRepository.CreateReading(reading);
            }

            var updateReading = readingDto.Where(x => x.Id > 0).Select(x => new UtilityReading
            {
                UtilityId = x.UtilityId,
                Reading = x.CurrentReading.Value,
                Id = x.Id.Value,
                OrganizationId = orgId,
            });

            foreach (var reading in updateReading)
            {
                await _utilityRepository.UpdateReading(reading);
            }
        }

    }
}
