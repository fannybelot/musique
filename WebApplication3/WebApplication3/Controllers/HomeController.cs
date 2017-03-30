using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using WebApplication3.App_Start;

namespace WebApplication3.Controllers
{
    [CustomError]
    [CustomActionFilter]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            /*try
            {
                int div = 0;
                var result = 10 / div;
            }
            catch (DivideByZeroException)
            {
                ViewBag.errorMessage = "Division par 0 non autorisée";
                return View("Error");
            }
            catch (SecurityException)
            {
                ViewBag.errorMessage = "Erreur de sécurité";
                return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                return View("Error");
            }
            finally
            {
                var toto = 3;
            }*/
            //if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["customKey"]))
            //{
            //    var key = ConfigurationManager.AppSettings["customKey"]; //web.config
            //}
            //int div = 0;
            //var result = 10 / div;
            return View();
        }

        public ActionResult Error()
        {
            return View("Error");
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