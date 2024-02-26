using LoghanAPI.Data;
using LoghanAPI.Models.Transactions;
using LoghanAPI.Repository.Interface;
using LoghanAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoghanAPI.Repository.Transactions
{
    public class AttachmentRepository : IAttachmentRepository
    {
        protected AppDbContext _appDbContext;
        protected IWebHostEnvironment _webHostEnvironment;
        public AttachmentRepository(IWebHostEnvironment webHostEnvironment, AppDbContext appDbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _appDbContext = appDbContext;
        }

        public ResultViewModel AddAttachmentLaporan(int laporanId, List<IFormFile> files)
        {
            var result = new ResultViewModel();

            try
            {
                if (files.Count != 0)
                {
                    foreach (var file in files)
                    {
                        string webRootPath = _webHostEnvironment.WebRootPath;
                        string paths = Path.Combine(webRootPath, "Files", "Attachment");
                        if (!Directory.Exists(paths))
                        {
                            Directory.CreateDirectory(paths);
                        }

                        string generateNameFile = file.FileName;
                        FileStream path = new FileStream(Path.Combine(paths, generateNameFile), FileMode.Create);
                        file.CopyTo(path);
                        path.Close();

                        var add = new AttachmentLaporan
                        {
                            LaporanHarianId = laporanId,
                            PathFile = generateNameFile
                        };
                        _appDbContext.Add(add);
                        _appDbContext.SaveChanges();
                        result.ItemsCount += 1;
                    }
                    result.IsSuccess = true;
                    result.Message = "Success Add Attachments";
                    return result;
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Data Null Fails Add Attachments";
                    return result;
                }
            }
            catch (Exception e)
            {

                result.IsSuccess = false;
                result.Message = e.InnerException.Message;
                return result;
            }
        }

        public ResultViewModel DeleteAttachmentById(int id)
        {
            var result = new ResultViewModel();
            try
            {
                var data = _appDbContext.AttachmentLaporans.Where(x => x.Id == id).FirstOrDefault();

                if (data != null)
                {
                    _appDbContext.Remove(data);
                    var isSuccess = _appDbContext.SaveChanges();

                    if (isSuccess > 0)
                    {
                        result.IsSuccess = true;
                        result.Message = "Data Deleted Successfully";
                        return result;
                    }
                    else
                    {
                        result.IsSuccess = false;
                        result.Message = "Data Is Not Deleted";
                        return result;
                    }
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Data is Not Found";
                    return result;
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "Data Is Not Deleted";
                return result;
            }
        }

        public ResultViewModel GetAttachmentLaporanById(int id)
        {
            var result = new ResultViewModel();
            try
            {
                var data = _appDbContext.AttachmentLaporans.Where(x => x.Id == id).FirstOrDefault();

                if (data != null)
                {
                    result.IsSuccess = false;
                    result.Message = "Success";
                    result.Data = data;
                    return result;
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Data is Not Found";
                    return result;
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "Data Not Found";
                return result;
            }
        }

        public ResultViewModel GetListAttachmentLaporan(int laporamId)
        {
            var result = new ResultViewModel();
            try
            {
                var data = _appDbContext.AttachmentLaporans.Where(x => x.LaporanHarianId == laporamId).ToList();

                if (data != null)
                {
                    result.IsSuccess = false;
                    result.Message = "Success";
                    result.Data = data;
                    return result;
                }
                else
                {
                    result.IsSuccess = false;
                    result.Message = "Data is Not Found";
                    return result;
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = "Data Not Found";
                return result;
            }
        }

        public string InsertAttachmentLaporan(int laporamId, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    string paths = Path.Combine(webRootPath, "Files", "Attachment");
                    if (!Directory.Exists(paths))
                    {
                        Directory.CreateDirectory(paths);
                    }

                    string generateNameFile = file.FileName;
                    FileStream path = new FileStream(Path.Combine(paths, generateNameFile), FileMode.Create);
                    file.CopyTo(path);
                    path.Close();

                    return generateNameFile;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception e)
            {

                return string.Empty;
            }
        }
    }
}
