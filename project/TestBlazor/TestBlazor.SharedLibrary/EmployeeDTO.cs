using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TestBlazor.SharedLibrary;

public class EmployeeDTO
{
    public int IdEmployee { get; set; }

    [Required(ErrorMessage = "Field cannot be empty")]
    public string FullName { get; set; } = null!;

    //[Required]
    //[Range(1, int.MaxValue, ErrorMessage = "Field cannot be empty")]
    [Required(ErrorMessage = "Field cannot be empty")]
    public int Income { get; set; }

    public DateTime ContractDate { get; set; }
}
