using AutoMapper;
using FileManager.Core.Application.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace FileManager.Core.Application.Mappings
{
    public static class UserMapper
    {
        public static UserViewModel ToUserViewModel(this IdentityUser identityUser)
        {
            IMapper mapper = IdentityUserToUserViewModelConfig().CreateMapper();
            return mapper.Map<UserViewModel>(identityUser);
        }

        #region Config
        private static MapperConfiguration IdentityUserToUserViewModelConfig()
        {
            return new MapperConfiguration(m =>
            {
                m.CreateMap<IdentityUser, UserViewModel>();
                m.CreateMap<UserViewModel, IdentityUser>();
            });
        }
        #endregion
    }
}
