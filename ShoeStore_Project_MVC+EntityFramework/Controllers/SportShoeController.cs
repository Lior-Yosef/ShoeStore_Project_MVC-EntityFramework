using ShoeStore_Project_MVC_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore_Project_MVC_EntityFramework.Controllers
{
    public class SportShoeController : Controller
    {
        public SportShoe[] ShoesArray = new SportShoe[]
        {
            new SportShoe(1,"nike","airFors",45,670),
            new SportShoe(2,"adidas","boost",45,350),
            new SportShoe(3,"Puma","Victorylmp",45,800),
            new SportShoe(4,"Rebook","Classic",45,100)
        };

        // GET: SportShoe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetNameModel()
        {
            return View(ShoesArray[0]);

        }
        public ActionResult GetshoeSport(int id)
        {
            foreach (SportShoe item in ShoesArray)
            {
                if (item.Id == id)
                {
                    return View(item);

                }
                
            }
            return View("not found");
        }
        public ActionResult GetshoesSport()
        {
            return View(ShoesArray);

        }

    }
}