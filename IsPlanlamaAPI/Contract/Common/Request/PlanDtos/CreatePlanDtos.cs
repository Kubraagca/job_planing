using System.ComponentModel.DataAnnotations;

namespace IsPlanlamaAPI.Contract.Common.Request.PlanDtos
{
    public class CreatePlanDtos
    {
        
        public DateTime IsGunu { get; set; }
        public string Title { get; set; }
        public string IsAciklama { get; set; }
        public string Place { get; set; }
       
        public int? TeamId { get; set; }

        public string? Status { get; set; }

        public int? AssignedUserId { get; set; }
  
    }
}

