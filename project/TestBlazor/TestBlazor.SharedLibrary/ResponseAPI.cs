using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazor.SharedLibrary;

public class ResponseAPI<T>
{
    public HttpStatusCode StatusCode { get; set; }

    public bool IsCorrect { get; set; }

    public T? Value { get; set; }
    
    public string? Message { get; set; }
}
