using System.Net.Http.Json;
using TestBlazor.SharedLibrary;
using static System.Net.WebRequestMethods;

namespace TestBlazor.Client.Services;

public class EmployeeService : IEmployeeService
{
    private readonly HttpClient _httpClient; //to enable using http services when request to api server

    public EmployeeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<bool> DeleteEmployee(int id)
    {
        var result = await _httpClient.DeleteAsync($"api/employee/delete_employee/{id}");
        var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

        if (response!.IsCorrect)
            return response.IsCorrect!;
        else
            throw new Exception(response.Message);
    }

    public async Task<int> EditEmployee(EmployeeDTO employee)
    {
        var result = await _httpClient.PutAsJsonAsync($"api/employee/edit_employee/{employee.IdEmployee}", employee);
        var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

        if (response!.IsCorrect)
            return response.Value!;
        else
            throw new Exception(response.Message);
    }

    public async Task<List<EmployeeDTO>> ListEmployee()
    {
        var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<EmployeeDTO>>>("api/employee/list_employee");

        if (result!.IsCorrect)
            return result.Value!;
        else
            throw new Exception(result.Message);
    }

    public async Task<int> SaveEmployee(EmployeeDTO employee)
    {
        var result = await _httpClient.PostAsJsonAsync("api/employee/save_employee", employee);
        var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

        if (response!.IsCorrect)
            return response.Value!;
        else
            throw new Exception(response.Message);
    }

    public async Task<EmployeeDTO> SearchEmployee(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<ResponseAPI<EmployeeDTO>>($"api/employee/search_employee/{id}");

        if (result!.IsCorrect)
            return result.Value!;
        else
            throw new Exception(result.Message);
    }
}
