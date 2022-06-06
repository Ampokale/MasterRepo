using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace EntityLayer.Models
{
    public partial class ProjectMember
    {
        public int? ProjectId { get; set; }
        public int? UserId { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public virtual User EmailNavigation { get; set; }
        [JsonIgnore]
        public virtual Project Project { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
