using DomainLayer;
using DomainLayer.Models;
using RepositoryLayer.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.UserServices
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IRepositoryUser<ApplicationUser> _applicationUser;

        public ApplicationUserService(IRepositoryUser<ApplicationUser> applicationUser)
        {
            this._applicationUser = applicationUser;

        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _applicationUser.GetAll();
        }

        public ApplicationUser GetUser(string id)
        {
            return _applicationUser.Get(id);
        }

        public void InsertUser(ApplicationUser user)
        {
            _applicationUser.Insert(user);
        }
        public void UpdateUser(ApplicationUser user)
        {
            _applicationUser.Update(user);
        }

        public void DeleteUser(string id)
        {
            ApplicationUser userProfile = _applicationUser.Get(id);
            _applicationUser.Remove(userProfile);
            _applicationUser.SaveChanges();
        }
    }
}
