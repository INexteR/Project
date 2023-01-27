using System;
using System.Collections.Generic;

namespace TaskProject.Models
{
    public partial class Tour
    {
        public Tour()
        {
            Journals = new HashSet<Journal>();
        }

        public int IdTour { get; set; }
        public string Name { get; set; } = null!;
        public int IdCity { get; set; }
        public sbyte Duration { get; set; }
        public long Cost { get; set; }

        public virtual Country IdCityNavigation { get; set; } = null!;
        public virtual ICollection<Journal> Journals { get; set; }
    }
}
