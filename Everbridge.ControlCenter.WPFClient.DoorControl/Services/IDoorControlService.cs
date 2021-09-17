using Everbridge.ControlCenter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Everbridge.ControlCenter.DoorControl.Services
{
    public interface IDoorControlService
    {
        IEnumerable<DoorRecord> GetDoorRecords();
        DoorRecord GetDoor(string doorId);
        void AddDoor(DoorRecord door);
        bool RemoveDoor(string id);

        void UpdateDoor(DoorRecord door);

    }
}
