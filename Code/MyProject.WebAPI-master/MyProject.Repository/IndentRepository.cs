using Microsoft.EntityFrameworkCore;
using MyProject.Contracts;
using MyProject.Entities;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository
{
    public class IndentRepository : RepositoryBase<IndentDetails>, IIndentRepository
    {
        private readonly RepositoryContext _repositoryContext;
        public IndentRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IndentDetails AddIndent(IndentDetails indentDetails, List<IndentProducts> indentProducts)
        {
            try
            {
                indentDetails.OrderNo = GetOrderId();
                indentDetails.CreatedDate = DateTime.Now;
                _repositoryContext.IndentDetails.Add(indentDetails);
                var id = GetIndentId();
                foreach (IndentProducts indentProduct in indentProducts)
                {
                    indentProduct.IndentId = id;
                }
                _repositoryContext.IndentProducts.AddRange(indentProducts);
                _repositoryContext.SaveChanges();
                return indentDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IndentDetails Update(IndentDetails indentDetails)
        {
            try
            {
                _repositoryContext.IndentDetails.Update(indentDetails);
                _repositoryContext.SaveChanges();
                return indentDetails;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public string GetOrderId()
        {
            string orderNo = _repositoryContext.IndentDetails.OrderByDescending(a => a.Id).Select(a => a.OrderNo).FirstOrDefault();
            if (orderNo == null)
            {
                orderNo = "IndNo-1";
            }
            else
            {
                orderNo = "IndNo-" + (Convert.ToInt32(orderNo.Split('-')[1].Trim()) + 1);
            }
            return orderNo;
        }

        public int GetIndentId()
        {
            int id = _repositoryContext.IndentDetails.OrderByDescending(a => a.Id).Select(a => a.Id).FirstOrDefault();
            return id;
        }


    }
}
