using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerAdmin.Models
{
    public class VolunteerSkill
    {
        public int VolunteerSkillID { get; set; }
        public int SkillID { get; set; }
        public int VolunteerID { get; set; }

        public Volunteer Volunteer { get; set; }
        public Skill Skill { get; set; }
    }
}
