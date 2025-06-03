using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.AssignmentService
{
    public interface IAssignmentService
    {
        IEnumerable<Assigment> GetAssignments();
        Assigment GetAssignment(long id);
        void InsertAssignment(Assigment assignment);
        void UpdateAssignment(Assigment assignment);
        void DeleteAssignment(long id);
    }
}
