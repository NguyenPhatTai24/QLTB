<%@ Control Language="C#" AutoEventWireup="false" Inherits="S4T_THIETBI.NPTINPHIEUCOVID.View" CodeFile="View.ascx.cs" %>

<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=11.1.17.503, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<style type="text/css">
    .auto-style1 {
        width: 81px;
    }
    .auto-style2 {
        width: 48px;
    }
    .auto-style3 {
        width: 58px;
    }
    .auto-style4 {
        width: 49px;
    }
    .auto-style5 {
        width: 56px;
    }
    .auto-style6 {
        width: 44px;
    }
</style>

<div class="dnnForm dnnEdit dnnClear" id="dnnEdit">
    <fieldset>
        <div class="dnnFormItem">
            <br />
            <p align ="center"><font size ="10px" >Xuất Excel</font></p> 
             <table style="width:100%;"><tr><td class="auto-style1">Tên tiêu đề :</td><td><telerik:radtextbox ID="rtentd" Runat="server" LabelWidth="50px" Resize="None" Text='<%# Bind("TenTD") %>' Width="300px" Height ="30px">
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
        </div>
   </fieldset>
<table class="auto-style8"><tr><td class="auto-style7">
<telerik:radgrid ID="rg_nhanvien" runat="server" AutoGenerateColumns="False" OnNeedDataSource="rg_nhanvien_NeedDataSource" Skin="Windows7" Width="545px">                  
    <GroupingSettings CollapseAllTooltip="Collapse all groups" />
    <mastertableview allowpaging="True" commanditemdisplay="Top" datakeynames="ID_NV" insertitempageindexaction="ShowItemOnCurrentPage" nomasterrecordstext="Không có dữ liệu">
        <CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="False" />
        <Columns>
            <telerik:GridBoundColumn DataField="HO_NV" FilterControlAltText="Filter HO_NV column" HeaderText="Họ " UniqueName="HO_NV">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="TEN_NV" FilterControlAltText="Filter TEN_NV column" HeaderText="Tên" UniqueName="TEN_NV">
            </telerik:GridBoundColumn>
        </Columns>
    </mastertableview>
</telerik:radgrid>
    </tr>
    </table>
    <br />
    <br />
    <p align ="center">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
    <telerik:RadButton ID="RadButton3" runat="server" Text ="Xuất Excel" Skin="Glow" Height="35px" Width="90px" OnClick="RadButton3_Click"></telerik:RadButton>
        </p>
    <br />
</div>