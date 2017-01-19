using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using System.Globalization;
using System.Text;
using System.IO;
using System.Threading;
using TestTask.Models;
using System.Data.Entity;
namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.Country = new SelectList(GetListWithCountries(), "Украина");
            ViewBag.Language = new SelectList(new string[] { "English", "Русский" }, 2);
            ViewBag.CountOfUsers = new SelectList(new string[] {
            "1 пользователь",
            "Пользователей: 2–4",
            "Пользователей: 5-9",
            "Пользователей: 10-24",
            "Пользователей: 25-49",
            "Пользователей: 50-249",
            "Пользователей: 250-999",
            "Пользователей: больше 1000"});
            UserModel model = new UserModel() { Login = "pas" };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Models.UserModel model)
        {

            if (ModelState.IsValid)
            {
                model.Login = "";
                model.CompanyName = "";
                model.Password = "";
                model.ConfirmPassword = "";
                return View("SecondPage", model);
            }
            ViewBag.Country = new SelectList(GetListWithCountries(), "Украина");
            ViewBag.Language = new string[] { "English", "Русский" };
            ViewBag.CountOfUsers = new string[] {
            "1 пользователь",
            "Пользователей: 2–4",
            "Пользователей: 5-9",
            "Пользователей: 10-24",
            "Пользователей: 25-49",
            "Пользователей: 50-249",
            "Пользователей: 250-999",
            "Пользователей: больше 1000"};

            return View();
        }

        public ActionResult SecondPage()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SecondPage(UserModel model)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<UserContext>());
            using (UserContext context = new UserContext())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }

            return View("Success");
        }

        public ActionResult Success()
        {
            return View();
        }

        private List<string> GetListWithCountries()
        {
            List<string> cultureList = new List<string>();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ru-RU");
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
            foreach (CultureInfo culture in cultures)
            {
                try
                {
                    RegionInfo region = new RegionInfo(culture.LCID);

                    if (!(cultureList.Contains(region.DisplayName)))
                    {
                        cultureList.Add(region.DisplayName);
                    }
                }
                catch (ArgumentException ex)
                {
                    continue;
                }
            }
            cultureList.Sort();

            return cultureList;

        }

        
    }
}