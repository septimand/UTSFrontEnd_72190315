using System.Collections.Generic;
using System.Threading.Tasks;
using UTS.Models;

namespace UTS.Services
{
    public interface IEmployeeServiceCard
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(int id, Employee employee);
        Task Delete(int id);
    }
}