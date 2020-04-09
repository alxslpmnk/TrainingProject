using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models
{
    public class PerformerDTO
    {
        public Guid IdPerformer { get; set; }
        public Guid IdUser { get; set; }
        public string Description { get; set; }
    }
}
