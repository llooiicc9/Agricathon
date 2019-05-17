using BLL;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Python_projet_booking
{
    class Program
    {
        static void Main(string[] args)
        {

            //DateTime date1 = new DateTime(2018, 11, 20);
            //DateTime date2 = new DateTime(2018, 11, 24);
            //List<int> rooms =  new List<int>();
            //rooms.Add(4);

            //Console.WriteLine(RoomDB.GetRoomByDate(date1, date2));
            // Console.WriteLine(RoomDB.GetAllRoom());
             List<Picture> visits = PictureDB.getAllPictureByIdroom(2);
            for (int i = 0; i < visits.Count; i++)
                Console.WriteLine(visits[i]);
            // GetRoomByDate(DateTime checkInDerired, DateTime checkOutDesired);
           /* Room test = RoomDB.GetRoomById(1);

            Console.WriteLine(test.Price);
            Console.Read();*/
            //RoomDB.ModifiyHasTV(false, 1);
        }
    }
}
