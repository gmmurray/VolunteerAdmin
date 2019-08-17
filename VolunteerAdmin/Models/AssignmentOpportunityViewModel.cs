using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerAdmin.Models
{
    public class AssignmentOpportunityViewModel
    {
        public List<Volunteer> Volunteers { get; set; }
        public Assignment Assignment { get; set; }
        public Opportunity Opportunity { get; set; }
    }
}
