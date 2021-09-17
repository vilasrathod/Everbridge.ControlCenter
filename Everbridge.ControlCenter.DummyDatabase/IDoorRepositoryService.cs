using Everbridge.ControlCenter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Everbridge.ControlCenter.DummyDatabase
{
    public interface IDoorRepositoryService
    {
        public IEnumerable<DoorRecord> GetDoors();
        public DoorRecord GetDoor(string doorId);
        public bool AddDoor(DoorRecord door);
        public bool RemoveDoor(string doorId);
        public bool UpdateDoor(DoorRecord door);
    }
}
