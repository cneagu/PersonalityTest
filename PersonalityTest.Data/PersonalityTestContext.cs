using Microsoft.EntityFrameworkCore;
using PersonalityTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityTest.Data
{
    public class PersonalityTestContext : DbContext
    {
        public PersonalityTestContext(DbContextOptions<PersonalityTestContext> options) : base(options)
        {

        }

        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
