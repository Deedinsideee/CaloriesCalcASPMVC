using WebCalculatorLast.Models;

using Microsoft.AspNetCore.Mvc;

namespace WebCalculatorLast.Controllers
{
    public class MainMenuController : Controller
    {
        private MyDbContext db;

        public MainMenuController(MyDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            Usersa usersa= StaticModelForSomething.userinwork ;
            return View(usersa);
        }
        public IActionResult AllFood()
        {

            var food =db.Foodss.First();


            return View(food);
        }
    }
}
