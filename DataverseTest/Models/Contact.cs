using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataverseTest.Models
{
    public class Contact : BaseEntity
    {
        public Contact()
        {
            ContactPhones = new Collection<ContactPhone>();
        }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        //
        public ICollection<ContactPhone> ContactPhones { get; set; }
    }
}
