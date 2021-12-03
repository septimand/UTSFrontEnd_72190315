using System.Collections.Generic;
using UTS.Models;
using System.Threading.Tasks;
using UTS.Services;
using Microsoft.AspNetCore.Components;
using System.Linq;
namespace UTS.Pages
{
    public partial class AddEmployee
    {        
        public Employee Employee { get; set; } = new Employee();

        public List<Department> Departments { get; set; } = new List<Department>();

        [Inject]
        public IDemployeeService EmployeeServiceCard {get;set;}

        [Inject]    
        public NavigationManager NavigationManager{ get; set; }

        [Inject]
        public IDepartmentService DepartmentService{get;set;}
    
        protected override async Task OnInitializedAsync()
        {
            Departments = (await DepartmentService.GetAll()).ToList();
        }
        protected async Task HandleValidSubmit()
        {
            Employee.PhotoPath = "/image/nophoto.jpg";
            var result = await EmployeeServiceCard.Add(Employee);
            NavigationManager.NavigateTo("/employeecard");
        }
    }
}