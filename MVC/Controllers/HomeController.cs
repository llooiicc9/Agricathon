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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Au début on mets a 0 la variable session idReservation
            Session["idReservation"] = 0;
            return View();
        }

        public ActionResult Parcelle(int IdParcelle)
        {
            //ViewBag.Message = "You have to chose dates for your reservation !";
            return View();
        }

        //Si on ne choisi pas de chambre cela nous renvoie vers la page de base
        public ActionResult ListHotel()
        {
            ViewBag.Message = "You have to chose dates for your reservation !";
            return RedirectToAction("Index", "Home");
        }

        //Affiche un hotel par rapport a un idHotel
        [HttpGet]
        public ActionResult Hotel(int IdHotel)
        {
            var infoHotel = HotelManager.GetHotelById(IdHotel);

            return View(infoHotel);
        }

        //Affiche la liste des chambres disponibles en fonction des hotels 
        [HttpPost]
        public ActionResult ListHotel(SearchVM SearchVM)
        {
            //Déclaration des variables de bases
            Session["nbCustomer"] = SearchVM.nbCustomer;
            Boolean customRequest = false;
            string requestAdd = " ";

            //Recherche avancée basé sur les hotels et les chambres
            if (SearchVM.hasHairDryer!=0 || SearchVM.hasTv != 0 || SearchVM.hasWifi != 0 || SearchVM.hasParking != 0)
            {
                customRequest = true;
                requestAdd = RoomManager.RequestEdit(SearchVM.hasHairDryer, SearchVM.hasTv, SearchVM.hasWifi, SearchVM.hasParking);
            }
    
            //gère les réservation groupées
            if (SearchVM.nbCustomer<=2)
            {
                //Si il y a des recherche avancée on les effectues
                List<DTO.Room> listRoomFree = new List <DTO.Room>();
                if (customRequest)
                {

                    listRoomFree = RoomManager.GetRoomByDateRequestAdd(SearchVM.CheckInWanted, SearchVM.CheckOutWanted, SearchVM.HotelLocation, SearchVM.nbCustomer, requestAdd);
                }
                else
                {
                    listRoomFree = RoomManager.GetRoomByDate(SearchVM.CheckInWanted, SearchVM.CheckOutWanted, SearchVM.HotelLocation, SearchVM.nbCustomer);
                }

                //Enregistre les informations dans les variables Sessions et on retourne les chambres libres
                if (listRoomFree != null)
                {
                    ViewBag.Message = "Here is the list of available room for "+ SearchVM.nbCustomer + " Customer(s)";

                    Session["CheckInWanted"] = SearchVM.CheckInWanted;
                    Session["CheckOutWanted"] = SearchVM.CheckOutWanted;
                    Session["LocationHotel"] = SearchVM.HotelLocation;

                    TimeSpan Diff = SearchVM.CheckOutWanted - SearchVM.CheckInWanted;
                    Session["NbDay"] = (int)Diff.TotalDays;

                    return View(listRoomFree);
                }
            }
            else
            {
                //Gère les réservations groupées
                int nbCustomerTemps;
                if ((int)Session["nbCustomer"] > 2)
                    nbCustomerTemps = 1;
                else
                    nbCustomerTemps = (int)Session["nbCustomer"];

                //Si il y a des recherche avancée on les effectues
                List<DTO.Room> listRoomFree = new List<DTO.Room>();
                if (customRequest)
                {
                    listRoomFree = RoomManager.GetRoomByDateRequestAdd(SearchVM.CheckInWanted, SearchVM.CheckOutWanted, SearchVM.HotelLocation, nbCustomerTemps, requestAdd);
                }
                else
                {
                    listRoomFree = RoomManager.GetRoomByDate(SearchVM.CheckInWanted, SearchVM.CheckOutWanted, SearchVM.HotelLocation, nbCustomerTemps);
                }
                
                //Enregistre les informations dans les variables Sessions et on retourne les chambres libres
                if (listRoomFree != null)
                {
                    ViewBag.Message = "Choose a room for 1 or 2 customers ( " + SearchVM.nbCustomer + " remaining Customer(s) )";

                    Session["CheckInWanted"] = SearchVM.CheckInWanted;
                    Session["CheckOutWanted"] = SearchVM.CheckOutWanted;
                    Session["LocationHotel"] = SearchVM.HotelLocation;

                    TimeSpan Diff = SearchVM.CheckOutWanted - SearchVM.CheckInWanted;
                    Session["NbDay"] = (int)Diff.TotalDays;

                    return View(listRoomFree);
                }
            }

            //Si il n'y a pas de chambre libre on retourne a la page de base
            ViewBag.Message = "No hotel meets your expectations";
            return RedirectToAction("Index", "Home");
        }
    }
}