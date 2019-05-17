using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class HotelManager
    {
        //Récupère tous les hotels dans une liste
        public static List<Hotel> GetAllHotel()
        {
            return HotelDB.GetAllHotel();
        }
        
        //Récupère un hotel selon son id
        public static Hotel GetHotelById(int idHotelDesired)
        {
            return HotelDB.GetHotelById(idHotelDesired);
        }
    }
}
