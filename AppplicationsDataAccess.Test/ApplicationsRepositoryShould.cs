using ApplicationsDataAccess;
using FluentAssertions;

namespace AppplicationsDataAccess.Test
{
    public class ApplicationsRepositoryShould
    {
        private readonly IApplicationsRepository _repository;

        public ApplicationsRepositoryShould() => _repository = new ApplicationsRepository(new ApplicationsContext());

        [Fact]
        public async Task HaveMoreThanASingleCompanyRole()
        {
            var results = await _repository.GetRoles(x => x.CompanyId >= 40);
            results.Count().Should().BeGreaterThan(1);
        }
    }
}