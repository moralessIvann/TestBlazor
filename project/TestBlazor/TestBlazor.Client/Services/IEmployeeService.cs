using TestBlazor.SharedLibrary;

namespace TestBlazor.Client.Services;

public interface IEmployeeService
{
    Task<List<EmployeeDTO>> ListEmployee();
    Task<int> SaveEmployee(EmployeeDTO employee);
    Task<int> EditEmployee(EmployeeDTO empleado);
    Task<bool> DeleteEmployee(int id);
    Task<EmployeeDTO> SearchEmployee(int id);
}
