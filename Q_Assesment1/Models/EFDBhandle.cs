using Microsoft.EntityFrameworkCore;

namespace Q_Assesment1.Models
{
    public class EFDBhandle : DbContext
    {

        public string conn = "Server=WKSMOHAMMED;Database=Q_AssesmentDB2;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsB)
        {
            optionsB.UseSqlServer(conn);
        }


        public DbSet<User> User_TB { get; set; }
       

        public DbSet<Userdata> History_TB { get; set; }



    }
}
