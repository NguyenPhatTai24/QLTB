<%@ Control Language="C#" AutoEventWireup="false" Inherits="S4T_THIETBI.NPT_INPHIEUTHIETBI.View" CodeFile="View.ascx.cs" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=11.1.17.503, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>


<script type="text/javascript" src="/crystalreportviewers13/js/crviewer/crv.js"></script>
<style type="text/css">
    .auto-style1 {
        width: 79px;
    }
    .auto-style2 {
        width: 51px;
    }
    .auto-style3 {
        width: 61px;
    }
    .auto-style4 {
        width: 52px;
    }
    .auto-style5 {
        width: 65px;
    }
    .auto-style6 {
        width: 48px;
    }
</style>
<div class="dnnForm dnnEdit dnnClear" id="dnnEdit">
    <br>
    <br>
                <p align ="center"><font size ="10px" >Phiếu kiểm kê</font></p> 
            <table style="width:100%;"><tr><td class="auto-style1">Tên đơn vị :</td><td><telerik:radtextbox ID="rtentb" Runat="server" LabelWidth="50px" Resize="None" Text='<%# Bind("TEN_TB") %>' Width="300px" Height ="30px">
            </telerik:radtextbox></td></tr>             
            </table>
           <br>
            <table style="width:100%;">
            <tr>
            <td class="auto-style2">Ngày :</td>
            <td class="auto-style3">
            <asp:DropDownList ID="rngay" OnInit="rngay_Init" runat="server" SelectedValue='<%# Bind("id_ngay") %>' Width ="50px" Height ="30px">
            </asp:DropDownList>
            </td>
            <td class="auto-style4">Tháng :</td>
            <td class="auto-style5">
            <asp:DropDownList ID="rthang" OnInit="rthang_Init" runat="server" SelectedValue='<%# Bind("id_thang") %>'  Width ="50px" Height ="30px">
            </asp:DropDownList>
            </td>
            <td class="auto-style6">Năm :</td>
            <td>
            <asp:DropDownList ID="rnam" OnInit="rnam_Init" runat="server" SelectedValue='<%# Bind("id_nam") %>'  Width ="100px" Height ="30px">
            </asp:DropDownList>
            </td>
            </tr>
            </table>
            <br>
            <telerik:RadButton ID="InPhieu" runat="server" Text ="In phiếu" Skin="Glow" Height="35px" Width="70px" OnClick="InPhieu_Click"></telerik:RadButton>
            <br>
    <br>
    </div>
<telerik:ReportViewer ID="ReportViewerNPT" runat="server" EnableTheming="True" Height="850px" ViewMode="PrintPreview" Width="100%" 
        ZoomMode="FullPage" ShowHistoryButtons="False" ShowPrintPreviewButton="False" ShowZoomSelect="True" ProgressText="Tạo phiếu..." 
        ShowNavigationGroup="False" ShowParametersButton="False"></telerik:ReportViewer>