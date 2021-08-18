using Microsoft.EntityFrameworkCore;

namespace OdinPlugs.OdinPython.Test.dbContext
{
    public class DBEntities : DbContext
    {
        //public DBEntities() { }
        public DBEntities(DbContextOptions<DBEntities> options) : base(options)
        {

        }
        public DbSet<Report_DbModel> Reports { get; set; }
    }
}