using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using UTS.Models;
using UTS.Services;

namespace UTS.Pages
{
    public partial class DetailEmployeeCard
    {
        [Parameter]
        public string id { get; set; }
        public Employee Employee { get; set; } = new Employee();
        [Inject]
        public IEmployeeServiceCard EmployeeService { get; set; }
        public string Coordinates {get; set;}
        protected void Mouse_Move(MouseEventArgs e){
            Coordinates = $"X = {e.ClientX}, Y = {e.ClientY}";
        }

        public string ButtonText { get; set; } = "Hide Footer";

        public string CssClass { get; set; } = null;
        protected void Button_Click(){
         if(ButtonText == "Hide Footer"){
             ButtonText = "Show Footer";
             CssClass = "Hide Footer";
         }   else{
             CssClass = null;
             ButtonText = "Hide Footer";
         }
        }
        protected override async Task OnInitializedAsync()
        {
            id = id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(id));
        }
    }
}