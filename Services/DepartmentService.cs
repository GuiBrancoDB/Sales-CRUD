using WebApp.Data;
using WebApp.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Services
{
    public class DepartmentService
    {
        private readonly WebAppContext _context;

        public DepartmentService(WebAppContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Departamento).ToListAsync();
        }



    }
}