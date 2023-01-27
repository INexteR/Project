using System;
using System.Collections.Generic;

namespace TaskProject.Models
{
    public partial class Journal
    {
        public int IdRecord { get; set; }
        public int ClientId { get; set; }
        public int TourId { get; set; }
        public int TourCount { get; set; }
        public DateOnly StartDate { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual Tour Tour { get; set; } = null!;
    }
}
