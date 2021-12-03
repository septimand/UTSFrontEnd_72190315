using System.Collections.Generic;
using UTS.Models;
using System.Threading.Tasks;
using UTS.Services;
using Microsoft.AspNetCore.Components;
using System.Linq;
namespace UTS.Pages
{
    public partial class EmployeePageCard
    {
        public IEnumerable<Employee> Employees {get; set;} = new List<Employee>();
        
        [Inject]
        public IEmployeeServiceCard EmployeeService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
    }
}