using System.Collections.Generic;
using System.Web.Mvc;
using RentCar.Api.Models;

namespace RentCar.Api.Controllers
{
    public class RentController : Controller
    {
        // public ActionResult Index()
        // {
        //     return View();
        // }
        //
        // public ActionResult Rent()
        // {
        //     return View();
        // }

        [HttpGet, Route("rents")]
        public ActionResult AdminGetAllRentTypes()
        {
            var rents = new List<RentType>
            {
                new RentType
                {
                    Id = 1,
                    Name = "Sedan"
                },
                new RentType
                {
                    Id = 2,
                    Name = "SUV"
                }
            };
            return View(rents);
        }
        
        [HttpGet, Route("create-rent")]
        public ActionResult AdminCreateRentType()
        {
            return View();
        }
        
        
        [HttpPost, Route("create-rent")]
        public ActionResult AdminCreateRentType(string name)
        {
            return View();
        }
        
        [HttpGet, Route("edit-rent")]
        public ActionResult AdminEditRentType(int id)
        {
            RentType rentType = new RentType()
            {
                Id = id,
                Name = "Test Rent Name"
            };
            
            return View(rentType);
        }
        
        [HttpPut, Route("edit-rent")]
        public ActionResult AdminEditRentType(int id, string name)
        {
            return RedirectToAction("AdminGetAllRentTypes");
        }
        
        [HttpGet, Route("delete-rent")]
        public ActionResult AdminDeleteRentType(int? id)
        {
            RentType rentType = new RentType()
            {
                Id = (int)id,
                Name = "Test Rent Name"
            };
            return View(rentType);
        }
        
        [HttpDelete, Route("delete-rent")]
        public ActionResult AdminDeleteRentType(int id)
        {
            return RedirectToAction("AdminGetAllRentTypes");
        }
    }
}