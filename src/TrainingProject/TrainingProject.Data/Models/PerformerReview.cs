using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Data.Models
{
    public class PerformerReview
    {
        public Guid id_review { get; set; }
        public Guid id_performer { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
    }
}
