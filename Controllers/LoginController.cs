using WebCalculatorLast.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebCalculatorLast.Controllers
{
    public class LoginController : Controller
    {
        private MyDbContext db;

        public LoginController(MyDbContext context)
        {
            db=context;
        }
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult CheckIfLogin(Usersa usersa) //проверка на правильный вход
        {
            
            var thisuser=db.Users.Where(p=> p.Login==usersa.Login).Where(p=>p.Password==usersa.Password).FirstOrDefault();
            //var thisuser = from b in db.Users where b.Login==usersa.Login where b.Password == usersa.Password select b;
            if (thisuser == null)
            {
                return View("Index");
            }
            else
            {
                StaticModelForSomething.userinwork = thisuser;
                return RedirectToAction("Index", "MainMenu");
            }
        }



        public IActionResult Registration()
        {
            
            var newuser = new Usersa();

            return View(newuser);
        }

       


        public IActionResult Register(Usersa usersa)
        {
            

            try
            {
                var isexist=db.Users.FirstOrDefault(u => u.Login == usersa.Login);
                if (isexist == null)
                {
                    throw new Exception();
                }
                StaticModelForSomething.isexist = true;
                return RedirectToAction(nameof(DontReg));
            }
            catch
            {
                StaticModelForSomething.isexist = false;
                db.Users.Add(usersa);
                db.SaveChanges();
                return RedirectToAction(nameof(ThanksForRegistration));
            }
            
           
        }

        public IActionResult ThanksForRegistration()
        {
            return View();
        }
        public IActionResult DontReg()
        {
            var newuser = new Usersa();
            return View();
        }
        public IActionResult ReturnToRed()
        {
            var newuser = new Usersa();

            return View(newuser);
        }
    }
}
