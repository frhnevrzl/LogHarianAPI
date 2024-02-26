using Dapper;
using LoghanAPI.Data;
using LoghanAPI.Models.Logs;
using LoghanAPI.Models.Masters.Main;
using LoghanAPI.Models.Transactions;
using LoghanAPI.Repository.Interface;
using LoghanAPI.Services;
using LoghanAPI.ViewModels;
using LoghanAPI.ViewModels.Masters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoghanAPI.Repository.Transactions
{
    public class LaporanHarianRepository : ILaporanHarianRepository
    {
        private readonly AppDbContext _appDbContext;
        private IConfiguration _configuration;
        SqlConnection _connection;
        IWebHostEnvironment _host;
        protected QueryServices _query;
        protected IAttachmentRepository _attachmentRepository;
        protected ILogApprovalRepository _logApprovalRepository;
        public LaporanHarianRepository(AppDbContext appDbContext, SqlConnection connection, IConfiguration configuration, IWebHostEnvironment host, QueryServices query, IAttachmentRepository attachmentRepository, ILogApprovalRepository logApprovalRepository)
        {
            _appDbContext = appDbContext;
            _connection = connection;
            _configuration = configuration;
            _host = host;
            _query = query;
            _attachmentRepository = attachmentRepository;
            _logApprovalRepository = logApprovalRepository;
        }

        public ResultViewModel Get(DokumenFilter filter)
        {
            try
            {
                _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                _connection.Open();

                var query = _query.GetFilteredDokumen(filter);
                var queryExec = _connection.Query<GetDataLaporan>(query);

                var result = new ResultViewModel();
                result.IsSuccess = true;
                result.Data = queryExec;
                return result;
            }
            catch (Exception e)
            {

                var result = new ResultViewModel();
                result.IsSuccess = true;
                result.Message = "No Data Available";
                return result;
            }
        }

        public ResultViewModel GetById(int id)
        {
            try
            {
                var data = _appDbContext.LaporanHarians
                    .Include(x => x.Application)
                    .Include(x => x.Status)
                    .Include(x => x.KategoriLaporan)
                    .Include(x => x.Creater)
                    .Where(x => x.Id == id).FirstOrDefault();

                var result = new ResultViewModel();
                result.IsSuccess = true;
                result.Data = data;
                return result;
            }
            catch (Exception e)
            {

                var result = new ResultViewModel();
                result.IsSuccess = true;
                result.Message = e.InnerException.Message;
                return result;
            }
        }

        public ResultViewModel Post(LaporanVM datas)
        {
            var result = new ResultViewModel();
            try
            {
                var isCompleteOperation = false;

                if (datas != null)
                {
                    if (datas.Id != 0)
                    {
                        var insert = new LaporanHarian
                        {
                            ApplicationId = datas.ApplicationId,
                            CreaterId = datas.CreaterId,
                            KategoriLaporanId = datas.KategoriLaporanId,
                            Keterangan = datas.Keterangan,
                            Nomor = "1",
                            Index = 1,
                            StatusId = 1,
                            IsDelete = false,
                            SubmitDate = DateTime.Now,
                        };
                        _appDbContext.Add(insert);
                        var isSuccessAdd = _appDbContext.SaveChanges();

                        if (isSuccessAdd > 0)
                        {
                            if (datas.Attachments.Count != 0)
                            {
                                foreach (var item in datas.Attachments)
                                {
                                    var attch = new AttachmentLaporan
                                    {
                                        LaporanHarianId = insert.Id,
                                        PathFile = _attachmentRepository.InsertAttachmentLaporan(insert.Id, item),
                                    };
                                    _appDbContext.Add(attch);
                                    _appDbContext.SaveChanges();
                                }
                            }
                            var addInitialLog = new LogApproval
                            {
                                LaporanHarianId = insert.Id,
                                Keterangan = "Success Submit Log",
                                ApproverNPP = "",
                                ApproveDate = DateTime.Now,
                                StatusLaporanId = insert.Id,
                            };
                            _appDbContext.Add(addInitialLog);
                            _appDbContext.SaveChanges();
                            isCompleteOperation = true;
                        }

                        if(isCompleteOperation)
                        {
                            result.IsSuccess = true;
                            result.Message = "Success Add Laporan";
                            return result;
                        }
                        else
                        {
                            result.IsSuccess = false;
                            result.Message = "Failed Add Laporan";
                            return result;
                        }
                    }
                    else
                    {
                        var update = _appDbContext.LaporanHarians.Where(x => x.Id == datas.Id).FirstOrDefault();
                        if (update != null)
                        {
                            update.Keterangan = datas.Keterangan;
                            update.UpdateDate = DateTime.Now;
                            update.StatusId = 1;
                            update.KategoriLaporanId = datas.KategoriLaporanId;
                            _appDbContext.Entry(update).State = EntityState.Modified;
                            var isSuccessEdit = _appDbContext.SaveChanges();

                            if (isSuccessEdit > 0)
                            {
                                if (datas.Attachments.Count != 0)
                                {
                                    foreach (var item in datas.Attachments)
                                    {
                                        var attch = new AttachmentLaporan
                                        {
                                            LaporanHarianId = update.Id,
                                            PathFile = _attachmentRepository.InsertAttachmentLaporan(update.Id, item),
                                        };
                                        _appDbContext.Add(attch);
                                        _appDbContext.SaveChanges();
                                    }
                                }
                                var addInitialLog = new LogApproval
                                {
                                    LaporanHarianId = update.Id,
                                    Keterangan = "Success Submit Log",
                                    ApproverNPP = "",
                                    ApproveDate = DateTime.Now,
                                    StatusLaporanId = update.Id,
                                };
                                _appDbContext.Add(addInitialLog);
                                _appDbContext.SaveChanges();
                                isCompleteOperation = true;
                            }
                            else
                            {
                                result.IsSuccess = false;
                                result.Message = "Failed Add Laporan";
                                return result;
                            }
                            if (isCompleteOperation)
                            {
                                result.IsSuccess = true;
                                result.Message = "Success Add Laporan";
                                return result;
                            }
                            else
                            {
                                result.IsSuccess = false;
                                result.Message = "Failed Add Laporan";
                                return result;
                            }
                        }
                        else
                        {
                            result.IsSuccess = false;
                            result.Message = "Data Null or Not in Correct Format";
                            return result;
                        }
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Data Null or Not in Correct Format";
                    return result;
                }
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Message = "Data Null or Not in Correct Format";
                return result;
            }
        }

        public ResultViewModel Delete(int id)
        {
            var result = new ResultViewModel();
            try
            {
                var data = _appDbContext.LaporanHarians
                    .Where(x => x.Id == id).FirstOrDefault();

                if (data != null)
                {
                    _appDbContext.Remove(data);
                    _appDbContext.SaveChanges();

                    result.IsSuccess = true;
                    result.Data = data;
                    return result;
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "No Records Found";
                    return result;
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = true;
                result.Message = e.InnerException.Message;
                return result;
            }
        }
    }
}
