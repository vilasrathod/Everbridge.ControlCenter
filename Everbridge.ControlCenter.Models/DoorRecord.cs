using Prism.Mvvm;
using System;

namespace Everbridge.ControlCenter.Models
{
    public class DoorRecord : BindableBase
    {
        public DoorRecord()
        {
        }

        public DoorRecord(string id, string label, bool isOpen, bool isLocked)
        {
            Id = id;
            Label = label;
            IsOpen = isOpen;
            IsLocked = isLocked;
        }

        public string Id { get; set; }

        public string Label { get; set; }

        public bool IsOpen { get; set; }

        public bool IsLocked { get; set; }
    }
}
