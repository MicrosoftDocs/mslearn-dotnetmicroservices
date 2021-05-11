using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace frontend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public PizzaInfo[] Pizzas { get; set; }

        public string ErrorMessage {get;set;}
        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet([FromServices]PizzaClient client)
        {
            Pizzas = await client.GetPizzasAsync();
            
            if(Pizzas.Count()==0)
                ErrorMessage="We must be sold out. Try again tomorrow.";
            else
                ErrorMessage = string.Empty;
        }
    }
}
