using System;
using System.Linq;
using ConferencePlanner.Data;
using ConferencePlanner.Data.Entities;
using ConferencePlanner.Entities;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace ConferencePlanner.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var context = new ApplicationDbContext();

            Ex03.Run(context);            
        }
    }

    internal class Ex01
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // write a simple query to validate ApplicationDbContext

            var attendee = context.Attendees.FirstOrDefault();

            Console.WriteLine(attendee.FirstName);

        }
    }

    internal class Ex02
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // on Tracks table, add PHP, C# tracks with a seed
            // update ApplicationDbContext to run a seed
            var attendee = context.Attendees.FirstOrDefault();

            var newAttendee = context.Attendees.Add(new Data.Entities.Attendee { EmailAddress = "test@conferenceplanner.com" });

            context.Tracks.Add(new Data.Entities.Track());
            context.SaveChanges();
        }

    }
}

    internal class Ex03
    {
        public static void Run(ApplicationDbContext context)
        {
        // Todo
        // on Attendee model, add a new property, date of birth
        // add a migration, run the migration
        // insert then read a Attendee
        var attendee = context.Attendees.FirstOrDefault();

        var newAttendee = context.Attendees.Add(
            new ConferencePlanner.Data.Entities.Attendee { 
                EmailAddress = "new.attendee@conferenceplanner.com",
                FirstName = "New",
                LastName = "Attendee",
                DateOfBirth = Convert.ToDateTime("1980-10-10"),
                UserName = "new.attendee"
            });
        
        context.SaveChanges();
    }
    }

    internal class Ex04
    {
        public static void Run(ApplicationDbContext context)
        {
        // Todo
        // have a look on ConferencePlanner.Services and ISessionRepository
        // implement the repository inside the Data project
        // use the repository here in order to read 
        var repo = new Repository<ConferencePlanner.Data.Entities.Attendee>(context);
        repo.Get();
    }
    }

    internal class Ex05
    {
        // todo
        // rename the Speaker.Name to Speaker.FullName
        // you should add a migration
    }

    internal class Ex06
    {
        public static void Run(ApplicationDbContext context)
        {
        // todo
        // all Sessions that title contains ".NET"

            var sessions = context.Sessions.Where(s => s.Title.Contains(".NET")).ToList();
        // number of sessions for each speaker

            var session = context.SessionSpeaker
                .GroupBy(s => s.SpeakerId)
                .Select(s => new { id = s.Key, Count = s.Count() })
                .ToList();
        // number of tracks per session
            var sessionTrack = context.Sessions
                .GroupBy(s => s.TrackId)
                .Select(s => new { id = s.Key, Count = s.Count() })
                .ToList();
        // all tracks for each session
        var sessionTracks = context.Sessions
                .GroupBy(s => s.TrackId)
                .ToList();
        }
    }

    internal class Ex07
    {
        public static void Run(ApplicationDbContext context)
        {
            // todo
            // get all sessions for one speaker
            var speakers = context.Speakers.Include(s => s.SessionSpeakers).ToList();
        }
    }

    internal class Ex08
    {
        public static void Run()
        {
            // todo
            // create a separate project for dapper
            // implement the ISpeakerRepository using dapper
        }
    }

    internal class Ex09
    {
        public static void Run()
        {
            // todo
            // create view
            /*
               create view AllSessionsAndSpeakersView as
               select ses.Title, sp.Name, ses.StartTime from Sessions ses
               join SessionSpeaker ss on ses.Id = ss.SessionId
               join Speakers sp on sp.Id = ss.SpeakerId
            */

            // use the view from Dapper
            // display all information at console
        }
    }

    internal class Ex10
    {
        public static void Run()
        {
            // todo
            // use Dapper Plus
            // bulk insert 10 attendees
        }
    }
}
