using AutoMapper;
using Core.Interfaces.Repositories;
using Infrastructure.AutoMapper;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = Core.Entities;

namespace Infrastructure.Repositories
{
    public class PostRepository: IPostRepository
    {
        private readonly AbyssDbContext _context;

        public PostRepository(AbyssDbContext context)
        {
            _context = context;    
        }

        public IEnumerable<C.Post> GetAll()
        {
            DbSet<Post> query = _context.Set<Post>();
            IEnumerable<Post> posts = query.AsNoTracking().ToList();
            return  MapperInstance.Mapper.Map<IEnumerable<Post>, IEnumerable<C.Post>>(posts);
        }
    }
}
