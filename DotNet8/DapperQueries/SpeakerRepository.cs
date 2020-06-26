using ConferencePlanner.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConferencePlanner.Data
{
    class SpeakerRepository : ISpeakerRepository
    {
        Task<Speaker>
        public Task<IEnumerable<Speaker>> CountSessionPerSpeaker()
        {
            throw new NotImplementedException();
        }

        public Task<Speaker> Get(int id)
        {
            return 
        }

        public Task<IEnumerable<Session>> GetAllSessions(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(Speaker speaker)
        {
            throw new NotImplementedException();
        }
    }
}
