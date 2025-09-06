using IsPlanlamaAPI.Contract.Common.Request;
using IsPlanlamaAPI.Contract.Common.Request.TeamDtos;
using IsPlanlamaAPI.Contract.Common.Request.UserDtos;

using IsPlanlamaAPI.Core.Entities;

namespace IsPlanlamaAPI.Business.Abstract
{
    public interface IUser
    {
        void Add(CreateUserDto user);


        List<ResultUserDto> GetAll();

        ResultUserDto GetById(int id);

        void Update(UpdateUserDto request);

        void Delete(int id);

        List<Team> GetAllTeams();

        void AddToTeam(int userId, int teamId);
      

    }
}
