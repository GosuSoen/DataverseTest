using DataverseTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataverseTest.IRepositories
{
    public interface IContactRepository
    {
        ICollection<Contact> GetAllContacts();
        ICollection<Contact> GetContactsWithExpressionFilter(Expression<Func<Contact, bool>> filterExpression);
        Contact GetSingleContactById(int id);
        Contact GetContactWithExpressionFilter(Expression<Func<Contact, bool>> filterExpression);
        void AddContact(Contact ct);
        void UpdateContact(Contact ct);
        void DeleteContact(Contact ct);
    }
}
