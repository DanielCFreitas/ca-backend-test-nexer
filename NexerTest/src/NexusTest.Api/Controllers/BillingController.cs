using Microsoft.AspNetCore.Mvc;
using NexerTest.Api.DTO.Request;
using NexerTest.Api.Services.Interfaces;
using NexerTest.SharedKernel.Api;

namespace NexerTest.Api.Controllers
{
    [Route("/[controller]")]
    public class BillingController : BaseController
    {
        private readonly IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var billings = await _billingService.BillingsList();
            return BaseResponse(billings);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddBillingRequest request)
        {
            var validationResult = await _billingService.AddBilling(request);
            return BaseResponse(validationResult);
        }
    }
}
