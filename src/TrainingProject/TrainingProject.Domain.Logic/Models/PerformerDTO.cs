﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models
{
    public class PerformerDTO
    {
        public Guid id_perf { get; set; }
        public Guid id_user { get; set; }
        public string description { get; set; }
    }
}