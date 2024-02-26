using LoghanAPI.ViewModels;
using System;
using System.Collections.Generic;

namespace LoghanAPI.Services
{
    public class QueryServices
    {
        public QueryServices() { }

        public string GetFilteredDokumen(DokumenFilter param)
        {
            var query = "SELECT lp.[Id],lp.[Nomor],lp.[Keterangan],lp.[SubmitDate],ap.Nama as NamaAplikasi,kl.Nama as kategoriLaporan,st.Nama as LastStatus,us.Nama as Maker FROM [LoghanAPI].[dbo].[TRX_LaporanHarian] as lp Join M_Application as ap on lp.ApplicationId = ap.Id Join M_KategoriLaporan as kl on lp.KategoriLaporanId = kl.Id Join M_StatusLaporan as st on lp.StatusId = st.Id Join M_Users as us on lp.CreaterId = us.Username ";
            try
            {
                var listStr = new List<string>();
                if (param.isFiltered != false)
                {
                    query += "WHERE ";

                    if (param.ApplicationId != null)
                    {
                        var str = "ap.Id = " + param.ApplicationId.ToString();
                        listStr.Add(str);
                    }
                    if (param.KategoriLaporanId != null)
                    {
                        var str = "kl.Id = " + param.KategoriLaporanId.ToString();
                        listStr.Add(str);
                    }
                    if (param.StatusId != null)
                    {
                        var str = "st.Id = " + param.StatusId.ToString();
                        listStr.Add(str);
                    }
                    if (param.Nomor != null)
                    {
                        var str = "kl.Id = " + param.Nomor;
                        listStr.Add(str);
                    }

                    for (int i = 0; i < listStr.Count; i++)
                    {
                        if (i == 0)
                        {
                            query += listStr[i];
                        }
                        else
                        {
                            query += (" and " + listStr[i]);
                        }
                    }
                    query += " order by st.Id desc";
                    return query;
                }
                else
                {
                    return query;
                }
            }
            catch (Exception e)
            {

                return query;
            }
        }
    }
}
