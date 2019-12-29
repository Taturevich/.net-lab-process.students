using System.Threading.Tasks;
using System.Web.Mvc;
using EF_Task;

namespace AsyncVsSyncExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;

        public HomeController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpPost]
        public ActionResult Category(int categoryId)
        {
            return RedirectToAction(nameof(Async), categoryId);
        }

        public ActionResult Index()
        {
            var productInfo = _productCategoryService.GetProductInfoForCategory(3);
            return View(productInfo);
        }

        public async Task<ActionResult> Async()
        {
            var productInfo = await _productCategoryService.GetProductInfoForCategoryAsync(3);
            return View(productInfo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
