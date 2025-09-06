using IsPlanlamaAPI.Contract.Common.Request;
using IsPlanlamaAPI.Contract.Common.Request.UserDtos;
using IsPlanlamaAPI.Contract.Common.Request.TeamDtos;

using IsPlanlamaAPI.Core.Entities;

namespace IsPlanlamaAPI.Business.Abstract
{
    public interface ITeam
    {
        void Add(CreateTeamDto team);


        List<ResultTeamDto> GetAll();

        ResultTeamDto GetById(int id);

        void Update(int id, UpdateTeamDto request);

        void Delete(int id);
        void Update(UpdateTeamDto update);
        List<ResultUserDto> GetTeamMembers(int teamId);

        void AddUserToTeam(int teamId, int userId);
        void RemoveUserFromTeam(int teamId, int userId);
    }
}
