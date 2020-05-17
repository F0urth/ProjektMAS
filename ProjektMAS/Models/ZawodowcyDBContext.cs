using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 *
 * @author F0urth 
 *
 * @date - 5/10/2020 12:00:24 AM 
 *
 */
namespace ProjektMAS.Models
{
    public class ZawodowcyDBContext : DbContext
    {
 
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=DESKTOP-P2NRNCA;Initial Catalog=MasProjectDbZawodowcy;Integrated Security=True");
        }
    }
}
