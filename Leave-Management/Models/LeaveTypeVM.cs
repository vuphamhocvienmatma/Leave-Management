using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Models
{  
    public class LeaveTypeVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name ="Ngày tạo")]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Ngày được hưởng")]
        [Required]
        [Range(1,25,ErrorMessage ="Please Enter a vaild number")]
        public int DefaultDays { get; set; }
    }
}
