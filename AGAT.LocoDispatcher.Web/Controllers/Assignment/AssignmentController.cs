using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGAT.LocoDispatcher.Business.Classes.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGAT.LocoDispatcher.Web.Controllers.Assignment
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private AssignmentManager manager;
        public AssignmentController(AssignmentManager _manager)
        {
            manager = _manager;
        }
        public async Task<IEnumerable<Business.Models.AssignmentModels.Assignment>> Get()
        {
            return await manager.GetAsync();
        }
    }
}
