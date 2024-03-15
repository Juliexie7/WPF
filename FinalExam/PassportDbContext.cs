using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    internal class PassportDbContext: DbContext
    {
        const string DbName = "passportdatabases.mdf";
        static string DbPath = Path.Combine(Environment.CurrentDirectory, DbName);

        public PassportDbContext() : base($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={DbPath};Integrated Security=True;Connect Timeout=30")
        {

        }
        public DbSet<Passport> Passports { get; set; }
    }
}
