using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace EntityLayer.Models
{
    public partial class Report
    {
        public int? PId { get; set; }
        public string Email { get; set; }
        public int Taskstatus { get; set; }
        public string TaskDetails { get; set; }
        public string WhatAction { get; set; }
        public DateTime? ReportedOn { get; set; }
        [JsonIgnore]
        public virtual Project PIdNavigation { get; set; }
    }
}
