<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calendar.ascx.cs" Inherits="WebApplication1.Pages.Controls.Calendar" %>
<asp:UpdatePanel runat="server" ID="uplCalendar" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" border="0" cellpadding="1" cellspacing="0">
            <tr>                
                <td>
                    <asp:DropDownList runat="server" ID="ddlMonth" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"
                        AutoPostBack="True" Width="55px" meta:resourcekey="ddlMonthResource1">
                        <asp:ListItem Text="01" Value="1" meta:resourcekey="ListItemResource1" />
                        <asp:ListItem Text="02" Value="2" meta:resourcekey="ListItemResource2" />
                        <asp:ListItem Text="03" Value="3" meta:resourcekey="ListItemResource3" />
                        <asp:ListItem Text="04" Value="4" meta:resourcekey="ListItemResource4" />
                        <asp:ListItem Text="05" Value="5" meta:resourcekey="ListItemResource5" />
                        <asp:ListItem Text="06" Value="6" meta:resourcekey="ListItemResource6" />
                        <asp:ListItem Text="07" Value="7" meta:resourcekey="ListItemResource7" />
                        <asp:ListItem Text="08" Value="8" meta:resourcekey="ListItemResource8" />
                        <asp:ListItem Text="09" Value="9" meta:resourcekey="ListItemResource9" />
                        <asp:ListItem Text="10" Value="10" meta:resourcekey="ListItemResource10" />
                        <asp:ListItem Text="11" Value="11" meta:resourcekey="ListItemResource11" />
                        <asp:ListItem Text="12" Value="12" meta:resourcekey="ListItemResource12" />
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlDay" Width="45px" meta:resourcekey="ddlDayResource1" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlYear" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                        AutoPostBack="True" Width="90px" meta:resourcekey="ddlYearResource1" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>