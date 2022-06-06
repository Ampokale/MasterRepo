using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace EntityLayer.Models
{
    public partial class Project
    {
        public Project()
        {
            TbTasks = new HashSet<TbTask>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Startdate { get; set; }
        [JsonIgnore]
        public virtual User CreatedByNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<TbTask> TbTasks { get; set; }
    }
}
