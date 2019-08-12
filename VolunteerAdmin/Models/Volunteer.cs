using System.Collections.Generic;

namespace VolunteerAdmin.Models
{
    public class Volunteer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string WorkPhone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyHomePhone { get; set; }
        public string EmergencyWorkPhone { get; set; }
        public string EmergencyEmail { get; set; }
        public string EmergencyAddress { get; set; }
        public bool DLCopyOnFile { get; set; }
        public bool SSCopyOnFile { get; set; }
        public bool Approved { get; set; }

        public ICollection<License> Licenses { get; set; }
        public ICollection<Center> Centers { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<AvailableTime> AvailableTimes { get; set; }


    }
}
