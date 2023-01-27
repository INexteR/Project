using System;
using System.Collections.Generic;

namespace TaskProject.Models
{
    public partial class Log
    {
        public int IdRecord { get; set; }
        public string EmployeeFullName { get; set; } = null!;
        public DateTime DateTime { get; set; }
    }
}
