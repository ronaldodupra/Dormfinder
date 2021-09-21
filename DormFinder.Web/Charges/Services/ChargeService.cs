using System;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Charges.Models;
using DormFinder.Web.Entities;
using DormFinder.Web.Services;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DormFinder.Web.Charges.Services
{
    public class ChargeService
    {
        private readonly IChargeRepository _repository;
        private readonly IMapper _mapper;

        public ChargeService(IChargeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActionResult<ChargeDto>> Update(int id, CreateChargeDto chargeDto)
        {
            var charge = await _repository.GetById(id);

            _mapper.Map(chargeDto, charge);

            await _repository.SaveChanges();

            return _mapper.Map<ChargeDto>(charge);
        }

        public async Task<ActionResult<ChargeDto>> Create(CreateChargeDto chargeDto, int orgId)
        {
            var charge = _mapper.Map<Charge>(chargeDto);

            charge.OrganizationId = orgId;

            await _repository.Create(charge);
                       
            return _mapper.Map<ChargeDto>(charge);
        }
    }
}
