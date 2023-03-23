using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppWithSqlDB.Models;
using WebAppWithSqlDB.Services;

namespace WebAppWithSqlDB.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Product> Products;

        public void OnGet()
        {
            var productService = new ProductService();
            Products = productService.GetProducts();
        }
    }
}