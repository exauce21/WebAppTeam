using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPWebGroupe.Models
{
    public class ProduitReport
    {
        public string Designation { get; set; }

        public int PU { get; set; }

        public double QteStock { get; set; }

        public double QteMin { get; set; }

        public DateTime DatePeremption { get; set; }

        public int idCategorie { get; set; }
    }
}