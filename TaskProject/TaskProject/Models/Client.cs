using System;
using System.Collections.Generic;

namespace TaskProject.Models
{
    public partial class Client
    {
        public Client()
        {
            Journals = new HashSet<Journal>();
        }

        public int IdClient { get; set; }
        public string FullName { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public string Phone { get; set; } = null!;

        public virtual ICollection<Journal> Journals { get; set; }
    }
}
