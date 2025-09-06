using AutoMapper;
using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Business.Interface;
using IsPlanlamaAPI.Contract.Common.Request.PlanDtos;
using IsPlanlamaAPI.Contract.Common.Request.TeamDtos;
using IsPlanlamaAPI.Contract.Common.Request.UserDtos;
using IsPlanlamaAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace IsPlanlamaAPI.Business.Service
{
    public class TeamServices : ITeam

    {
        private readonly IGenericRepository<Team> _genericRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;


        public TeamServices(IGenericRepository<Team> genericRepository, IMapper mapper, IGenericRepository<User> userRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public void Add(CreateTeamDto team)
        {
            var teams = _mapper.Map<Team>(team);
            _genericRepository.Add(teams);

        }

        public void Delete(int id)
        {
            var delete = _genericRepository.GetById(id); 
            if (delete != null)
            {
                _genericRepository.Delete(delete);
            }
        }

        public List<ResultTeamDto> GetAll()
        {
            var teams = _genericRepository.GetAll(query => query.Include(t => t.Users));

            return teams?.Select(t => new ResultTeamDto
            {
                Id = t.Id,
                TeamName = t.TeamName,
                Users = t.Users != null
                    ? _mapper.Map<List<ResultUserDto>>(t.Users)
                    : new List<ResultUserDto>()
            }).ToList() ?? new List<ResultTeamDto>();
        }

        public ResultTeamDto GetById(int id)
        {
            var getteam = _genericRepository.GetById(id);
            return _mapper.Map<ResultTeamDto>(getteam);
        }

        public void Update(UpdateTeamDto request)
        {
            var update = _mapper.Map<Team>(request);
            _genericRepository.Update(update);
        }

        public void Update(int id, UpdateTeamDto request)
        {
            var existingTeam = _genericRepository.GetById(id);
            _mapper.Map(request, existingTeam);
            _genericRepository.Update(existingTeam);
        }

        public List<ResultUserDto> GetTeamMembers(int teamId)
        {

            var team = _genericRepository.GetAll(q => q.Include(t => t.Users))
                                         .FirstOrDefault(t => t.Id == teamId);

            if (team == null) return new List<ResultUserDto>();

            return _mapper.Map<List<ResultUserDto>>(team.Users);
        }

        public void AddUserToTeam(int teamId, int userId)
        {
            var team = _genericRepository.GetAll(q => q.Include(t => t.Users))
                                      .FirstOrDefault(t => t.Id == teamId);
            if (team == null) return;

            var user = _userRepository.GetById(userId); 
            if (user != null && !team.Users.Any(u => u.Id == userId))
            {
                team.Users.Add(user);
                _genericRepository.Update(team);
            }
        }

        public void RemoveUserFromTeam(int teamId, int userId)
        {
            var team = _genericRepository.GetAll(q => q.Include(t => t.Users))
                                      .FirstOrDefault(t => t.Id == teamId);
            if (team == null) return;

            var user = team.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                team.Users.Remove(user);
                _genericRepository.Update(team);
            }
        }
    }
}
