using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace EntityLayer.Models
{
    public partial class User
    {
        public User()
        {
            Projects = new HashSet<Project>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        [JsonIgnore]
        public virtual ICollection<Project> Projects { get; set; }
    }
}
