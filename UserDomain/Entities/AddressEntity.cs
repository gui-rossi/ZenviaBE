using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain.Entities
{
    public class AddressEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Alias { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Complemento { get; set; }

        public virtual UserEntity User { get; set; } = new();
    }
}
