using AGAT.LocoDispatcher.AsusData.Models;
using AGAT.LocoDispatcher.AsusData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AGAT.LocoDispatcher.AsusData.Tests
{
    public class AssignmentUnitTests
    {
        public AssignmentUnitTests()
        {
            ConnectionFaccede.SetConnectionString("Data Source=192.168.111.211;Initial Catalog=asus;User ID=web;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        [Fact]
        public void AsssignmentsNotEmptyOk()
        {
            using (AsusDataContext db = new AsusDataContext())
            {
                IEnumerable<Assignment> assignments = db.Assignments.ToList();
                Assert.NotEmpty(assignments);
            }
        }

        [Fact]
        public async Task GetAssignmentRepositoryOk()
        {
            AssignmentRepository repository = new AssignmentRepository();
            var assignments = await repository.GetActiveAsync();
            Assert.NotEmpty(assignments);
        }
    }
}
