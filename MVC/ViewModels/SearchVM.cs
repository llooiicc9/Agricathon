using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels
{
    public class SearchVM
    {
        [Required]
        public string HotelLocation { get; set; }

        [Required]
        public int nbCustomer { get; set; }

        [Required]
        public DateTime CheckInWanted { get; set; }

        [Required]
        public DateTime CheckOutWanted { get; set; }

        public int hasTv { get; set; }
        public int hasHairDryer { get; set; }
        public int hasParking { get; set; }
        public int hasWifi { get; set; }



    }
}