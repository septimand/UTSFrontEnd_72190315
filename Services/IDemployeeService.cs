using System.Collections.Generic;
using System.Threading.Tasks;
using UTS.Models;

namespace UTS.Services
{
    public interface IDemployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(int id, Employee employee);
    }
}