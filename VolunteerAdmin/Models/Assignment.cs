using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerAdmin.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int OpportunityID { get; set; }
        public int VolunteerID { get; set; }

        public Opportunity Opportunity { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
