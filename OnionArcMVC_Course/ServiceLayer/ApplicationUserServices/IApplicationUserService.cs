using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserServices
{
    public interface IApplicationUserService 
    {
        IEnumerable<ApplicationUser> GetUsers();
        ApplicationUser GetUser(string id);
        void InsertUser(ApplicationUser user);
        void UpdateUser(ApplicationUser user);
        void DeleteUser(string id);

    }
}
