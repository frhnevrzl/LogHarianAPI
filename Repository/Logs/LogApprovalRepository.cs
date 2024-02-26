using LoghanAPI.Data;
using LoghanAPI.Models.Logs;
using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Repository.Interface;
using LoghanAPI.ViewModels;
using LoghanAPI.ViewModels.Masters;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LoghanAPI.Repository.Transactions
{
    public class LogApprovalRepository : ILogApprovalRepository
    {
        protected AppDbContext _appDbContext;
        public LogApprovalRepository(AppDbContext context)
        {
            _appDbContext = context;
        }
        public ResultViewModel GetById(int id)
        {
            var result = new ResultViewModel();

            var data = _appDbContext.LogApprovals
                .Include(x => x.StatusLaporan)
                .Include(x => x.LaporanHarian)
                .Where(x => x.LaporanHarianId == id)
                .ToList();
            try
            {
                result.IsSuccess = true;
                result.Data = data;
                result.Message = "Success";
                result.ItemsCount = data.Count;
                return result;
            }
            catch (Exception e)
            {

                result.IsSuccess = false;
                result.Message = e.InnerException.Message;
                return result;
            }
        }
        public ResultViewModel Post(LogApprovalVM datas)
        {
            datas.ApprovedDate = DateTime.Now;
            var data = new LogApproval
            {
                LaporanHarianId = datas.LaporanHarianId,
                Keterangan = datas.Keterangan,
                StatusLaporanId = datas.StatusLaporanId,
                ApproverNPP = datas.ApproverNPP,
                ApproveDate = datas.ApprovedDate.Value
            };

            _appDbContext.LogApprovals.Add(data);
            _appDbContext.SaveChanges();

            var result = new ResultViewModel();
            result.IsSuccess = true;
            result.Message = "Success Add Log";

            return result;
        }
    }
}
