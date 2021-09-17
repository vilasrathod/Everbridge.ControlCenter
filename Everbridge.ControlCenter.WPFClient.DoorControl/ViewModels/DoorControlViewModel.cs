using Everbridge.ControlCenter.Common;
using Everbridge.ControlCenter.DoorControl.Services;
using Everbridge.ControlCenter.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace Everbridge.ControlCenter.DoorControl.ViewModels
{
    public class DoorControlViewModel : BindableBase
    {
        private IDoorControlService DoorControlService;
        public DelegateCommand<object> RemoveDoorCommand { get; private set; }
        public DelegateCommand<object> UpdateDoorCommand { get; private set; }

        public DelegateCommand<object> AddDoorCommand { get; private set; }

        public DoorControlViewModel(IDoorControlService doorControlService)
        {
            DoorControlService = doorControlService;
            doorRecords = new ObservableCollection<DoorRecord>();
            newDoorRecords = new ObservableCollection<DoorRecord>();
            doorRecords.AddRange<DoorRecord>(DoorControlService.GetDoorRecords());
            RemoveDoorCommand = new DelegateCommand<object>(Remove, CanRemove);
            UpdateDoorCommand = new DelegateCommand<object>(UpdateDoor, CanUpdateDoor);
            AddDoorCommand = new DelegateCommand<object>(AddDoor, CanAddDoor);
        }

        private bool CanAddDoor(object arg)
        {
            return true;
        }

        private void AddDoor(object obj)
        {
            if (obj is DoorRecord)
            {
                var door = obj as DoorRecord;
                DoorControlService.AddDoor(door);
                doorRecords.Add(door);
                newDoorRecords.Clear();
                newDoorRecords.Add(new DoorRecord());
                RaisePropertyChanged(nameof(newDoorRecords));
            }
        }

        private bool CanUpdateDoor(object arg)
        {
            return true;
        }

        private void UpdateDoor(object obj)
        {
            if (obj is DoorRecord)
            {
                var door = obj as DoorRecord;
                DoorControlService.UpdateDoor(door);                
            }
        }

        private bool CanRemove(object arg)
        {
            return true;
        }

        private void Remove(object obj)
        {
            if(obj is DoorRecord)
            {
                var door = obj as DoorRecord;
                if (DoorControlService.RemoveDoor(door.Id))
                    doorRecords.Remove(door);
            }
        }

        private ObservableCollection<DoorRecord> doorRecords;
        public ObservableCollection<DoorRecord> DoorRecords
        {
            get { return doorRecords; }
            set
            {
                SetProperty(ref doorRecords, value,nameof(DoorRecords));
            }
        }

        private ObservableCollection<DoorRecord> newDoorRecords;
        public ObservableCollection<DoorRecord> NewDoorRecords
        {
            get { return newDoorRecords; }
            set
            {
                SetProperty(ref doorRecords, value, nameof(NewDoorRecords));
            }
        }



    }
}
