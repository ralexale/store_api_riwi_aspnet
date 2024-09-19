using FluentValidation;
using store_api_riwi.src.Api.DTOs.Request;

namespace store_api_riwi.src.Api.Validators.Request
{
    public class OrderValidatorRequest : AbstractValidator<OrderRequest>
    {
        public OrderValidatorRequest()
        {
            RuleFor(o => o.UserId).NotNull();
            RuleFor(o => o.UserId).GreaterThan(0);

            RuleFor(o => o.ProductId).NotNull();
            RuleFor(o => o.ProductId).GreaterThan(0);
        }
    }
}
