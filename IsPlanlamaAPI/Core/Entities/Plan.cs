using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsPlanlamaAPI.Core.Entities
{
    public class Plan : BaseEntity
    {
       
        public DateTime IsGunu { get; set; }
        public string Title { get; set; }
        public string IsAciklama { get; set; }
        public string Place { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }

        public string? Status { get; set; }  

        public string? RevizyonAciklama { get; set; }
       
        [ForeignKey("AssignedUserId")]
        public int? AssignedUserId { get; set; }
        public User? AssignedUser { get; set; }

        //public enum PlanStatus
        //{   Planlandı,
        //    Onaylandi,
        //    Revizyon,
        //    Tamamlandı,
        //    Iptaledildi
        //}
    }
}

