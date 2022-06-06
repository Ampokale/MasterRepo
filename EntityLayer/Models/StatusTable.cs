using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace EntityLayer.Models
{
    public partial class StatusTable
    {
        public StatusTable()
        {
            TbTasks = new HashSet<TbTask>();
        }

        public int StatusId { get; set; }
        public string SDetail { get; set; }
        [JsonIgnore]
        public virtual ICollection<TbTask> TbTasks { get; set; }
    }
}
