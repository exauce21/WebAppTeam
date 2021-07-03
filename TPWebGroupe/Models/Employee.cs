﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPWebGroupe.Models
{
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int EmployeeID { get; set; }
        [Display(Name = "Nom prénom"), Required(ErrorMessage = "*")]
        public string Name { get; set; }
        [Display(Name = "Age"), Required(ErrorMessage = "*")]
        public int Age { get; set; }
        [Display(Name = "Etat"), Required(ErrorMessage = "*")]
        public string State { get; set; }
        [Display(Name = "Pays"), Required(ErrorMessage = "*")]
        public string Country { get; set; }

    }
}