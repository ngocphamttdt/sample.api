using System;
using System.Collections.Generic;
using System.Text;

namespace WTPSample.Service.DTOs
{
    public class ResultEmployee
    {
        public int Count { get; set; }
        public List<EmployeeDto> Employees { get; set; }
    }
}
