using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class RoomManager
    {
        //récupère toutes les chambres
        public static List<Room> GetAllRoom()
        {
            return RoomDB.GetAllRoom();
        }

        //Recupre les chambres en fonction des date désirées, de l'emplacement de l'hotel et le nombre de client
        public static List<Room> GetRoomByDate(DateTime checkInDerired, DateTime checkOutDesired, String location,int nbCustomer)
        {
           
            return RoomDB.GetRoomByDate(checkInDerired, checkOutDesired, location, nbCustomer);
            
        }

        //Recupre les chambres en fonction des date désirées, de l'emplacement de l'hotel et le nombre de client et ajoute la recherche avancée
        public static List<Room> GetRoomByDateRequestAdd(DateTime checkInDerired, DateTime checkOutDesired, String location, int nbCustomer, String requestAdd)
        {

            return RoomDB.GetRoomByDateRequestAdd(checkInDerired, checkOutDesired, location, nbCustomer, requestAdd);

        }

        //Récupère une chambre en fonction de son id
        public static Room GetRoomById(int IdRoom)
        {
            return RoomDB.GetRoomById(IdRoom);
        }

        //Récupère une chambre avec son id
        public static int countRoomByIdHotel(int IdHotel, DateTime checkInDesired, DateTime checkOutDesired, String location, int nbCustomer)
        {
            return RoomDB.countRoomByIdHotel( IdHotel,  checkInDesired,  checkOutDesired,  location,  nbCustomer);
        }

        //Récupère les chambres en fonction de l'id de la reservation
        public static List<Room> GetRoomByIdReservation(int IdReservation)
        {
            return RoomDB.GetRoomByIdReservation(IdReservation);
        }

        //Permet un hotel d'ajouter une télévision a une chambre
        public static void ModifiyHasTV(Boolean HasTv, int IdRoomDesired)
        {
            RoomDB.ModifiyHasTV(HasTv, IdRoomDesired);
        }

        //Modifie la requete pour la recherche avancé
        public static String RequestEdit(int hasHairDryer, int hasTv, int hasWifi, int hasParking)
        {
            return RoomDB.RequestEdit( hasHairDryer,  hasTv,  hasWifi,  hasParking);
        }
    }
}
