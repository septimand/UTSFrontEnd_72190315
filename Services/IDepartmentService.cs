using System.Collections.Generic;
using System.Threading.Tasks;
using UTS.Models;
namespace UTS.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
    }
}