using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Data.Models
{
    public class Performer
    {
        public Guid id_perf { get; set; }
        public Guid id_user { get; set; }
        public string description { get; set; }
        public HashSet<PerformerReview> Reviews { get; set; }
    }
}
