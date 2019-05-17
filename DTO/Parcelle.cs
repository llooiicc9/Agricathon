using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class Parcelle
    {
        //Déclare les champs présents sur la base de donnée
        public int IdParcelle { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Surface { get; set; }
    }
}
