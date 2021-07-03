using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPWebGroupe.Models
{
    public class Utilisateur
    {
        [Key]
        public int id { set; get; }

        [Display(Name = "Nom"), MaxLength(60, ErrorMessage = "Taille maximal 30"), Required(ErrorMessage = "*")]
        public string nom { set; get; }

        [Display(Name = "Prenom"), MaxLength(60, ErrorMessage = "Taille maximal 30"), Required(ErrorMessage = "*")]
        public string prenom { set; get; }

        [Display(Name = "Identifiant"), MaxLength(60, ErrorMessage = "Taille maximal 30"), Required(ErrorMessage = "*")]
        public string identifint { set; get; }

        [Display(Name = "Email"), Required(ErrorMessage = "*")]
        public string email { set; get; }

        [Display(Name = "Actif"),MaxLength(1)]
        public string actif { set; get; }

        [Display(Name = "Profil"), MaxLength(20), Required(ErrorMessage = "*")]
        public string profil { set; get; }

        [MaxLength(128)]
        public string idUser { set; get; }
        
    }
}