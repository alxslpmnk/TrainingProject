﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Data.Models
{
    public class User
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IdUserType { get; set; }
    }
}
