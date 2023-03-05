using FilterExample.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterExample.API.Filters
{
    public class ProductIDfilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            List<Product> product = ProductUret.ProductUrets();
            var parameter = context.ActionArguments.Values.FirstOrDefault(); //parametredekileri teker teker döndürür Ienum şekilde
            if (parameter == null)
            {
                next(); //next diyerek api'tarafında geçiyoruz
            }
            var productkontrol = product.Any(p => p.ID == (int)parameter);

            if (!productkontrol)
            {
                context.Result = new NotFoundObjectResult(DTos<NoContentDTO>.Fail(204,"veri yok"));
                return;
            }
            else
            {
                next.Invoke();  //next diyerek api'tarafında geçiyoruz

            }
            
        }
    }
}
