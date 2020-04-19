using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models
{
    public class OrderDTO
    {
        public Guid IdOrder { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdCategory { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
        public Guid IdStatus { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? AssignedData { get; set; } 

    }
}
