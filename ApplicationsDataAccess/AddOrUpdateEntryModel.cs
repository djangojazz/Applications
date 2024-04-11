using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsDataAccess
{
    public record struct AddOrUpdateEntryModel(string Company, int StatusId, string City, string State, string Role, decimal PayStart, decimal PayEnd, DateTime AppliedDate, string RoleDesc) { }
}
