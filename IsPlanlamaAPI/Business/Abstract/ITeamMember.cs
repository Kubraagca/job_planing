
using IsPlanlamaAPI.Contract.Common.Request.TeamDtos;
using IsPlanlamaAPI.Contract.Common.Request.TeamMemberDtos;

using IsPlanlamaAPI.Core.Entities;

namespace IsPlanlamaAPI.Business.Abstract
{
    public interface ITeamMember
    {
        void Add(CreateTeamMemberDto teamMember);


        List<ResultTeamMemberDto> GetAll();

        ResultTeamMemberDto GetById(int id);

        void Update(UpdateTeamMemberDto request);

        void Delete(int id);
    }
}
