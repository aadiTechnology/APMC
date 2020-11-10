using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Contracts
{
    public interface IIndentRepository : IRepositoryBase<IndentDetails>
    {
        IndentDetails Add(IndentDetails indentDetails, List<IndentProducts> indentProducts);
        IndentDetails Update(IndentDetails indentDetails);
    }
}
