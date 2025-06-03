using DomainLayer.Models;
using RepositoryLayer.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer;

namespace ServiceLayer.AttendenceService
{
    public class AttendenceService : IAttendenceService
    {

        private readonly IRepository<Attendance> _attendence;

        public AttendenceService(IRepository<Attendance> attendence)
        {
            this._attendence = attendence;

        }

        public IEnumerable<Attendance> GetAttendences()

        {
            return _attendence.GetAll();
        }

        public Attendance GetAttendence(long id)
        {
            return _attendence.Get(id);
        }

        public void InsertAttendence(Attendance Attendence)
        {
            _attendence.Insert(Attendence);
        }
        public void UpdateAttendence(Attendance Attendence)
        {
            _attendence.Update(Attendence);
        }

        public void DeleteAttendence(long id)
        {
            Attendance userApplication = _attendence.Get(id);
            _attendence.Remove(userApplication);
            _attendence.SaveChanges();
        }
        public void SaveChanges()
        {
            _attendence.SaveChanges();
        }
    }
}
