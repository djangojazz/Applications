using ApplicationsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsDataAccess
{
    public sealed class ApplicationsRepository : IApplicationsRepository
    {
        private readonly ApplicationsContext _context;

        public ApplicationsRepository(ApplicationsContext context) => _context = context;

        public async Task<IEnumerable<VCompanyRole>> GetRoles(Expression<Func<VCompanyRole, bool>> func) => 
            await _context.VCompanyRoles.Where(func).ToListAsync();
    }
}
