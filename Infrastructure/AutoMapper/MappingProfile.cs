using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<Core.Entities.Deep, Deep>().ReverseMap();
            CreateMap<Core.Entities.Account, Account>().ReverseMap();
        }
    }
}
