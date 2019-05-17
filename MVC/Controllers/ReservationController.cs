using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.ViewModels;
using DTO;
using BLL;

namespace MVC.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }

        //Confirme la réservation d'une chambre, si c'est une réservation de groupe ca permet de réserver d'autre chambres
        [HttpPost]
        public ActionResult ReservationConfirmation(String firstName, String lastName, int IdRoom)
        {
            if ((int)Session["idReservation"] != 0)
            {
                RoomReservationManager.NewRoomReservation((int)Session["idReservation"], IdRoom, (int)Session["priceIncrease"]);
            }
            else
            {
                int idReservation = ReservationManager.NewReservation(lastName, firstName, (DateTime)Session["CheckInWanted"], (DateTime)Session["CheckOutWanted"], IdRoom, (int)Session["priceIncrease"]);
                Session["idReservation"] = idReservation;
            }


            //Enlève le nombre de client de la variable nbCustomer ce qui permet de savoir si il reste des chambres a réserver
            var RoomSelected = RoomManager.GetRoomById(IdRoom);
            int nbCustomerInRoom = RoomSelected.Type;
            Session["nbCustomer"] = (int)Session["nbCustomer"] - nbCustomerInRoom;


            ViewBag.Message = "Your room is booked ! with the number " + Session["idReservation"];


            return View();
        }

        //Donne les informations pour une réservation et permet de la supprimer
        [HttpPost]
        public ActionResult ReservationInformation(InfoReservationVM infoReservation)
        {
            var information = ReservationManager.GetReservationByIdName(infoReservation.idReservation, infoReservation.firstName, infoReservation.LastName);
            var infoRooms = RoomManager.GetRoomByIdReservation(infoReservation.idReservation);

            if (information != null)
            {
                ViewBag.Message = "Reservation informations :";
                infoReservation.nbCustomerTotal = 0;
                List<Hotel> infoHotel = new List<Hotel>();
                foreach (var room in infoRooms)
                {
                    infoHotel.Add(HotelManager.GetHotelById(room.IdHotel));
                    infoReservation.nbCustomerTotal += room.Type;

                    //Si pendant la réservation le prix était de 20% en plus on applique cela maintenant
                    var infoRoomRes = RoomReservationManager.GetRoomReservationByIdRoomIdReservation(room.IdRoom, infoReservation.idReservation);
                    double price = (double)room.Price;

                    if (infoRoomRes.PriceIncreased != 0)
                    {
                        price = price + (price * 0.2);
                    }

                    room.Price = (decimal)price;
                }

                infoReservation.listRooms = infoRooms;
                infoReservation.reservation = information;
                infoReservation.listHotels = infoHotel;

                return View(infoReservation);
            }

            ViewBag.Message = "No reservation founded ";
            return RedirectToAction("Index", "Reservation");
        }

        //Confirme l'annulation d'une réservation
        [HttpPost]
        public ActionResult ReservationCancel(int idReservation)
        {
            ViewBag.Message = "The reservation has been canceled";

            RoomReservationManager.DeleteReservationRoom(idReservation);

            return View();
        }
    }
}