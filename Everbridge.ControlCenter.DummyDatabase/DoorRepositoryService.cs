using Everbridge.ControlCenter.Common;
using Everbridge.ControlCenter.DummyDatabase.Data;
using Everbridge.ControlCenter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace Everbridge.ControlCenter.DummyDatabase
{
    public class DoorRepositoryService : IDoorRepositoryService
    {
        private DummyDatabase _dataSource;
        private string _dataPath;

        public DoorRepositoryService()        
        {
            _dataPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "data","XMLDataSource.xml");
            _dataSource = XmlSerilization.DeserializeToObject<DummyDatabase>(_dataPath);
        }

        public bool AddDoor(DoorRecord door)
        {
            bool status = true;
            try
            {
                _dataSource.DoorRecords.Add(new DoorRecordDto()
                {
                    Id = door.Id,
                    Label = door.Label,
                    IsOpen = door.IsOpen,
                    IsLocked = door.IsLocked
                });

                XmlSerilization.SerializeToXml<DummyDatabase>(_dataSource, _dataPath);
            }
            catch (Exception)
            {
                status = false;
            }
            return status;

        }

        public DoorRecord GetDoor(string doorId)
        {
            DoorRecord record = null;
            var data = _dataSource.DoorRecords.Where(n => n.Id == doorId);

            if(data.Any())
            {
                record = new DoorRecord
                    (data.First().Id,
                    data.First().Label,
                    data.First().IsOpen,
                    data.First().IsLocked);
            }
            return record;
        }

        public IEnumerable<DoorRecord> GetDoors()
        {
           return _dataSource.DoorRecords.Select(n => new DoorRecord
                    (n.Id,
                    n.Label,
                    n.IsOpen,
                    n.IsLocked));
        }

        public bool RemoveDoor(string doorId)
        {
            bool status = true;
            try
            {
                var doors = _dataSource.DoorRecords.Where(n => n.Id == doorId);

                if (doors.Any())
                {
                    _dataSource.DoorRecords.Remove(doors.First());
                    XmlSerilization.SerializeToXml<DummyDatabase>(_dataSource, _dataPath);                    
                }

            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateDoor(DoorRecord door)
        {
            bool status = true;
            try
            {
                var doors = _dataSource.DoorRecords.Where(n => n.Id == door.Id);

                if (doors.Any())
                {
                    doors.First().Id = door.Id;
                    doors.First().Label = door.Label;
                    doors.First().IsOpen = door.IsOpen;
                    doors.First().IsLocked = door.IsLocked;
                    XmlSerilization.SerializeToXml<DummyDatabase>(_dataSource, _dataPath);
                }
            }
            catch (Exception)
            {

                status = false;
            }
            return status;
        }
    }
}
