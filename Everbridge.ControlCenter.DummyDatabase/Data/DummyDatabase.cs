using Everbridge.ControlCenter.DummyDatabase.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Everbridge.ControlCenter.DummyDatabase
{
    [XmlRoot(ElementName = "DoorRecords")]
    public class DummyDatabase
    {
      public DummyDatabase()
        {
            DoorRecords = new List<DoorRecordDto>();
        }

        [XmlElement(ElementName = "DoorRecord")]
        public List<DoorRecordDto> DoorRecords { get; set; }

    }
}
