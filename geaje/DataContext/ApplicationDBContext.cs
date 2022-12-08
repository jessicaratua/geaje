using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using geaje.Models;

namespace geaje.DataContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext():base(nameOrConnectionString: "MyConnection")
        {

        }
        public virtual DbSet<adminModel> admins { get; set; }
        public virtual DbSet<desaModel> desas { get; set; }
        public virtual DbSet<kecModel> kecs { get; set; }
        public virtual DbSet<kotaModel> kotas { get; set; }
        public virtual DbSet<venueModel> venues { get; set; }
        public virtual DbSet<bookModel> books { get; set; }
    }
}