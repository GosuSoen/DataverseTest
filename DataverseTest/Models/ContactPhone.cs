using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataverseTest.Models
{
    public class ContactPhone : BaseEntity
    {
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public int PhoneNumber { get; set; }
    }
}
