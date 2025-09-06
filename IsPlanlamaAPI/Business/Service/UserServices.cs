using AutoMapper;
using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Business.Interface;
using IsPlanlamaAPI.Contract.Common.Request.TeamDtos;
using IsPlanlamaAPI.Contract.Common.Request.UserDtos;
using IsPlanlamaAPI.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsPlanlamaAPI.Business.Service
{
    public class UserServices : IUser
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IGenericRepository<Team> _teamRepository;
        private readonly IGenericRepository<Plan> _planRepository;
        private readonly IMapper _mapper;

        public UserServices(IGenericRepository<User> genericRepository, IMapper mapper, IGenericRepository<Team> teamRepository, IGenericRepository<Plan> planRepository)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _teamRepository = teamRepository;
            _planRepository=  planRepository;
        }

        public void Add(CreateUserDto user)
        {
            var entity = _mapper.Map<User>(user);
            _genericRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var delete = _genericRepository.GetById(id);
            _genericRepository.Delete(delete);
        }

        public List<ResultUserDto> GetAll()
        {
            var result = _genericRepository.GetAll();
            return _mapper.Map<List<ResultUserDto>>(result);
        }

        public ResultUserDto GetById(int id)
        {
            var getuser = _genericRepository.GetById(id);
            return _mapper.Map<ResultUserDto>(getuser);
        }

        public void Update(UpdateUserDto request)
        {
            var update = _mapper.Map<User>(request);
            _genericRepository.Update(update);
        }

        public List<Team> GetAllTeams()
        {
            return _teamRepository.GetAll();
        }

        public void AddToTeam(int userId, int teamId)
        {
            var user = _genericRepository.GetById(userId);       
            user.TeamId = teamId;
            _genericRepository.Update(user);
        }

       
        

    }
}
