using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DTO;

namespace MVC.ViewModels
{
    public class InfoReservationVM
    {
        [Required]
        public int idReservation { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Reservation reservation { get; set; }

        public RoomReservation roomReservation { get; set; }

        public List<Room> listRooms { get; set; }
        public List<Hotel> listHotels { get; set; }

        public int nbCustomerTotal { get; set; }
    }
}