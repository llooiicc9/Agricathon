using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class PictureManager
    {
        //selectionne toutes les photos 
        public static List<Picture> getAllPicture()
        {
            return PictureDB.getAllPicture();
        }

        //recupère toutes les photos en fonction de l'id d'une chambre
        public static List<Picture> getAllPictureByIdroom(int idRoom)
        {
            return PictureDB.getAllPictureByIdroom(idRoom);
        }

        //recupère qu'une chambre en fonction de l'id de la chambre
        public static Picture getOnePictureByIdroom(int idRoom)
        {
            return PictureDB.getOnePictureByIdroom(idRoom);
        }

    }
}
