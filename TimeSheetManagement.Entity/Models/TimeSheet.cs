using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TimeSheetManagement.Entity.Models
{
    public class TimeSheet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeSheetID { get; set; }

        public Project project { get; set; }
        [ForeignKey("project")]
        public int ProjectID { get; set; }

        public Employee employee { get; set; }
        [ForeignKey("employee")]
        public int EmpID { get; set; }

        public string Date { get; set; }

        public string TimeFrom { get; set; }

        public string TimeTo { get; set; }

        public decimal Hours { get; set; }

        public string Status { get; set; }


    }
}
