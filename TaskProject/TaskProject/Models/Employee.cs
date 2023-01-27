using System;
using System.Collections.Generic;

namespace TaskProject.Models
{
    public partial class Employee
    {
        public int IdEmployee { get; set; }
        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
