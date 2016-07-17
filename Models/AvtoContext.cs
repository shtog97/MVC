using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace WebApllication4.Models
{
    public class AvtoContext:DbContext
    {
        public AvtoContext()
            : base("AvtoConnection")
        {
            
        }
        public DbSet<Avto> Avtos { get; set; }
       
    }
}