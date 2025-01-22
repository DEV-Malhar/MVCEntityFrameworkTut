using Microsoft.EntityFrameworkCore;

namespace CodeFirstASPCore6.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options) //here Base is Calling DbContext Class Constructor
        {
                
        }

        public DbSet<Student> Students { get; set; }
    }
}
/*
 * DbContext*
 1:DbContext class is an integral part of Entity Framework
 2:This is the class that we use in our application code to interact with the underlying database
 3:It is the Class that manages the database connection and is used to retrieve and save data int the database
 4:An instance of DbContext represtes a session with the database which can be used to query and save instance of your
    entities to a database
 5:DbContextris combination of the Unit of Work and Repository Pattern 
 6:DbContext can be ued to define the database context class after creating a model class
 7:DbContext co-ordinate wuth Entity Framework and allows you to query and save the data in the database
 8:Uses the "DbSet<T>" (DbsetGeneric) type ro define one or more Properties 
   where "T" represent the type of an object that needs to be stored in the Database

**DbContextOPtions in Entity Framework Core**
 1:For the Dbcontext class to be ablw to do any useful work,it need an instance of the DbContextOptions class
    eg:
        public StudentDbContext(DbContextOptions options) : base(options)
 2:The DbContextOptions instance carries configuration information such as Connection string , Database Provider to use etc.

*/