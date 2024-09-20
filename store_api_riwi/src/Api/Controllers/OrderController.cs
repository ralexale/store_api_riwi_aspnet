using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store_api_riwi.src.Api.DTOs.Request;
using store_api_riwi.src.Api.DTOs.Response;
using store_api_riwi.src.Infrastructure.AbstractServices;

namespace store_api_riwi.src.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private ICommonService<OrderResponse, OrderRequest> _orderService;

        private IValidator<OrderRequest> _orderValidator;

        public OrderController(ICommonService<OrderResponse, OrderRequest> orderService, 
            IValidator<OrderRequest> orderValidator)
        {
            _orderService = orderService;
            _orderValidator = orderValidator;
        }


        [HttpGet]
        public async Task<IEnumerable<OrderResponse>> Get() => await _orderService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> GetById(int id)
        {
            var order = await _orderService.GetById(id);

            return order == null ? NotFound() : Ok(order);
        }


        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Create(OrderRequest orderResquest)
        {
            var validation = await _orderValidator.ValidateAsync(orderResquest);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var orderResponse = await _orderService.Create(orderResquest);

            return CreatedAtAction(nameof(GetById), new { id = orderResponse.Id }, orderResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderResponse>> Update(int id, OrderRequest orderResquest)
        {
            var validation = await _orderValidator.ValidateAsync(orderResquest);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var orderResponse = await _orderService.Update(id, orderResquest);

            return orderResponse == null ? NotFound() : Ok(orderResponse);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderResponse>> Delete(int id)
        {
            var orderResponse = await _orderService.Delete(id);

            return orderResponse == null ? NotFound() : Ok(orderResponse);
        }

    }
}
