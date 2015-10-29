<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterPedometerSteps.aspx.cs" EnableSessionState="True"
    Inherits="WebApplication1.Pages.EnterPedometerSteps" MasterPageFile="MasterPage.Master" %>

<%@ Register TagPrefix="_WFHStepsControl" TagName="Calendar" Src="~/Pages/Controls/Calendar.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel runat="server" ID="pnlRegistration">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ValidationSummary runat="server" ID="vdsSummary" meta:resourcekey="vdsSummaryResource1" />
                </td>
            </tr>
            <tr>
                <td style="height: 10px" />
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel runat="server" ID="uplEnterSteps" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td valign="top" style="width: 60%">
                                        <table border="0" cellpadding="1" cellspacing="1" width="100%" class="Grid">
                                            <tr style="background-image: url(../../images/header_gradient.jpg);">
                                                <td style="height: 20px" valign="middle">
                                                    &nbsp;<asp:Label runat="server" ID="lblAccountInformation" Text="Enter your Steps"
                                                        Font-Bold="True" meta:resourcekey="lblAccountInformationResource1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="2" cellspacing="0">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label runat="server" ID="lblSteps" Text="Steps" Font-Bold="True" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtSteps" MaxLength="100" Width="250px" />
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator Text="*" runat="server" ID="rfvFirstName" InitialValue=""
                                                                    ControlToValidate="txtSteps" ToolTip="First Name is required" ErrorMessage="First Name is required" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="2" cellspacing="0">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label runat="server" ID="lblAerobicSteps" Text="Aerobic Steps" Font-Bold="True" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtAerobicSteps" MaxLength="100" Width="250px" />
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator Text="*" runat="server" ID="rfvLastName" InitialValue=""
                                                                    ControlToValidate="txtAerobicSteps" ToolTip="Last Name is required" ErrorMessage="Last Name is required" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="2" cellspacing="0">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label runat="server" ID="lblAerobicDuration" Text="Aerobic Duration" Font-Bold="True"
                                                                    meta:resourcekey="lblPasswordResource1" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtAerobicDuration" MaxLength="12" Width="100px"
                                                                    meta:resourcekey="txtPasswordResource1" />
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator InitialValue="" Text="*" runat="server" ID="RequiredFieldValidator3"
                                                                    ControlToValidate="txtAerobicDuration" ToolTip="Password is required" ErrorMessage="Password is required"
                                                                    meta:resourcekey="rfvPasswordResource1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="2" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblDistance" Text="Distance(in miles)" Font-Bold="True" />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblFatBurn" Text="Fat Burn" Font-Bold="True" />
                                                            </td>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblCalories" Text="Calories" Font-Bold="True" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtDistance" MaxLength="12" Width="100px" Enabled="false" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtFatBurn" MaxLength="12" Width="100px" Enabled="false" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtCalories" MaxLength="12" Width="100px" Enabled="false" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="2" cellspacing="0">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label runat="server" ID="lblReadingDate" Text="Reading Date" Font-Bold="True"
                                                                    meta:resourcekey="lblPasswordResource1" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <_WFHStepsControl:Calendar runat="server" ID="cdrReadingDate" UseCalendarMinimumDate="true"
                                                                    ShowDayDropdown="true" />
                                                            </td>
                                                            <td>
                                                                <%--<asp:RequiredFieldValidator InitialValue="" Text="*" runat="server" ID="RequiredFieldValidator4"
                                                                    ControlToValidate="cdrReadingDate" ToolTip="Reading Date is required" ErrorMessage="Reading Date is required"
                                                                    meta:resourcekey="rfvPasswordResource1" />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="btnSave" runat="server" Text="Save Data" Enabled="false" OnClick="btnSave_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
