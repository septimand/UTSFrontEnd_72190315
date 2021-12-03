using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using UTS.Models;
using UTS.Services;

namespace UTS.Pages
{
    public partial class DetailDepartment
    {
        [Parameter]
        public string id { get; set; }
        public Department Department { get; set; } = new Department();
        
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        

        protected override async Task OnInitializedAsync()
        {
            id = id ?? "1";
            Department = await DepartmentService.GetById(int.Parse(id));
        }
    }
}