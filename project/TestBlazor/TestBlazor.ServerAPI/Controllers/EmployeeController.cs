using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TestBlazor.ServerAPI.Models;
using TestBlazor.SharedLibrary;

namespace TestBlazor.ServerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly DbtestBlazorContext _context;
    public EmployeeController(DbtestBlazorContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("list_employee")]
    public async Task<IActionResult> ListEmployee()
    {
        var listEmployeeDTO = new List<EmployeeDTO>();
        var responseAPI = new ResponseAPI<List<EmployeeDTO>>();

        try
        {
            foreach (var item in await _context.Employees.OrderBy(x => x.IdEmployee).ToListAsync())
            {
                listEmployeeDTO.Add(new EmployeeDTO
                {
                    IdEmployee = item.IdEmployee,
                    FullName = item.FullName,
                    Income = item.Income,
                    ContractDate = item.ContractDate,
                });
            }

            responseAPI.StatusCode = HttpStatusCode.OK;
            responseAPI.IsCorrect = true;
            responseAPI.Value = listEmployeeDTO;

        }
        catch (Exception ex)
        {
            responseAPI.StatusCode = HttpStatusCode.InternalServerError;
            responseAPI.IsCorrect = false;
            responseAPI.Message = ex.Message;
        }

        return Ok(responseAPI);
    }

    [HttpPost]
    [Route("save_employee")]
    public async Task<IActionResult> SaveEmployee(EmployeeDTO employee)
    {
        var responseAPI = new ResponseAPI<int>();

        try
        {
            var new_employee = new Employee
            {
                FullName = employee.FullName,
                Income = employee.Income,
                ContractDate = employee.ContractDate,
                
            };

            _context.Employees.Add(new_employee);
            await _context.SaveChangesAsync();

            if (new_employee.IdEmployee != 0)
            {
                responseAPI.StatusCode = HttpStatusCode.OK;
                responseAPI.IsCorrect = true;
                responseAPI.Value = new_employee.IdEmployee;
            }

        }
        catch (Exception ex)
        {
            responseAPI.StatusCode = HttpStatusCode.InternalServerError;
            responseAPI.IsCorrect = false;
            responseAPI.Message = ex.Message;
        }

        return Ok(responseAPI);
    }

    [HttpPut]
    [Route("edit_employee/{id}")]
    public async Task<IActionResult> EditEmployee(EmployeeDTO employee, int id)
    {
        var responseApi = new ResponseAPI<int>();

        try
        {

            var edit_employee = await _context.Employees.FirstOrDefaultAsync(e => e.IdEmployee == id);

            if (edit_employee != null)
            {

                edit_employee.FullName = employee.FullName;
                edit_employee.Income = employee.Income;
                edit_employee.ContractDate = employee.ContractDate;

                _context.Employees.Update(edit_employee);
                await _context.SaveChangesAsync();

                responseApi.IsCorrect = true;
                responseApi.Value = edit_employee.IdEmployee;

            }
            else
            {
                responseApi.IsCorrect = false;
                responseApi.Message = "Employee not found";
            }

        }
        catch (Exception ex)
        {
            responseApi.IsCorrect = false;
            responseApi.Message = ex.Message;
        }

        return Ok(responseApi);
    }

    
    [HttpDelete]
    [Route("delete_employee/{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var responseApi = new ResponseAPI<int>();

        try
        {

            var delete_employee = await _context.Employees.FirstOrDefaultAsync(e => e.IdEmployee == id);

            if (delete_employee != null)
            {
                _context.Employees.Remove(delete_employee);
                await _context.SaveChangesAsync();

                responseApi.IsCorrect = true;
            }
            else
            {
                responseApi.IsCorrect = false;
                responseApi.Message = "Employee not found";
            }

        }
        catch (Exception ex)
        {

            responseApi.IsCorrect = false;
            responseApi.Message = ex.Message;
        }

        return Ok(responseApi);
    }

    [HttpGet]
    [Route("search_employee/{id}")]
    public async Task<IActionResult> SearchEmployee(int id)
    {
        var responseApi = new ResponseAPI<EmployeeDTO>();
        var EmployeeDTO = new EmployeeDTO();

        try
        {
            var db_employee = await _context.Employees.FirstOrDefaultAsync(x => x.IdEmployee == id);

            if (db_employee != null)
            {
                EmployeeDTO.IdEmployee = db_employee.IdEmployee;
                EmployeeDTO.FullName = db_employee.FullName;
                EmployeeDTO.Income = db_employee.Income;
                EmployeeDTO.ContractDate = db_employee.ContractDate;

                responseApi.IsCorrect = true;
                responseApi.Value = EmployeeDTO;
            }
            else
            {
                responseApi.IsCorrect = false;
                responseApi.Message = "Employee not found";
            }

        }
        catch (Exception ex)
        {
            responseApi.IsCorrect = false;
            responseApi.Message = ex.Message;
        }

        return Ok(responseApi);
    }
}
