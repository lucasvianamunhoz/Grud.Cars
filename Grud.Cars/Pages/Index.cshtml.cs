using Grud.Cars.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Grud.Cars.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICarService _carService ;
        public IndexModel(ILogger<IndexModel> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        public void OnGet()
        {
            ViewData["Cars"] = _carService.GetAll();

        }
    }
}