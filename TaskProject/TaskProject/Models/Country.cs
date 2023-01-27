using System;
using System.Collections.Generic;

namespace TaskProject.Models
{
    public partial class Country
    {
        public Country()
        {
            Tours = new HashSet<Tour>();
        }

        public int IdCity { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
