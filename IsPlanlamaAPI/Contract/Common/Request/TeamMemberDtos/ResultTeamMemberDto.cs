using IsPlanlamaAPI.Core.Entities;

namespace IsPlanlamaAPI.Contract.Common.Request.TeamMemberDtos
{
    public class ResultTeamMemberDto
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
