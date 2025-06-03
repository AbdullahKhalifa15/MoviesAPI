using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CourseService
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(long ? id);
        void InsertCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(long id);
        void Remove(Course course);
        void SaveChanges();
    }
}
