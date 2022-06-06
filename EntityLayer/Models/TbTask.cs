using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace EntityLayer.Models
{
    public partial class TbTask
    {
        public int TId { get; set; }
        public int? PId { get; set; }
        public string AssignedTo { get; set; }
        public string TaskDetails { get; set; }
        public int? TaskStatus { get; set; }
        public string AssignedBy { get; set; }
        [JsonIgnore]
        public virtual Project PIdNavigation { get; set; }
        [JsonIgnore]
        public virtual StatusTable TaskStatusNavigation { get; set; }
    }
}
