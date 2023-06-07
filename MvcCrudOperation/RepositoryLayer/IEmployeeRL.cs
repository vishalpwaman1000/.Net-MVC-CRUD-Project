using MvcCrudOperation.Models;

namespace MvcCrudOperation.RepositoryLayer
{
    public interface IEmployeeRL
    {
        Task Add(AddEmployeeViewModel request);
        List<Employee> GetList();
        Employee GetById(Guid id);
        Task Edit(Employee employee, Employee request);
        Task Delete(Employee request);
    }
}
