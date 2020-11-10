using Microsoft.EntityFrameworkCore.Infrastructure;
using MyProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Entities.DataTransferObjects
{
    public class IndentDto
    {
        public IndentDetails IndentDetails { get; set; }
        public List<IndentProducts> IndentProducts { get; set; }
    }
}
