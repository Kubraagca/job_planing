namespace IsPlanlamaAPI.Contract.Common.Request.PlanDtos
{
    public class ResultPlanDto
    {
        public int Id { get; set; }
        public DateTime IsGunu { get; set; }
        public string Title { get; set; }
        public string IsAciklama { get; set; }
        public string Place { get; set; }
        public int? TeamId { get; set; }
        public int? UserId { get; set; }
        public string Status { get; set; } = "Planlandı";
        public string? RevizyonAciklama { get; set; }
        public string? UserName { get; set; }  
        public string? TeamName { get; set; }
    }
}

