using aspfromscratch;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace aspwebapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public RandomNumberService Rns { get; set; }

        public IndexModel(ILogger<IndexModel> logger, RandomNumberService rns)
        {
            _logger = logger;
            Rns = rns;
        }

        public void OnGet()
        {

        }
    }
}
