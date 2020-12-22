using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepsitoryPattern.Data
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Categroy { get; internal set; }
        public string ProjectName { get; internal set; }
        public string EmployeeName { get; internal set; }
        public string SupervisorName { get; internal set; }
    }
}