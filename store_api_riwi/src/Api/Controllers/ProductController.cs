using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store_api_riwi.src.Api.DTOs.Request;
using store_api_riwi.src.Api.DTOs.Response;
using store_api_riwi.src.Infrastructure.AbstractServices;
using store_api_riwi.src.Infrastructure.Services;

namespace store_api_riwi.src.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ICommonService<ProductResponse, ProductRequest> _productService;

        private IValidator<ProductRequest> _productValidator;

        public ProductController(ICommonService<ProductResponse, ProductRequest> 
            productService, IValidator<ProductRequest> productValidator)
        {
            _productService = productService;
            _productValidator = productValidator;
        }


        [HttpGet]
        public async Task<IEnumerable<ProductResponse>> Get() => await _productService.Get();

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetById(int id)
        {
            var product = await _productService.GetById(id);

            return product == null ? NotFound() : Ok(product);
        }


        [HttpPost]
        public async Task<ActionResult<ProductResponse>> Create(ProductRequest productResquest)
        {
            var validation = await _productValidator.ValidateAsync(productResquest);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var productResponse = await _productService.Create(productResquest);

            return CreatedAtAction(nameof(GetById), new { id = productResponse.Id }, productResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponse>> Update(int id, ProductRequest productResquest)
        {
            var validation = await _productValidator.ValidateAsync(productResquest);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var productResponse = await _productService.Update(id, productResquest);

            return productResponse == null ? NotFound() : Ok(productResponse);
        }


        [HttpDelete]
        public async Task<ActionResult<ProductResponse>> Delete(int id)
        {
            var productResponse = await _productService.Delete(id);

            return productResponse == null ? NotFound() : Ok(productResponse);
        }


    }
}
