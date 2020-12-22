using System;
using System.ComponentModel.DataAnnotations;

namespace RepsitoryPattern.Data
{
    public class Supervisor
    {
        [Key]
        public Guid SupervisorId { get; set; }

        public string SupervisorName { get; set; }
        public string Reputation { get; set; }
    }
}