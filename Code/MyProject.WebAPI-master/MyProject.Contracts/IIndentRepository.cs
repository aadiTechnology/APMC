using MyProject.Entities.DataTransferObjects;
using MyProject.Entities.Models;
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
        string GetOrderId();
        public byte[] GenerateQRCode(string indentId, string merchantId, string driverId);
        public IndentDetails GetIndent(int indentId);
        public IndentDetails GetIndent(int indentId, int merchantId, string driverId);
        public List<IndentDetails> GetIndentByDateRange(DateTime fromDate, DateTime toDate);
        public List<IndentMerchantDto> GetIndentWithMerchantName();

        public List<IndentDetailsDto> GetIndentDetailsByMerchantID(int merchant);
        public List<IndentDetailsDto> GetIndentDetailsByDriverID(int driverId);
        public IndentDetailsDto GetIndent(int indentId, int merchantId, int driverId);
        public IndentDetailsDto GetIndentDetails(int indentID);
    }
}
