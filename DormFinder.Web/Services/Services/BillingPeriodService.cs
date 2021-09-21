using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DormFinder.Web.Entities;
using DormFinder.Web.Models;
using DormFinder.Web.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DormFinder.Web.Services.Services
{
    public class BillingPeriodService
    {
        private readonly IMapper _mapper;
        private readonly IBillingPeriodRepository _billingPeriodRepository;
        public BillingPeriodService(IMapper mapper, IBillingPeriodRepository billingPeriodRepository)
        {
            _mapper = mapper;
            _billingPeriodRepository = billingPeriodRepository;
        }
        public async Task<ActionResult<BillingPeriodDto>> Create(CreateBillingPeriodDto createBillingPeriod,int orgId)
        {
            var billingPeriod = _mapper.Map<BillingPeriod>(createBillingPeriod);
            billingPeriod.OrganizationId = orgId;
            await _billingPeriodRepository.Create(billingPeriod);

            return _mapper.Map<BillingPeriodDto>(billingPeriod);
        }
        public async Task<ActionResult<BillingPeriodDto>> Update(CreateBillingPeriodDto createBillingPeriod, int orgId, int billingPeriodId)
        {
            var billingPeriod = await _billingPeriodRepository.GetById(billingPeriodId);
            _mapper.Map(createBillingPeriod, billingPeriod);
            await _billingPeriodRepository.SaveChanges();

            return _mapper.Map<BillingPeriodDto>(billingPeriod);
        }
    }
}
