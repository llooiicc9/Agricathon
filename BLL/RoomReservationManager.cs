using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
   public class RoomReservationManager
    {
        //Récupère toutes les roomReservations
        public static List<RoomReservation> GetAllRoomReservation()
        {
            return RoomReservationDB.GetAllRoomReservation();
        }

        //récupère une roomReservation en fonction de l'id de la chambre et de la réservation
        public static RoomReservation GetRoomReservationByIdRoomIdReservation(int idRoom, int idReservation)
        {
            return RoomReservationDB.GetRoomReservationByIdRoomIdReservation(idRoom, idReservation);
        }

        //Ajoute une nouvelle réservation
        public static void NewRoomReservation(int IdReservation, int IdRoom, int PriceIncreased)
        {
            RoomReservationDB.NewRoomReservation(IdReservation , IdRoom, PriceIncreased);
        }

        //SUpprime une réservation en fonction d'un id
        public static void DeleteReservationRoom(int IdReservation)
        {
            RoomReservationDB.DeleteReservationRoom(IdReservation);
            ReservationDB.DeleteReservation(IdReservation);
        }
    }
}
