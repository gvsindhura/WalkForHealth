<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Title="Walk for Health Home" Inherits="WebApplication1.Pages.LoginPage"  MasterPageFile="MasterPage.Master"%>

<%@ Register TagPrefix="_WFHStepsControl" TagName="Login" Src="~/Pages/Controls/Login.ascx" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">
<table align="center">
<tr>
<td>
<_WFHStepsControl:Login runat="server" ID="LoginControl" />
</td>
</tr>
</table>    
    </asp:Content>