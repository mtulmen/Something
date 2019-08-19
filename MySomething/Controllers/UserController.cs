using DataAccessLayer;
using MySomething.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace MySomething.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UserRepository rep = new UserRepository();
            List<Users> list = rep.List();
            string serializedStr = JsonConvert.SerializeObject(list);
            List<UserViewModel> result = JsonConvert.DeserializeObject<List<UserViewModel>>(serializedStr);
            
            return View(result);
        }

        public ActionResult AddUser(int id)
        {
            UserRepository rep = new UserRepository();
            Users userDataModel = new Users();
            
            UserViewModel model = new UserViewModel();
            if(id >0 )
            {
                userDataModel = rep.List(id);
                string serializedStr = JsonConvert.SerializeObject(userDataModel);
                model = JsonConvert.DeserializeObject<UserViewModel>(serializedStr);
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel user)
        {

            if (!ModelState.IsValid)
            {
                return View(user);
            }
            UserRepository rep = new UserRepository();

            Users userDataModel = new Users();
            string serializedStr = JsonConvert.SerializeObject(user);
            userDataModel = JsonConvert.DeserializeObject<Users>(serializedStr); //json dönüştürüp gönderdik.
            
            rep.Add(userDataModel);
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(int Id)
        {
            UserRepository rep = new UserRepository();
            rep.Delete(Id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(UserViewModel user)
        {
            return RedirectToAction("AddUser",user);
        }
    }
}