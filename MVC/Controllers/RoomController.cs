using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.ViewModels;
using BLL;

namespace MVC.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Index(int IdRoom)
        {
            OneRoomVM RoomSelected = new OneRoomVM();

            var InfoRoom = RoomManager.GetRoomById(IdRoom);
            if (InfoRoom != null)
            {
                
                RoomSelected.room = InfoRoom;
                RoomSelected.hotel = HotelManager.GetHotelById(InfoRoom.IdHotel);
                RoomSelected.picture = PictureManager.getAllPictureByIdroom(IdRoom);

                int priceIncrease = RoomManager.countRoomByIdHotel(InfoRoom.IdHotel, (DateTime)Session["CheckInWanted"], (DateTime)Session["CheckOutWanted"], (String)Session["LocationHotel"], (int)Session["nbCustomer"]);
                double price = (double)InfoRoom.Price;

                if (priceIncrease.Equals(1))
                {
                    price = price + (price * 0.2);
                }
                Session["priceIncrease"] = priceIncrease;

                RoomSelected.room.Price = (decimal)price;

                return View(RoomSelected);
            }

            return RedirectToAction("Index", "Home");
 
        }

    }
}