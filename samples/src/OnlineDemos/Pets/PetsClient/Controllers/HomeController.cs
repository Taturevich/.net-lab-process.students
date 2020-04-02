using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PetsClient.ServiceReference1;

namespace PetsClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetService _petService;

        public HomeController(IPetService petService)
        {
            _petService = petService;
        }

        public async Task<ActionResult> Index()
        {
            var client = new PetServiceClient();
            client.ClientCredentials.UserName.UserName = "Fsjkdhbfksdb;fsdf'";
            var result = await client.GetPetsAsync();
            var pets = await _petService.GetPetsAsync();
            return Content(string.Join(" ", pets.Select(x => x.Name + " " + x.Type)));
        }

        public async Task<ActionResult> About()
        {
            var pets = await _petService.GetPetsAsync();
            return Content(string.Join(" ", pets.Select(x => x.Name + " " + x.Type)));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}