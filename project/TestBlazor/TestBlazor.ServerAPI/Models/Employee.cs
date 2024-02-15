using System;
using System.Collections.Generic;

namespace TestBlazor.ServerAPI.Models;

public class Employee
{
    public int IdEmployee { get; set; }

    public string FullName { get; set; } = null!;

    public int Income { get; set; }

    public DateTime ContractDate { get; set; }
}
