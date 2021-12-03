using System.Collections.Generic;
using UTS.Models;
using System.Threading.Tasks;
using UTS.Services;
using Microsoft.AspNetCore.Components;
using System.Linq;
namespace UTS.Pages
{
    public partial class EmployeePage
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        [Inject]
        public IDemployeeService EmployeeService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetAll()).ToList();
        }
    }
}