using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Data.Models
{
    public class Performer
    {
        public Guid IdPerformer { get; set; }
        public Guid IdUser { get; set; }
        public string Description { get; set; }
        public HashSet<PerformerReview> Reviews { get; set; }
    }
}
