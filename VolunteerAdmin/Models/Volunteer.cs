using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VolunteerAdmin.Models
{
    public class Volunteer
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [Display(Name = "Home Phone")]
        public string HomePhone { get; set; }

        [Display(Name = "Cell Phone")]
        public string CellPhone { get; set; }

        [Display(Name = "Work Phone")]
        public string WorkPhone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }

        [Display(Name = "Emergency Contact Name")]
        public string EmergencyName { get; set; }

        [Display(Name = "Emergency Contact Home Phone")]
        public string EmergencyHomePhone { get; set; }

        [Display(Name = "Emergency Contact Work Phone")]
        public string EmergencyWorkPhone { get; set; }

        [Display(Name = "Emergency Contact Email Address")]
        public string EmergencyEmail { get; set; }

        [Display(Name = "Emergency Contact Address")]
        public string EmergencyAddress { get; set; }
        
        [Display(Name = "Driver's License Copy on File (Y/N)")]
        public bool DLCopyOnFile { get; set; }

        [Display(Name = "Social Security Copy on File (Y/N)")]
        public bool SSCopyOnFile { get; set; }

        [Display(Name = "Approval Status")]
        public bool? Approved { get; set; }

        public ICollection<License> Licenses { get; set; }
        public ICollection<Center> Centers { get; set; }
        public ICollection<VolunteerSkill> VolunteerSkills { get; set; }
        public ICollection<AvailableTime> AvailableTimes { get; set; }
        public ICollection<Assignment> Assignments { get; set; }


    }
}
