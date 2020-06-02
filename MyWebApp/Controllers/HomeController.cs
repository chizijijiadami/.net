using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using MyWebApp.SqlRepository;
namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Test()
        {
            ViewBag.Title = "Test Page";

            return View();
        }

        public JsonResult Json1()
        {
            return Json(new { status = 0, msg="success",data =new int[5] { 99, 98, 92, 97, 95 } }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MysqlDatabase()
        {
           
            return Json(new {list= UserRepository.GetUsers() }, JsonRequestBehavior.AllowGet);
        }
    
     }

}
