using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerAdmin.Models;

namespace VolunteerAdmin.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AdminContext context)
        {
            context.Database.EnsureCreated();

            // Look for existing volunteers
            if (context.Volunteers.Any())
            {
                return;
            }

            var volunteers = new Volunteer[]
            {
                new Volunteer{FirstName="James",LastName="Jameson",Username="jjameson",Password="jj123",HomePhone="1111111111",CellPhone="2222222222",WorkPhone="3333333333",Address="101 Address Road",Email="jjameson@james.com",Education="Bachelors",EmergencyName="Tom",EmergencyHomePhone="1111111111",EmergencyWorkPhone="2222222222",EmergencyEmail="tommy@aol.com",EmergencyAddress="123 Road Lane",DLCopyOnFile =true,SSCopyOnFile =true,Approved=true},
                new Volunteer{FirstName="John",LastName="Johnson",Username="jjohnson",Password="jj123",HomePhone="1111111111",CellPhone="2222222222",WorkPhone="3333333333",Address="101 Address Road",Email="jjohnson@john.com",Education="Masters",EmergencyName="James",EmergencyHomePhone="1111111111",EmergencyWorkPhone="2222222222",EmergencyEmail="jimmy@aol.com",EmergencyAddress="123 Road Lane",DLCopyOnFile =true,SSCopyOnFile =true,Approved=false}
            };
            foreach (Volunteer v in volunteers)
            {
                context.Volunteers.Add(v);
            }
            context.SaveChanges();

            var availableTimes = new AvailableTime[]
            {
                new AvailableTime{Time=DateTime.Parse("2:00PM")},
                new AvailableTime{Time=DateTime.Parse("6:00AM")},
                new AvailableTime{Time=DateTime.Parse("10:00AM")}
            };
            foreach (AvailableTime a in availableTimes)
            {
                context.AvailableTimes.Add(a);
            }
            context.SaveChanges();

            var centers = new Center[]
            {
                new Center{CenterName="North"},
                new Center{CenterName="West"},
                new Center{CenterName="Southside"}
            };
            foreach (Center c in centers)
            {
                context.Centers.Add(c);
            }
            context.SaveChanges();

            var licenses = new License[]
            {
                new License{LicenseName="ABC"},
                new License{LicenseName="DEF"},
                new License{LicenseName="GHI"}
            };
            foreach (License l in licenses)
            {
                context.Licenses.Add(l);
            }
            context.SaveChanges();

            var skills = new Skill[]
            {
                new Skill{SkillName="Leadership"},
                new Skill{SkillName="Organization"},
                new Skill{SkillName="Positivity"}
            };
            foreach (Skill s in skills)
            {
                context.Skills.Add(s);
            }
            context.SaveChanges();
        }
    }
}
