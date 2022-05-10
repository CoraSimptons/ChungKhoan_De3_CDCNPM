using DMChungKhoan.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMChungKhoan.Controllers
{
    public class DMChungKhoanController : Controller
    {
        // GET: Chung khoan
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChungKhoanConnection"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"SELECT [MACP], [GIAMUA3], [SOLUONGMUA3], [GIAMUA2], [SOLUONGMUA2], 
                [GIAMUA1], [SOLUONGMUA1], [GIAKHOP], [SOLUONGKHOP], [GIABAN1], [SOLUONGBAN1], [GIABAN2], [SOLUONGBAN2], [GIABAN3], 
                [SOLUONGBAN3], [TONGSOLUONGKHOP] FROM [dbo].[BANGGIATRUCTUYEN]", connection))
                {
                    // Make sure the command object does not already have
                    // a notification object associated with it.
                    command.Notification = null;

                    SqlDependency dependency = new SqlDependency(command);
                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    var listCus = reader.Cast<IDataRecord>()
                            .Select(x => new
                            {
                                MACP = (string)x["MACP"],
                                GIAMUA3 = (double)x["GIAMUA3"],
                                SOLUONGMUA3 = (int)x["SOLUONGMUA3"],
                                GIAMUA2 = (double)x["GIAMUA2"],
                                SOLUONGMUA2 = (int)x["SOLUONGMUA2"],
                                GIAMUA1 = (double)x["GIAMUA1"],
                                SOLUONGMUA1 = (int)x["SOLUONGMUA1"],
                                GIAKHOP = (double)x["GIAKHOP"],
                                SOLUONGKHOP = (int)x["SOLUONGKHOP"],
                                GIABAN1 = (double)x["GIABAN1"],
                                SOLUONGBAN1 = (int)x["SOLUONGBAN1"],
                                GIABAN2 = (double)x["GIABAN2"],
                                SOLUONGBAN2 = (int)x["SOLUONGBAN2"],
                                GIABAN3 = (double)x["GIABAN3"],
                                SOLUONGBAN3 = (int)x["SOLUONGBAN3"],
                                TONGSOLUONGKHOP = (int)x["TONGSOLUONGKHOP"]
                            }).ToList();

                    return Json(new { listCus = listCus }, JsonRequestBehavior.AllowGet);

                }
            }
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            CusHub.Show();
        }
    }
}