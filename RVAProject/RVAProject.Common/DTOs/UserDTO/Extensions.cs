using RVAProject.Common.Entities;

namespace RVAProject.Common.DTOs.UserDTO
{
    public static class Extensions
    {
        public static UserInfo AsUserInfo(this User user)
        {
            var userInfo = new UserInfo()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            return userInfo;
        }
    }
}
