using Everbridge.ControlCenter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Everbridge.ControlCenter.DummyDatabase.Data
{
    public class DoorRecordDto
    {
        [XmlElement(ElementName = "Id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "Label")]
        public string Label { get; set; }

        [XmlElement(ElementName = "IsOpen")]
        public bool IsOpen { get; set; }

        [XmlElement(ElementName = "IsLocked")]
        public bool IsLocked { get; set; }
    }
}
