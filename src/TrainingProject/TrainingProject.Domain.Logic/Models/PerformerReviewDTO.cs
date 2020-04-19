using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models
{
    public class PerformerReviewDTO
    {
        public Guid IdReview { get; set; }
        public Guid IdPerformer { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
