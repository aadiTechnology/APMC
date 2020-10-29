using Microsoft.EntityFrameworkCore;
using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository
{
    public class AppUsersRepository : RepositoryBase<AppUsers>,IAppUsersRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public AppUsersRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public AppUsers Register(AppUsers appUsers)
        {
            _repositoryContext.Add(appUsers);
            _repositoryContext.SaveChanges();
            return appUsers;
        }

        public AppUsers GetUsers(LoginDto loginDto)
        {
            return _repositoryContext.AppUsers.SingleOrDefault(x => x.UserName == loginDto.UserName);
            //return FindByCondition(x=>x.UserName == loginDto.UserName);
        }

        public async Task<IEnumerable<AppUserRoles>> GetAllUserRolls()
        {
            return await _repositoryContext.AppUserRoles.ToListAsync();
        }

        IQueryable<AppUserRoles> IRepositoryBase<AppUserRoles>.FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<AppUserRoles> FindByCondition(Expression<Func<AppUserRoles, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Create(AppUserRoles entity)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUserRoles entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUserRoles entity)
        {
            throw new NotImplementedException();
        }
    }
}
