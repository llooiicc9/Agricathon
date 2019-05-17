using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Picture
    {
        //Déclare les champs présents sur la base de donnée
        public int IdPicture { get; set; }
        public String Url { get; set; }
        public int IdRoom { get; set; }

        public override string ToString()
        {
            //Renvoie en String tous les champs
            return
                " IdPicture: " + IdPicture.ToString() +
                " Url: " + Url +
                " IdRoom: " + IdRoom.ToString();
        }
    }
}
