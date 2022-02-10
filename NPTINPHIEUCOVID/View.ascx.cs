// 
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// 
#region Using Statements

using System;
using DotNetNuke.Entities.Modules;
using System.Linq;
using System.IO;
using System.Web.UI;
using System.Web;
using Telerik.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using Telerik.Web.UI.GridExcelBuilder;
using System.Net.Mime;
using System.Web.Mvc;
using S4T_THIETBI.NPTINPHIEUCOVID;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;

#endregion

namespace S4T_THIETBI.NPTINPHIEUCOVID
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
			
			if (!Page.IsPostBack)
			{

			}
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

        protected void rg_nhanvien_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                rg_nhanvien.DataSource = (from item in Hp_QLTB.NHANVIEN.All()
                                          select item).ToList();
            }
            catch
            {
            }
        }
        public byte[] Great()
        {
            DataTable dt = new DataTable();
            int columncount = 0;
            foreach (GridColumn column in rg_nhanvien.MasterTableView.Columns)
            {
                if (!string.IsNullOrEmpty(column.UniqueName) && !string.IsNullOrEmpty(column.HeaderText))
                {
                    columncount++;
                    dt.Columns.Add(column.UniqueName, typeof(string));
                }
            }
            DataRow dr;
            foreach (GridDataItem item in rg_nhanvien.MasterTableView.Items)
            {
                dr = dt.NewRow();
                for (int i = 0; i < columncount; i++)
                {
                    dr[i] = item[rg_nhanvien.MasterTableView.Columns[i].UniqueName].Text;
                }
                dt.Rows.Add(dr);
            }
            int rowindex = 1;
            ExcelRange cell;
            ExcelFill fill;
            Border border;
            using (var excelpackage = new ExcelPackage())
            {
                excelpackage.Workbook.Properties.Author = "NPT Report";
                excelpackage.Workbook.Properties.Title = "NPT Report";
                var sheet = excelpackage.Workbook.Worksheets.Add("NPT Report");
                sheet.Name = "NPT Report";
                sheet.Column(2).Width = 10;
                sheet.Column(3).Width = 30;
                sheet.Column(4).Width = 20;

                sheet.Cells[rowindex, 2, rowindex, 6].Merge = true;
                cell = sheet.Cells[rowindex, 2];
                cell.Value = "Cộng Hòa Xã Hội Chủ Nghĩa Việt Nam";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Name = "Times New Roman";
                cell.Style.Font.Size = 20;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowindex = rowindex + 1;

                sheet.Cells[rowindex, 2, rowindex, 6].Merge = true;
                cell = sheet.Cells[rowindex, 2];
                cell.Value = "Độc lập - Tự do - Hạnh Phúc";
                cell.Style.Font.UnderLine = true;
                cell.Style.Font.Name = "Times New Roman";
                cell.Style.Font.Size = 15;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowindex = rowindex + 1;

                sheet.Cells[rowindex+1, 2, rowindex+1, 6].Merge = true;
                cell = sheet.Cells[rowindex+1, 2];
                cell.Value = rtentd.Text;
                cell.Style.Font.Bold = true;
                cell.Style.Font.Name = "Times New Roman";
                cell.Style.Font.Size = 20;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowindex = rowindex + 1;

                string time = "Ngày "+rngay.Text+" Tháng "+rthang.Text+" Năm "+rnam.Text;
                sheet.Cells[rowindex + 1, 2, rowindex + 1, 6].Merge = true;
                cell = sheet.Cells[rowindex + 1, 2];
                cell.Value = time;
                cell.Style.Font.Italic = true;
                cell.Style.Font.Name = "Times New Roman";
                cell.Style.Font.Size = 12;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rowindex = rowindex + 1;

               sheet.Column(6).Width = 50;
               cell = sheet.Cells[8,4];
               cell.Value = "Họ";
               cell.Style.Font.Bold = true;
               cell.Style.Font.Color.SetColor(Color.White);
               cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
               cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
               fill = cell.Style.Fill;
               fill.PatternType = ExcelFillStyle.Solid;
               fill.BackgroundColor.SetColor(Color.Black);
               cell.Style.Font.Size = 13;
               cell.Style.Font.Bold = true;
               border = cell.Style.Border;
               border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                cell = sheet.Cells[8,5];
                cell.Value = "Tên";
                cell.Style.Font.Bold = true;
                cell.Style.Font.Color.SetColor(Color.White);
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.Black);
                cell.Style.Font.Size = 13;
                cell.Style.Font.Bold = true;
                border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                for (int i = 0;i< dt.Rows.Count;i++)
                {
                    for(int j = 0; j < rg_nhanvien.Columns.Count; j++)
                    {
                        cell = sheet.Cells[i+9, j + 4];
                        cell.Value = dt.Rows[i][j].ToString();
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(Color.White);
                        cell.Style.Font.Size = 10;
                        cell.Style.Font.Italic = true;
                        border = cell.Style.Border;
                        border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                        //sheet.Cells[i+10 + 2, j + 1+5].Value = dt.Rows[i][j].ToString();
                    }    
                }    
                return excelpackage.GetAsByteArray();
            }
        }
        protected void RadButton3_Click(object sender, EventArgs e)
        {
            if (rtentd.Text != "")
            {
                Response.ClearContent();
                Response.BinaryWrite(Great());
                Response.AddHeader("content-disposition", "attachment; filename = NPTReport.xlsx");
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.Flush();
                Response.End();
            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Bạn chưa nhập tên tiêu đề !')</script>");
            }
        }
    }
}
