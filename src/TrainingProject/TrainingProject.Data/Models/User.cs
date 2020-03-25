using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Data.Models
{
    public class User
    {
        public Guid id_user { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public Guid id_userType { get; set; }
    }
}
