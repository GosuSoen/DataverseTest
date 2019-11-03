using DataverseTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataverseTest.ViewModels
{
    public class ContactViewModel
    {
        public Contact Contact  {get;set; }
        public int PhoneNumber { get; set; }
        public int ContactPhoneId { get; set; }
    }
}
