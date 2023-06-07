using MvcCrudOperation.Data;
using MvcCrudOperation.Models;

namespace MvcCrudOperation.RepositoryLayer
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRL(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Add(AddEmployeeViewModel request)
        {
            _dbContext.Employee.Add(
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Email = request.Email,
                    Salary = request.Salary,
                    Department = request.Department,
                    DateOfBirth = request.DateOfBirth
                });
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(Employee request)
        {
            _dbContext.Employee.Remove(request);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Edit(Employee employee, Employee request)
        {
            employee.Id = request.Id;
            employee.Name = request.Name;
            employee.Email = request.Email;
            employee.Salary = request.Salary;
            employee.Department = request.Department;
            employee.DateOfBirth = request.DateOfBirth;
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Employee GetById(Guid id)
        {
            return _dbContext.Employee.Where(X => X.Id == id).FirstOrDefault();

        }

        public List<Employee> GetList()
        {
            return _dbContext.Employee.ToList();
        }
    }
}
