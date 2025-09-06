using AutoMapper;
using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Business.Interface;
using IsPlanlamaAPI.Contract.Common.Request.TeamMemberDtos;
using IsPlanlamaAPI.Core.Entities;
using IsPlanlamaAPI.Data.Repository;

namespace IsPlanlamaAPI.Business.Service
{
    public class TeamMemberServices : ITeamMember
    {
        private readonly IGenericRepository<TeamMember> _genericrepository;
        private readonly IMapper _mapper;

        public TeamMemberServices(IGenericRepository<TeamMember> genericrepository, IMapper mapper)
        {
            _genericrepository = genericrepository;
            _mapper = mapper;
        }

        public void Add(CreateTeamMemberDto teamMember)
        {
            var teamMembers = _mapper.Map<TeamMember>(teamMember);
            _genericrepository.Add(teamMembers);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ResultTeamMemberDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ResultTeamMemberDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UpdateTeamMemberDto request)
        {
            throw new NotImplementedException();
        }
    }
}
