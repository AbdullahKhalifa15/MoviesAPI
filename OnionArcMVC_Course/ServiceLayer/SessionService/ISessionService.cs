using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.SessionService
{
    public interface ISessionService
    {
        IEnumerable<Session> GetSessions();
        Session GetSession(long id);
        void InsertSession(Session user);
        void UpdateSession(Session user);
        void DeleteSession(long id);
    }
}
