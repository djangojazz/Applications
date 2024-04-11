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
            var results = await _repository.GetRolesAsync(x => x.CompanyId >= 40);
            results.Count().Should().BeGreaterThan(1);
        }

        [Fact]
        public async Task CanUpdateARecord()
        {
            var company = "AssistRx";
            var role = "Tech Lead (remote) - .NET Angular";
            var desc = "Test automatically";
            var updateModel = new AddOrUpdateEntryModel(company, 1, "Orland (remote)", "FL", role, 130000, 170000, new DateTime(2024, 4, 11), desc);
            await _repository.SaveOrUpdateApplicationEntryAsync(updateModel);
            var results = await _repository.GetRolesAsync(x => x.Company == company && x.RoleName == role);
            results.First().RoleDescription.Should().Be(desc);
        }
    }
}