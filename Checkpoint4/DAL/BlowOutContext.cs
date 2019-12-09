using Checkpoint4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Checkpoint4.DAL
{
    public class BlowOutContext : DbContext
    {
        public BlowOutContext()
            : base("BlowOutContext")
        {

        }

        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Client> Clients { get; set; }

    }
}