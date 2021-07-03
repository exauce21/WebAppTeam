using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPWebGroupe.Models
{
    public class Profil
    {
        [Key]
        public int IdProfil { set; get; }

        [Display(Name = "Libelle Profil"), MaxLength(20, ErrorMessage = "Taille maximal 20"), Required(ErrorMessage = "*")]
        public string libelleProfil { set; get; }
    }
}