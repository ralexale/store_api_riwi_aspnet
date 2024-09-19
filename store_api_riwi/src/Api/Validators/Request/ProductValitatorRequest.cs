using FluentValidation;
using store_api_riwi.src.Api.DTOs.Request;

namespace store_api_riwi.src.Api.Validators.Request
{
    public class ProductValitatorRequest: AbstractValidator<ProductRequest>
    {

        public ProductValitatorRequest()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).Length(2, 30);

            RuleFor(p => p.Description).Length(2, 100);
            RuleFor(p => p.Description).NotEmpty();

            RuleFor(p => p.Price).Null();
            RuleFor(p=> p.Price).GreaterThan(0);
        }
    }
}
