using DomainLayer.Models;
using RepositoryLayer.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly IRepository<Session> _session;

        public SessionService(IRepository<Session> session)
        {
            this._session = session;
        }
        public IEnumerable<Session> GetSessions()

        {
            return _session.GetAll();
        }

        public Session GetSession(long id)
        {
            return _session.Get(id);
        }

        public void InsertSession(Session Session)
        {
            _session.Insert(Session);
        }
        public void UpdateSession(Session Session)
        {
            _session.Update(Session);
        }

        public void DeleteSession(long id)
        {
            Session userApplication = _session.Get(id);
            _session.Remove(userApplication);
            _session.SaveChanges();
        }
    }
}
