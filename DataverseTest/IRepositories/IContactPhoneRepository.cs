using DataverseTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataverseTest.IRepositories
{
    public interface IContactPhoneRepository
    {
        ICollection<ContactPhone> GetAllContactPhones();
        ICollection<ContactPhone> GetContactPhonesWithExpressionFilter(Expression<Func<bool, string>> filterExpression);
        ContactPhone GetSingleContactPhoneById(int id);
        ContactPhone GetContactPhoneWithExpressionFilter(Expression<Func<bool, string>> filterExpression);
        void AddContactPhone(ContactPhone cp);
        void UpdateContactPhone(ContactPhone cp);
        void DeleteContactPhone(ContactPhone cp);
    }
}
