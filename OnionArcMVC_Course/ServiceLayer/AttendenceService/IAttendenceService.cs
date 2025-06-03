using DomainLayer;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AttendenceService
{
    public interface IAttendenceService
    {
        IEnumerable<Attendance> GetAttendences();
        Attendance GetAttendence(long id);
        void InsertAttendence(Attendance attendence);
        void UpdateAttendence(Attendance attendence);
        void DeleteAttendence(long id);
        void SaveChanges();
    }
}
