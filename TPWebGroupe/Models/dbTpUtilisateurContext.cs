using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TPWebGroupe.Models
{
    public class dbTpUtilisateurContext : DbContext
    {
        public dbTpUtilisateurContext() : base("name=connTPUser")
        {
        }
        
        public DbSet<Produit> produits { get; set; }
        public DbSet<Categorie> categories { get; set; }
        public DbSet<Profil> Profils { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}