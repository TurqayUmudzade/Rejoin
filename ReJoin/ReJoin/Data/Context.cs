using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ReJoin.Models;

namespace ReJoin.Data
{
    public class Context : DbContext
    {
        public Context() : base("Server=DESKTOP-TULDBCK;Database=Rejoin;Trusted_Connection=True;")
        {

        }
        public DbSet<ContactInfo> contactInfos { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<JobAd> JobsAd { get; set; }
        public DbSet<Resume> resumes { get; set; }

        public DbSet<Education> educations { get; set; }
        public DbSet<WorkExprience> workExpriences { get; set; }
    }
}