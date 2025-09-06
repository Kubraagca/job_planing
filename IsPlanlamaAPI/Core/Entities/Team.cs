using System.ComponentModel.DataAnnotations;

namespace IsPlanlamaAPI.Core.Entities
{
    public class Team : BaseEntity
    {
      
        public string TeamName { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
        public List<Plan> Plans { get; set; }
        public List<User> Users { get; set; }
       // public virtual ICollection<User> Users { get; set; } = new List<User>();



    }
}
