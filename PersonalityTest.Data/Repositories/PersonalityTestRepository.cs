using PersonalityTest.Data.Models;
using PersonalityTest.Data.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityTest.Data.Repositories
{
    public class PersonalityTestRepository : IPersonalityTestRepository
    {
        private readonly PersonalityTestContext db;
        public PersonalityTestRepository(PersonalityTestContext db)
        {
            this.db = db;
        }
        public IQueryable<Option> Options => db.Options;

        public IQueryable<Question> Questions => db.Questions;

        public void Add<EntityType>(EntityType entity) => db.Add(entity);
        
        public void SaveChanges() => db.SaveChanges(); 
    }
}
