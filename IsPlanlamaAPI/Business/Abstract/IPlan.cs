

using IsPlanlamaAPI.Contract.Common.Request.PlanDtos;

namespace IsPlanlamaAPI.Business.Abstract
{
    public interface IPlan 
    {
        void AddPlan(CreatePlanDtos plan);


        List<ResultPlanDto> GetAll();

        GetPlanDto GetById(int id);

        void Update(UpdatePlanDtos request);

        void Delete(int id);

        void UpdateStatus(int planId, string newStatus, string? revizyonAciklama = null);

        List<ResultPlanDto> GetFilteredPlans(int?TeamId, int? UserId);
    }
}
