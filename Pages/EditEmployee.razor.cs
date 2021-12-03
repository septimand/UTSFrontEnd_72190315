using System.Collections.Generic;
using UTS.Models;
using System.Threading.Tasks;
using UTS.Services;
using Microsoft.AspNetCore.Components;
using System.Linq;
namespace UTS.Pages
{
    public partial class EditEmployee
    {        
        [Parameter]
        public string id { get; set; }
        public Employee Employee { get; set; } = new Employee();

        public List<Department> Departments { get; set; } = new List<Department>();

        [Inject]
        public IEmployeeServiceCard EmployeeServiceCard {get;set;}

        [Inject]    
        public NavigationManager NavigationManager{ get; set; }

        [Inject]
        public IDepartmentService DepartmentService{get;set;}
    
        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeServiceCard.GetEmployee(int.Parse(id));
            Departments = (await DepartmentService.GetAll()).ToList();
        }
        protected async Task HandleValidSubmit()
        {
            Employee.PhotoPath = "image/nophoto.jpg";
            var result = await EmployeeServiceCard.Update(int.Parse(id),Employee);
            NavigationManager.NavigateTo("/employeecard");
        }
    }
}