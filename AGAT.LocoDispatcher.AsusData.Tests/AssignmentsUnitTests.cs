using AGAT.LocoDispatcher.AsusData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                List<Assignment> data = db.Assignments.ToList();
                Assert.NotEmpty(data);
            }
        }
    }
}
