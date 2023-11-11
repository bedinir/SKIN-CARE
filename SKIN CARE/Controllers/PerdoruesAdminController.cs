//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;

//namespace SKIN_CARE.Controllers
//{
//    [Authorize(Roles = "Admin")]
//    public class PerdoruesAdminController : Controller
//    {
//        public PerdoruesAdminController() { }

//        public PerdoruesAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
//        {
//            RoleManager = roleManager;
//        }
//        UserManager = userManager;

//        private ApplicationUserManager _userManager;
//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ??
//                HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }
//        private ApplicationRoleManager _roleManager;
//        public ApplicationRoleManager RoleManager
//        {
//            get
//            {
//                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
//            }
//            private set
//            {
//                _roleManager = value;
//            }
//        }

//        // GET: PerdoruesAdmin
//        public ActionResult Index()
//        {
//            return View();
//        }

//        // GET: PerdoruesAdmin/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: PerdoruesAdmin/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: PerdoruesAdmin/Create
//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: PerdoruesAdmin/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: PerdoruesAdmin/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: PerdoruesAdmin/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: PerdoruesAdmin/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
