using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.Contracts
{
    public interface IAppUsersRepository:IRepositoryBase<AppUsers>
    {
        AppUsers Register(AppUsers appUsers);
        AppUsers GetUsers(LoginDto loginDto);
        AppUsers GetUsersById(int Id);
        Task<IEnumerable<AppUserRoles>> GetAllUserRolls();
    }
}
