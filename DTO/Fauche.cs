using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Fauche
    {
        public int IdFauche { get; set; }
        public DateTime Date { get; set; }
        public double HeuresTravail { get; set; }
        public double HeuresMachines { get; set; }
        public int IdEpandage { get; set; }
        public int IdEmploye { get; set; }

    }
}
