using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataverseTest.Models;
using DataverseTest.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DataverseTest.Controllers
{
    public class BaseController : Controller
    {
        //Declare Context
        private DataverseDbContext _context;
        //Declare Unit of work service that will be 
        public IUnitOfWork _unitOfWork;

        //Initialize our unit of work to be able to open transactions with database
        protected BaseController()
        {
            _unitOfWork = new UnitOfWork(new DataverseDbContext(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DataverseConnectionString"))));
        }
    }
}