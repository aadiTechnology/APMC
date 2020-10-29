using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Contracts
{
    public interface IAppUsersRepository:IRepositoryBase<AppUsers>,IRepositoryBase<AppUserRoles>
    {
        AppUsers Register(AppUsers appUsers);
        AppUsers GetUsers(LoginDto loginDto);
        Task<IEnumerable<AppUserRoles>> GetAllUserRolls();
    }
}
