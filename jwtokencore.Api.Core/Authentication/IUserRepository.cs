using jwtokencore.Api.Core.Dto.Authentication;
using jwtokencore.Api.Core.Shared.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace jwtokencore.Api.Core.Authentication
{
    public interface IUserRepository : IRepository<User>
    {
        Task<CreateUserResponse> Create(string firstName, string lastName, string email, string userName, string password);
        Task<User> FindByName(string userName);
        Task<bool> CheckPassword(User user, string password);
    }
}
