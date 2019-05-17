using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Parcelle
    {
        //Déclare les champs présents sur la base de donnée
        public int IdPasserelle { get; set; }
        public int Numero { get; set; }
        public string Nom { get; set; }
        public double Surface { get; set; }
        public int IdFauche { get; set; }



    }
}
