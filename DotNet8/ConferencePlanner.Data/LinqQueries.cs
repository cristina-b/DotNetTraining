using ConferencePlanner.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferencePlanner.Data
{
    class LinqQueries
    {
        internal ApplicationDbContext context;

        public LinqQueries(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Session> getSessionByTitle(string searchedKey)
        {

            var query = context.Sessions.Where(a => a.Title.ToLower().Contains(searchedKey));

            return query.ToList();            
        }

        /*public List<Session> groupSessionsByUser()
        {
            //return context.Sessions.GroupBy(s => s.TrackId).ToList();            
        }*/
    }
}
