using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain.Entities
{
    public class TelephoneNumberEntity : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Alias { get; set; }
        public string Number { get; set; }

        public Guid User_Id { get; set; }
        public virtual UserEntity User { get; set; } = new();
    }
}
