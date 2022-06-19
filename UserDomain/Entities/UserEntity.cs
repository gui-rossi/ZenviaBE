using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDomain.Entities
{
    public class UserEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }

        public virtual ICollection<TelephoneNumberEntity> telephoneNumbers { get; set; }
        public virtual ICollection<AddressEntity> addresses { get; set; }
    }
}
