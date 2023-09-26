using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Name { get; set; } = null!;

        public string Identifier { get; set; } = null!;

        public virtual ICollection<Deep> Posts { get; set; } = new List<Deep>();
    }
}
