using IsPlanlamaAPI.Contract.Common.Request.UserDtos;

namespace IsPlanlamaAPI.Contract.Common.Request.TeamDtos
{
    public class ResultTeamDto

    {   public int Id {  get; set; }
        public string? TeamName { get; set; }
        public string? Status { get; set; }
        public List<ResultUserDto> Users { get; set; }
        public int MemberCount { get; set; }
    }
}
