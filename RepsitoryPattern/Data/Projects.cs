using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepsitoryPattern.Data
{
    public class Projects
    {
        public int Id { get; set; } 

        public string ProjectName { get; set; }
    
        public string Category { get; set; }

        public Supervisor Supervisor { get; set; }
        [ForeignKey("Id")]
        public Guid SupervisorId { get; set; }
        [ForeignKey("Id")]
        public int EmployeeId { get; internal set; }
        public Employee Employee { get; set; }

    }
}