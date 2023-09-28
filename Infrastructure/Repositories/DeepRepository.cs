using AutoMapper;
using Core.Interfaces.Repositories;
using Infrastructure.AutoMapper;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = Core.Entities;

namespace Infrastructure.Repositories
{
    public class DeepRepository : IDeepRepository
    {
        private readonly AbyssDbContext _context;

        public DeepRepository(AbyssDbContext context)
        {
            _context = context;
        }

        public IEnumerable<C.Deep> GetAll()
        {
            //IIncludableQueryable<Deep, Account?> query = _context.Set<Deep>().OrderByDescending(d => d.Id).Include(p => p.Account);
            //IEnumerable<Deep> deeps = query.Select(p => new Deep
            //{
            //    Text = p.Text,
            //    Id = p.Id,
            //    Guid = p.Guid,
            //    Date = p.Date,
            //    AccountGuid = p.AccountGuid,
            //    Account = p.Account != null ? null : new Account
            //    {
            //        Id = p.Account.Id,
            //        Name = p.Account.Name,
            //        Guid = p.Account.Guid,
            //        Identifier = p.Account.Identifier
            //        // Avoid cycling ref by not getting the posts of this account.
            //        // Could be done with [JsonIgnore] over the prop in the model as well
            //    }
            //}).AsNoTracking().ToList();
            //return MapperInstance.Mapper.Map<IEnumerable<Deep>, IEnumerable<C.Deep>>(deeps);
            return new List<C.Deep>();
        }

        public void Post(C.Deep deep)
        {
            Deep postContext = MapperInstance.Mapper.Map<Deep>(deep);
            _context.Add(postContext);
            _context.SaveChanges();
        }

        public void Put(C.Deep deep)
        {
            Deep? deepContext = _context.Deeps.Where(p => p.Id == deep.Id).AsNoTracking().FirstOrDefault();

            if (deepContext != null)
            {
                deepContext.Account = null;
                deepContext = MapperInstance.Mapper.Map<Deep>(deep);
                _context.Update(deepContext);
                _context.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            Deep? deep = _context.Deeps.SingleOrDefault(d => d.Id == id);

            if (deep != null)
            {
                _context.Remove(deep);
                _context.SaveChanges();
            }
        }
    }
}
