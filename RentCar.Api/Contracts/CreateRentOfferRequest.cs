using System.Collections.Generic;
using System.Web;
using RentCar.Api.Models;

namespace RentCar.Api.Contracts
{
    public class CreateRentOfferRequest
    {
        public RentOffer RentOffer { get; set; }
        public List<HttpPostedFileBase> Photos { get; set; }
    }
}