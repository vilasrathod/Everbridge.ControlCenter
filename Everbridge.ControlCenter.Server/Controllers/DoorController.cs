using Everbridge.ControlCenter.DummyDatabase;
using Everbridge.ControlCenter.Models;
using Everbridge.ControlCenter.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Everbridge.ControlCenter.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DoorController : ControllerBase
    {
        private readonly IDoorRepositoryService _doorRepositoryService;

        public DoorController(IDoorRepositoryService doorRepositoryService)
        {
            _doorRepositoryService = doorRepositoryService;
        }

        [HttpGet]
        public IEnumerable<DoorModel> Get()
        {
            return _doorRepositoryService.GetDoors().Select(n =>
            new DoorModel()
            {
                Id = n.Id,
                Label = n.Label,
                IsOpen = n.IsOpen,
                IsLocked = n.IsLocked
            });
        }

        [HttpGet]
        [Route("{doorId}")]
        public DoorModel GetDoor([FromRoute][Required] string doorId)
        {
            var doorRecord = _doorRepositoryService.GetDoor(doorId);

            return (doorRecord == null)
                ? null
                : new DoorModel
                {
                    Id = doorRecord.Id,
                    Label = doorRecord.Label,
                    IsOpen = doorRecord.IsOpen,
                    IsLocked = doorRecord.IsLocked
                };
        }

        
        [HttpPost]
        public void AddDoor(DoorModel value)
        {
            _doorRepositoryService.AddDoor(new DoorRecord(value.Id, value.Label, value.IsOpen, value.IsLocked));
        }

        
        [HttpDelete("{id}")]
        public void DeleteDoor(string id)
        {
            _doorRepositoryService.RemoveDoor(id);
        }

        [HttpPut]
        public void UpdateDoor(DoorModel value)
        {
            _doorRepositoryService.UpdateDoor(new DoorRecord(value.Id, value.Label, value.IsOpen, value.IsLocked));
        }
    }
}
