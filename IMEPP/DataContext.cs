using IMEPP.Entities;
using System;
using System.Data.Entity;

namespace IMEPP
{
    public class DataContext:DbContext
    {
        DbSet<Adviser> Advisers { get; set; }
        DbSet<Career> Careers { get; set; }
        DbSet<Coach> Coaches { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Coordinator> Coordinators { get; set; }
        DbSet<Student> Students { get; set; }
        public DataContext():base("name=con")
        {

        }

        internal object Entry<T>(object sparePart)
        {
            throw new NotImplementedException();
        }
    }
}
