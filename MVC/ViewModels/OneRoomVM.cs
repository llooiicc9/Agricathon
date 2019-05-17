using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;

namespace MVC.ViewModels
{
    public class OneRoomVM
    {
        public Room room { get; set; }
        public List<Picture> picture { get; set; }
        public Hotel hotel { get; set; }
    }
}