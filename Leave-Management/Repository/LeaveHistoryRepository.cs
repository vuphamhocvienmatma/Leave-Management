using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistorys.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistorys.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            return _db.LeaveHistorys.ToList();
        }

        public LeaveHistory FindById(int id)
        {
            return _db.LeaveHistorys.FirstOrDefault(o => o.Id == id);
        }

        public bool Save()
        {
            int chage = _db.SaveChanges();
            return chage > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistorys.Update(entity);
            return Save();
        }
    }
}
