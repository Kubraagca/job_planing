﻿namespace IsPlanlamaAPI.Core.Entities
{
    public class TeamMember: BaseEntity
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int?   UserId { get; set; }
        public User? User { get; set; }
    }
}
