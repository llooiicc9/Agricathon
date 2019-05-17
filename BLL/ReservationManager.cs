using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ReservationManager
    {
        //recupère toutes les réservations
        public static List<Reservation> GetAllReservation()
        {
            return ReservationDB.GetAllReservation();
        }

        //recupère une réservation en fonction du nom, de l'id de la reservation et du prenom
        public static Reservation GetReservationByIdName(int idReservation, String FirstName, String LastName)
        {
            return ReservationDB.GetReservationByIdName(idReservation, FirstName, LastName);
        }

        //crée une nouvelle reservation 
        public static int NewReservation(String NameClient, String FirstNameClient, DateTime CheckIn, DateTime CheckOut, int idRoom, int PriceIncreased)
        {
            int IdReservation = ReservationDB.NewReservation(NameClient, FirstNameClient, CheckIn, CheckOut);

            RoomReservationManager.NewRoomReservation(IdReservation, idRoom, PriceIncreased);

            return IdReservation;

        }
    }
}
