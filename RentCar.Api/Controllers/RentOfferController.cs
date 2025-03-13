using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RentCar.Api.Contracts;
using RentCar.Api.Models;

namespace RentCar.Api.Controllers
{
    public class RentOfferController : Controller
    {
        private static readonly List<RentOffer> RentOffers = new List<RentOffer>()
        {
            new RentOffer
            {
                Id = 1,
                CarName = "Ford Mustang",
                CarYear = 2021,
                FuelType = FuelType.Benzine, // Assuming FuelType is an enum
                GearBoxType = GearBoxType.Automatic, // Assuming GearBoxType is an enum
                Horsepower = 450,
                Price = 299.99m,
                PhotoPaths = new[] { "dsgash", "/images/mustang2.jpg" }
            }
        };

        // GET: RentOffer
        public ActionResult Index()
        {
            return View(RentOffers);
        }

        // GET: RentOffer/Details/5
        public ActionResult Details(int id)
        {
            // Hardcoded example RentOffer for the static page
            var rentOffer = RentOffers[0];

            return View(rentOffer);
        }

        // GET: RentOffer/Create
        public ActionResult Create()
        {
            ViewBag.FuelTypes = Enum.GetValues(typeof(FuelType)).Cast<FuelType>();
            ViewBag.GearBoxTypes = Enum.GetValues(typeof(GearBoxType)).Cast<GearBoxType>();
            return View();
        }

        // POST: RentOffer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RentOffer rentOffer)
        {
            if (ModelState.IsValid)
            {
                rentOffer.Id = RentOffers.Count + 1; // Simulate auto-increment
                RentOffers.Add(rentOffer);
                return RedirectToAction("Index");
            }

            ViewBag.FuelTypes = Enum.GetValues(typeof(FuelType)).Cast<FuelType>();
            ViewBag.GearBoxTypes = Enum.GetValues(typeof(GearBoxType)).Cast<GearBoxType>();

            var result = new CreateRentOfferRequest
            {
                RentOffer = rentOffer
            };
            return View(result);
        }

        // GET: RentOffer/Edit/5
        public ActionResult Edit(int id)
        {
            var rentOffer = RentOffers.FirstOrDefault(r => r.Id == id);
            if (rentOffer == null)
            {
                return HttpNotFound();
            }

            ViewBag.FuelTypes = Enum.GetValues(typeof(FuelType)).Cast<FuelType>();
            ViewBag.GearBoxTypes = Enum.GetValues(typeof(GearBoxType)).Cast<GearBoxType>();
            return View(rentOffer);
        }

        // POST: RentOffer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RentOffer rentOffer)
        {
            if (ModelState.IsValid)
            {
                var existingOffer = RentOffers.FirstOrDefault(r => r.Id == rentOffer.Id);
                if (existingOffer != null)
                {
                    existingOffer.CarName = rentOffer.CarName;
                    existingOffer.CarYear = rentOffer.CarYear;
                    existingOffer.FuelType = rentOffer.FuelType;
                    existingOffer.GearBoxType = rentOffer.GearBoxType;
                    existingOffer.Horsepower = rentOffer.Horsepower;
                }

                return RedirectToAction("Index");
            }

            ViewBag.FuelTypes = Enum.GetValues(typeof(FuelType)).Cast<FuelType>();
            ViewBag.GearBoxTypes = Enum.GetValues(typeof(GearBoxType)).Cast<GearBoxType>();
            return View(rentOffer);
        }

        // GET: RentOffer/Delete/5
        public ActionResult Delete(int id)
        {
            var rentOffer = RentOffers.FirstOrDefault(r => r.Id == id);
            if (rentOffer == null)
            {
                return HttpNotFound();
            }

            return View(rentOffer);
        }

        // POST: RentOffer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var rentOffer = RentOffers.FirstOrDefault(r => r.Id == id);
            if (rentOffer != null)
            {
                RentOffers.Remove(rentOffer);
            }

            return RedirectToAction("Index");
        }
    }
}