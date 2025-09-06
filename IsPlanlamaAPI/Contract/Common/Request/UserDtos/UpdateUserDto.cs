using IsPlanlamaAPI.Core.Entities;

namespace IsPlanlamaAPI.Contract.Common.Request.UserDtos
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public int TeamId { get; set; }

    }
}
