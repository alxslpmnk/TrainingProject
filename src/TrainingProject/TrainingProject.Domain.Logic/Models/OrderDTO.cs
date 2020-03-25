using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Logic.Models
{
    public class OrderDTO
    {
        public Guid id_order { get; set; }
        public Guid id_user { get; set; }
        public Guid id_category { get; set; }
        public string Description { get; set; }
        public string? image_path { get; set; }
        public Guid id_status { get; set; }
        public DateTime endDate { get; set; }
        public DateTime? assignedData { get; set; } 

    }
}
