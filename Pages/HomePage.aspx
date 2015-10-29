<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebApplication1.Pages.HomePage" Title="Home" MasterPageFile="MasterPage.Master"%>

<%@ Register TagPrefix="_WFHStepsControl" TagName="Login" Src="~/Pages/Controls/Login.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">
<table width="60%" align="center">
<tr>
<td align="left">
<asp:ImageButton ID="imgbtnEnterSteps" runat="server" 
        ImageUrl="~/Images/EnterSteps.jpg" Width="200px" Height="150px" 
        PostBackUrl="~/Pages/EnterPedometerSteps.aspx"/>
</td>
<td>
</td>
<td  align="right">
<asp:ImageButton ID="imgbtnEditData" runat="server" ImageUrl="~/Images/EditData.jpg" Width="200px" Height="150px"/>
</td>
</tr>
<tr style="height: 50px">
<td colspan="3"></td>
</tr>
<tr>
<td align="left">
<asp:ImageButton ID="imgbtnViewCharts" runat="server" 
        ImageUrl="~/Images/ViewCharts.jpg" Width="200px" Height="150px" 
        PostBackUrl="~/Pages/MemberCharts.aspx"/>
</td>
<td>
</td>
<td  align="right">
<asp:ImageButton ID="imgbtnViewInfo" runat="server" ImageUrl="~/Images/ViewInfo.jpg" Width="200px" Height="150px"/>
</td>
</tr>
</table>    
    </asp:Content>