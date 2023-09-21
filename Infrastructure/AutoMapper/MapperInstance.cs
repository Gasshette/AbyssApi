using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
    internal class MapperInstance
    {
        private static IMapper _instance;
        public static IMapper Mapper { get { return _instance ?? Configure(); } }

        private static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _instance = config.CreateMapper();
            return _instance;
        }
    }
}
