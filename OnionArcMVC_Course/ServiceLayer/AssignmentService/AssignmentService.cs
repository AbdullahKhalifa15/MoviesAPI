using DomainLayer;
using DomainLayer.Models;
using RepositoryLayer.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AssignmentService
{
    public class AssignmentService:IAssignmentService
    {

        private readonly IRepository<Assigment> _assignment;

        public AssignmentService(IRepository<Assigment> Assignment)
        {
            this._assignment = Assignment;

        }

        public IEnumerable<Assigment> GetAssignments()

        {
            return _assignment.GetAll();
        }

        public Assigment GetAssignment(long id)
        {
            return _assignment.Get(id);
        }

        public void InsertAssignment(Assigment Assignment)
        {
            _assignment.Insert(Assignment);
        }
        public void UpdateAssignment(Assigment Assignment)
        {
            _assignment.Update(Assignment);
        }

        public void DeleteAssignment(long id)
        {
            Assigment userApplication = _assignment.Get(id);
            _assignment.Remove(userApplication);
            _assignment.SaveChanges();
        }
    }
}
