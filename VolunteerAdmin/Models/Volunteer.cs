using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VolunteerAdmin.Models
{
    public class Volunteer
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Za-z]+$")]
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [Display(Name = "Home Phone")]
        [RegularExpression(@"^[0-9]+-[0-9]+-[0-9]+$")]
        public string HomePhone { get; set; }

        [Display(Name = "Cell Phone")]
        [RegularExpression(@"^[0-9]+-[0-9]+-[0-9]+$")]
        public string CellPhone { get; set; }

        [Display(Name = "Work Phone")]
        [RegularExpression(@"^[0-9]+-[0-9]+-[0-9]+$")]
        public string WorkPhone { get; set; }
        public string Address { get; set; }

        [RegularExpression(@"^[A-Za-z]+._*(0-9)?@[a-z]+.[a-z]+$")]
        public string Email { get; set; }
        public string Education { get; set; }

        [Display(Name = "Emergency Contact Name")]
        [RegularExpression(@"^[A-Za-z]+\s+[A-Za-z]+\s+[A-Za-z]+.")]
        public string EmergencyName { get; set; }

        [Display(Name = "Emergency Contact Home Phone")]
        [RegularExpression(@"^[0-9]+-[0-9]+-[0-9]+$")]
        public string EmergencyHomePhone { get; set; }

        [Display(Name = "Emergency Contact Work Phone")]
        [RegularExpression(@"^[0-9]+-[0-9]+-[0-9]+$")]
        public string EmergencyWorkPhone { get; set; }

        [Display(Name = "Emergency Contact Email Address")]
        [RegularExpression(@"^[A-Za-z]+._*(0-9)?@[a-z]+.[a-z]+$")]
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
