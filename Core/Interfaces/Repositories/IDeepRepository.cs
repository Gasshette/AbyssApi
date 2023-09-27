using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IDeepRepository
    {
        public IEnumerable<Deep> GetAll();
        public void Post(Deep post);
        public void Put(Deep post);
        public void Delete(int id);
    }
}
