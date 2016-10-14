using DataObject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace simple_mvc_adonet.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult List()
        {
            return View();
        }


        // GET: User
        public ActionResult CreateView()
        {
            return View();
        }

        // GET: User
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }

        // GET: User
        [HttpPost]
        public ActionResult Search(SearchUserConditionModel condition)
        {
            return View();
        }
    }
}