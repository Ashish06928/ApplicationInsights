using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DemoApp.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public DemoApp.Models.Registration RegistrationUser { get; set; }
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public RegistrationModel(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            try
            {
                _logger.LogInformation("Registration process has been started.");
                var json = JsonConvert.SerializeObject(RegistrationUser);
                var client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                string path = $"{_configuration["AppSettings:BaseAPI"]}api/Registration";
                var res = client.PostAsync(path, content).GetAwaiter().GetResult();
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    return RedirectToPage("Registration");
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
