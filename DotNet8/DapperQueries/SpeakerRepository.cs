using ConferencePlanner.Entities;
using ConferencePlanner.Services;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferencePlanner.Data
{
    class SpeakerRepository 
    {
        private string sqlConnectionString = @"data source = DESKTOP-VP4E8HD\SQLEXPRESS; database = ConferencePlanner; integrated security = SSPI";
        
        public List<Speaker> GetAllSpeakers()
        {
            List<Speaker> speakers = new List<Speaker>();

            using var connection = new SqlConnection(sqlConnectionString);
            var allSpeakers = connection.Query<Speaker>("select * from speakers").ToList();

            return allSpeakers;            
        }

        public List<Speaker> Get(int id)
        {            
            using var connection = new SqlConnection(sqlConnectionString);
            var speaker = connection.Query<Speaker>("select * from speakers WHERE id=@Id", new { Id = id }).ToList();
            return speaker;
        }

        public List<Speaker> GetAllSessions(int id)
        {
            using var connection = new SqlConnection(sqlConnectionString);
            var sessionSpeaker = connection.Query<Speaker>("" +
                "select * from speakers " +
                "LEFT JOIN SessionSpeaker ON SessionSpeaker.SpeakerId = Speaker.Id" +
                "WHERE Speaker.Id=@Id", new { Id = id }).ToList();
            return sessionSpeaker;
        }

        public int Save(Speaker speaker)
        {            
            using var connection = new SqlConnection(sqlConnectionString);
            string sqlSpeakerInsert = @"INSERT INTO speakers(Name, Bio, Website) VALUES (@FullName, @Bio, @Website)";
            var affectedRows = connection.Execute(sqlSpeakerInsert, new { speaker.FullName, speaker.Bio, speaker.WebSite });
            return affectedRows;
        }
    }
}
