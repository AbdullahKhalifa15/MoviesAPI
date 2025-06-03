using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.RepositoryPattern;
using ServiceLayer.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _course;

        public CourseService(IRepository<Course> course)
        {
            this._course = course;

        }

        public IEnumerable<Course> GetCourses()
      
        {
            return _course.GetAll();
        }

        public Course GetCourse(long ? id)
        {
            return _course.Get(id);
        }

        public void InsertCourse(Course course)
        {
            _course.Insert(course);
        }
        public void UpdateCourse(Course course)
        {
            _course.Update(course);
        }

        public void DeleteCourse(long id)
        {
            Course userApplication = _course.Get(id);
            _course.Remove(userApplication);
            _course.SaveChanges();
        }
        public void Remove(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("entity");
            }
            _course.Remove(course);
        }
        public void SaveChanges()
        {
            _course.SaveChanges();
        }
    }

}
