using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Everbridge.ControlCenter.Server.Model
{
    [DataContract]
    public class DoorModel
    {
        [DataMember(Name = "id")]
        [Required]
        public string Id { get; set; }

        [DataMember(Name = "label")]
        [Required]
        public string Label { get; set; }

        [DataMember(Name = "isOpen")]
        [Required]
        public bool IsOpen { get; set; }

        [DataMember(Name = "isLocked")]
        [Required]
        public bool IsLocked { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DoorModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  IsOpen: ").Append(IsOpen).Append("\n");
            sb.Append("  IsLocked: ").Append(IsLocked).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}
