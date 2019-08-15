using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerAdmin.Models
{
    public class OppReqSkill
    {
        public int OppReqSkillID { get; set; }
        public int OpportunityID { get; set; }
        public int SkillID { get; set; }

        public Opportunity Opportunity { get; set; }
        public Skill Skill { get; set; }
    }
}
