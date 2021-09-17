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

        private string id;
        public string Id 
        { 
            get { return id; }
            set
            {
                SetProperty(ref id, value, nameof(Id));
            }
            
        }

        public string label;
        public string Label
        {
            get { return label; }
            set
            {
                SetProperty(ref label, value, nameof(Label));
            }

        }

        private bool isOpen;
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                SetProperty(ref isOpen, value, nameof(IsOpen));
            }

        }

        private bool isLocked;
        public bool IsLocked
        {
            get { return isLocked; }
            set
            {
                SetProperty(ref isLocked, value, nameof(IsLocked));
            }

        }
    }
}
