// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
#region Using Statements

using System;
using DotNetNuke.Entities.Modules;
using System.Linq;
using Telerik.Web.UI;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Telerik.Reporting;
using System.Xml;
using Telerik.Reporting.XmlSerialization;
using System.Configuration;
using System.IO;
using QRCoder;
using System.Drawing;

#endregion

namespace S4T_THIETBI.NPT_INPHIEUTHIETBI
{

    public partial class View : PortalModuleBase
    {

        #region Event Handlers

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        #endregion
        protected void rngay_Init(object sender, EventArgs e)
        {
            try
            {
                int[] ngay = { 1, 2, 3 };
                rngay.DataTextField = "Ngày";
                rngay.DataValueField = "id_ngay";
                for (int i = 1; i <= 31; i++)
                {
                    rngay.Items.Add(i.ToString());
                }
            }
            catch
            { }
        }
        protected void rthang_Init(object sender, EventArgs e)
        {
            try
            {
                rthang.DataTextField = "Tháng";
                rthang.DataValueField = "id_thang";
                for (int i = 1; i <= 12; i++)
                {
                    rthang.Items.Add(i.ToString());
                }
            }
            catch
            { }
        }
        protected void rnam_Init(object sender, EventArgs e)
        {
            try
            {
                rnam.DataTextField = "Năm";
                rnam.DataValueField = "id_nam";
                for (int i = 2020; i <= 2024; i++)
                {
                    rnam.Items.Add(i.ToString());
                }
            }
            catch
            { }
        }
        SqlConnection constr = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=QLTB_Sys;User ID=sa;Password=123");
        protected void InPhieu_Click(object sender, EventArgs e)
        {
            if (rtentb.Text != "")
            {
                ReportViewerTai_Load();
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Bạn chưa nhập tên đơn vị !')</script>");
            }
        }
        protected void ReportViewerTai_Load()
        {
            try
            {
                SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-JVM8D5H\SQLEXPRESS;Initial Catalog=QLTB_Sys;User ID=sa;Password=123");
                string sql = "select TEN_TB,TENNHOMTHIETBI,TEN_NV,VITRI from VITRIDATTHIETBI,THIETBI,NHOMTHIETBI,NHANVIEN where THIETBI.ID_VITRI = VITRIDATTHIETBI.ID_VITRI and THIETBI.ID_NHOMTHIETBI = NHOMTHIETBI.ID_NHOMTHIETBI and THIETBI.ID_NV = NHANVIEN.ID_NV";
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string noidung;
                    noidung = "Tên thiết bị: " + dt.Rows[i][0].ToString() + "-  thuộc - " + dt.Rows[i][1].ToString() + "- người quản lý -" + dt.Rows[i][2].ToString() + "- vị trí -" + dt.Rows[i][3].ToString();

                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCode qrCode = new QRCode(qrGenerator.CreateQrCode(noidung, QRCodeGenerator.ECCLevel.Q));

                    using (Bitmap bitMap = qrCode.GetGraphic(2, Color.Black, Color.White, false))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            //qrcodeNPT.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                        }
                    }
                }



                string thoigian;
                thoigian = "Ngày " + rngay.SelectedValue + " Tháng " + rthang.SelectedValue + " Năm " + rnam.SelectedValue;
                SqlDataSource sqlDataSource = new SqlDataSource();

                Report report = new Report();
                XmlReaderSettings settings;
                XmlReader xmlReader;
                ReportXmlSerializer xmlSerializer;

                settings = new XmlReaderSettings
                {
                    IgnoreWhitespace = true
                };

                string path = Server.MapPath(".") + @"\DesktopModules\S4T_THIETBI\NPT_INPHIEUTHIETBI\ReportPhieuThietBi.trdx";

                using (xmlReader = XmlReader.Create(path, settings))
                {
                    xmlSerializer = new ReportXmlSerializer();
                    report = (Report)xmlSerializer.Deserialize(xmlReader);
                }



                InstanceReportSource ir = new InstanceReportSource();
                sqlDataSource = (SqlDataSource)report.DataSource;
                ir.ReportDocument = report;

                report.ReportParameters["TenDV"].Value = rtentb.Text;
                report.ReportParameters["ThoiGian"].Value = thoigian;
                report.ReportParameters["Text"].Value = "Tải Tại Tài Tai";
                ReportViewerNPT.RefreshReport();

                if (report != null)
                {
                    ReportViewerNPT.ReportSource = ir;
                }
            }
            catch
            {
            }
        }
    }
}
