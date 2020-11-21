﻿using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Contracts
{
    public interface IIndentRepository : IRepositoryBase<IndentDetails>
    {
        IndentDetails AddIndent(IndentDetails indentDetails, List<IndentProducts> indentProducts);
        IndentDetails Update(IndentDetails indentDetails);
        Task<IEnumerable<IndentDetails>> GetOrderId();
      
    }
}
