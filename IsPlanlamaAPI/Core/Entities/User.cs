namespace IsPlanlamaAPI.Core.Entities
{
    public class User: BaseEntity
    {
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public int? TeamId { get; set; }
     
        public List<TeamMember> TeamMembers { get; set; }
        public Team? Team { get; set; }
    }
}
