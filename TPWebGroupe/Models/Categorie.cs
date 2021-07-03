using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPWebGroupe.Models
{
    public class Categorie
    {
        [Key]
        public int IdCategorie { set; get; }

        [Display(Name = "Libelle Categorie"), MaxLength(20, ErrorMessage = "Taille maximal 20"), Required(ErrorMessage = "*")]
        public string libelleCategorie { set; get; }
    }
}