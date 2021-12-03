using System.Collections.Generic;
using UTS.Models;
using System.Threading.Tasks;
using UTS.Services;
using Microsoft.AspNetCore.Components;
using System.Linq;
namespace UTS.Pages
{
    public partial class DepartmentPage
    {
        public List<Department> Departments { get; set; } = new List<Department>();
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Departments = (await DepartmentService.GetAll()).ToList();
        }
    }
}