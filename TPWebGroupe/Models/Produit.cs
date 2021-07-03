using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPWebGroupe.Models
{
    public class Produit
    {
        [Key]
        public int idProduit { get; set; }

        [Display(Name = "Désignation"), MaxLength(80, ErrorMessage = "Taille maximal 80"), Required(ErrorMessage = "*")]
        public string Designation { get; set; }

        [Display(Name = "Prix Unitaire"), Required(ErrorMessage = "*")]
        public int PU { get; set; }

        [Display(Name = "Quantité en Stock"), Required(ErrorMessage = "*")]
        public double QteStock { get; set; }

        [Display(Name = "Quantité minimale"), Required(ErrorMessage = "*")]
        public double QteMin { get; set; }

        [Display(Name = "Date de péremption"), DataType(DataType.DateTime), Required(ErrorMessage = "*")]
        public DateTime DatePeremption { get; set; }

        [Display(Name = "Catégorie"), Required(ErrorMessage = "*")]
        public int idCategorie { get; set; }

        [ForeignKey("idCategorie")]
        public virtual Categorie Categorie { get; set; }
    }
}