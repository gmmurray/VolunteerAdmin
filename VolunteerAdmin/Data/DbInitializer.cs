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
                new Volunteer{FirstName="James",LastName="Jameson",Username="jjameson",Password="jj123",HomePhone="1111111111",CellPhone="2222222222",WorkPhone="3333333333",Address="101 Address Road",Email="jjameson@james.com",Education="Bachelors",
                    Licenses="ABC,MD",Centers="North",Skills="Leadership, Positivity",AvailableTimes="10:00AM-12:00PM MWF",EmergencyName ="Tom",EmergencyHomePhone="1111111111",EmergencyWorkPhone="2222222222",EmergencyEmail="tommy@aol.com",EmergencyAddress="123 Road Lane",DLCopyOnFile =true,SSCopyOnFile =true,Approved=true},
                new Volunteer{FirstName="John",LastName="Johnson",Username="jjohnson",Password="jj123",HomePhone="1111111111",CellPhone="2222222222",WorkPhone="3333333333",Address="101 Address Road",Email="jjohnson@john.com",Education="Masters",
                    Licenses="ABC,MD",Centers="Westside",Skills="Programming, Being Too Nice",AvailableTimes="2:00PM-8:00PM MWF",EmergencyName ="James",EmergencyHomePhone="1111111111",EmergencyWorkPhone="2222222222",EmergencyEmail="jimmy@aol.com",EmergencyAddress="123 Road Lane",DLCopyOnFile =true,SSCopyOnFile =true,Approved=false}
            };
            foreach (Volunteer v in volunteers)
            {
                context.Volunteers.Add(v);
            }
            context.SaveChanges();

            //var availableTimes = new AvailableTime[]
            //{
            //    new AvailableTime{Time=DateTime.Parse("2:00PM")},
            //    new AvailableTime{Time=DateTime.Parse("6:00AM")},
            //    new AvailableTime{Time=DateTime.Parse("10:00AM")}
            //};
            //foreach (AvailableTime a in availableTimes)
            //{
            //    context.AvailableTimes.Add(a);
            //}
            //context.SaveChanges();

            //var centers = new Center[]
            //{
            //    new Center{CenterName="North"},
            //    new Center{CenterName="West"},
            //    new Center{CenterName="Southside"}
            //};
            //foreach (Center c in centers)
            //{
            //    context.Centers.Add(c);
            //}
            //context.SaveChanges();

            //var licenses = new License[]
            //{
            //    new License{LicenseName="ABC"},
            //    new License{LicenseName="DEF"},
            //    new License{LicenseName="GHI"}
            //};
            //foreach (License l in licenses)
            //{
            //    context.Licenses.Add(l);
            //}
            //context.SaveChanges();

            //var skills = new Skill[]
            //{
            //    new Skill{SkillName="Leadership"},
            //    new Skill{SkillName="Organization"},
            //    new Skill{SkillName="Positivity"}
            //};
            //foreach (Skill s in skills)
            //{
            //    context.Skills.Add(s);
            //}
            //context.SaveChanges();

            var Opportunities = new Opportunity[]
            {
                new Opportunity{CenterID=1, OpportunityName="Feed the homeless", Description="Serve food to the local Homeless population", OpportunityDate=DateTime.Parse("2019-10-23")},
                new Opportunity{CenterID=2, OpportunityName="Give Blood", Description="Everyone's got it, everyone needs it", OpportunityDate=DateTime.Parse("2020-01-13")},
            };
            foreach(Opportunity o in Opportunities)
            {
                context.Opportunities.Add(o);
            }
            context.SaveChanges();

            var Assignments = new Assignment[]
            {
                new Assignment{OpportunityID=1, VolunteerID=1},
                new Assignment{OpportunityID=2, VolunteerID=2}
            };
            foreach(Assignment a in Assignments)
            {
                context.Assignments.Add(a);
            }
            context.SaveChanges();
        }
    }
}
