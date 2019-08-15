using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerAdmin.Models
{
    public class Opportunity
    {
        public int OpportunityID { get; set; }
        public int CenterID {get; set;}

        public string Description { get; set; }
        public string OpportunityName { get; set; }
        public DateTime OpportunityDate { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<OppReqSkill> OppReqSkills { get; set; }

        //We can put a nullable list or icollection here for required skills,
        //didn't want to make things too complicated yet.
    }
}
