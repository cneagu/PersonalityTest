using PersonalityTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityTest.Data.Repositories.Contract
{
    public interface IPersonalityTestRepository
    {
        public IQueryable<Option> Options { get; }
        public IQueryable<Question> Questions { get; }

        void Add<EntityType>(EntityType entity);

        void SaveChanges();
    }
}
