using ApplicationsDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsDataAccess
{
    public interface IApplicationsRepository
    {
        Task<IEnumerable<VCompanyRole>> GetRoles(Expression<Func<VCompanyRole, bool>> func);
    }
}
