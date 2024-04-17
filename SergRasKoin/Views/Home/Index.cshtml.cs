using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace SergRasKoin.Views.Home
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Здесь может быть логика для обработки GET-запроса, если требуется
            return Page(); // Возвращаем страницу Index.cshtml
        }
    }
}
