using WebApp.Data;
using WebApp.Models;
using System.Linq;
using System.Collections.Generic;

namespace WebApp.Services
{
    public class DepartmentService
    {
        private readonly WebAppContext _context;

        public DepartmentService(WebAppContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Departamento).ToList();
        }



    }
}