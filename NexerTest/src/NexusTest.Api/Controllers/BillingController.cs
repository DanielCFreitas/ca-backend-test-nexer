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

        /// <summary>
        /// Returns list of billings
        /// </summary>
        /// <returns>List of billings</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var billings = await _billingService.BillingsList();
            return BaseResponse(billings);
        }

        /// <summary>
        /// Add a new billing
        /// </summary>
        /// <returns></returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddBillingRequest request)
        {
            var validationResult = await _billingService.AddBilling(request);
            return BaseResponse(validationResult);
        }
    }
}
