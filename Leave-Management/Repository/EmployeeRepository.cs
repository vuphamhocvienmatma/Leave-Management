using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Leave_Management.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Employee entity)
        {
            _db.Employees.Add(entity);
            return Save();
        }

        public bool Delete(Employee entity)
        {
            _db.Employees.Remove(entity);
            return Save();
        }

        public ICollection<Employee> FindAll()
        {
            return _db.Employees.ToList();
        }

        public Employee FindById(int id)
        {
            return _db.Employees.FirstOrDefault(o => o.Id == id.ToString());
        }

        public bool Save()
        {
            int chage = _db.SaveChanges();
            return chage > 0;
        }

        public bool Update(Employee entity)
        {
            _db.Employees.Update(entity);
            return Save();
        }
    }
}
