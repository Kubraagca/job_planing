using AutoMapper;
using IsPlanlamaAPI.Business.Abstract;
using IsPlanlamaAPI.Business.Interface;

using IsPlanlamaAPI.Contract.Common.Request.PlanDtos;

using IsPlanlamaAPI.Core.Entities;
using IsPlanlamaAPI.Data.Repository;

namespace IsPlanlamaAPI.Business.Service
{
    public class PlanServices : IPlan
    {
        private readonly IGenericRepository<Plan> _planRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Team> _teamRepository;
        private readonly IMapper _mapper;

        public PlanServices(IGenericRepository<Plan> planRepository, IMapper mapper, IGenericRepository<User> userRepository, IGenericRepository<Team> teamRepository)
        {
            _planRepository = planRepository;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public void AddPlan(CreatePlanDtos plan)
        {
            if (plan == null)
                throw new ArgumentNullException(nameof(plan));

            var entity = _mapper.Map<Plan>(plan);

            if (string.IsNullOrEmpty(entity.Status))
                entity.Status = "Planlandi";

            if (entity.IsGunu == DateTime.MinValue)
                entity.IsGunu = DateTime.Now;

            _planRepository.Add(entity);


        }



        public void Delete(int id)
        {
            var delete = _planRepository.GetById(id);
            _planRepository.Delete(delete);

        }

        public List<ResultPlanDto> GetAll()
        {
            var result = _planRepository.GetAll();
            return _mapper.Map<List<ResultPlanDto>>(result);
        }

        public GetPlanDto GetById(int id)
        {
            var getplan = _planRepository.GetById(id);
            return _mapper.Map<GetPlanDto>(getplan);
        }

        public void Update(UpdatePlanDtos request)
        {
            var existingPlan = _planRepository.GetById(request.Id);
            if (existingPlan == null)
                throw new Exception("Plan bulunamadı");


            _mapper.Map(request, existingPlan);

            _planRepository.Update(existingPlan);
        }

        public void UpdateStatus(int planId, string newStatus, string? revizyonAciklama = null)
        {
            var plan = _planRepository.GetById(planId);
            if (plan == null)
                throw new Exception("Plan bulunamadı");

            plan.Status = newStatus;


            if (!string.IsNullOrEmpty(revizyonAciklama))
                plan.RevizyonAciklama = revizyonAciklama;

            _planRepository.Update(plan);
        }
        public List<ResultPlanDto> GetFilteredPlans(int? TeamId, int? UserId)
        {
            var plans = _planRepository.GetAll();


            if (TeamId.HasValue)
                plans = plans.Where(p => p.TeamId == TeamId.Value).ToList();

            if (UserId.HasValue)
                plans = plans.Where(p => p.AssignedUserId == UserId.Value).ToList();


            var result = _mapper.Map<List<ResultPlanDto>>(plans);


            var users = _userRepository.GetAll() ?? new List<User>();
            var teams = _teamRepository.GetAll() ?? new List<Team>();


            foreach (var plan in result)
            {
                plan.UserName = plan.UserId != null
                    ? users.FirstOrDefault(u => u.Id == plan.UserId)?.UserName ?? "-"
                    : "-";

                plan.TeamName = plan.TeamId != null
                    ? teams.FirstOrDefault(t => t.Id == plan.TeamId)?.TeamName ?? "-"
                    : "-";
            }

            return result;


        }
    }
}