<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs"
    Inherits="WebApplication1.Pages.RegistrationPage" MasterPageFile="MasterPage.Master" %>

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
                <td>
                    <asp:Label Font-Bold="True" runat="server" ID="lblRequiredFieldNote" Text="Fields with &lt;span style='color: red'&gt;*&lt;/span&gt; are required fields."
                        meta:resourcekey="lblRequiredFieldNoteResource1" />
                </td>
            </tr>
            <tr>
                <td style="height: 10px" />
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel runat="server" ID="uplRegistration" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td valign="top" style="width: 60%">
                                        <table border="0" cellpadding="1" cellspacing="1" width="100%" class="Grid">
                                            <tr style="background-image: url(../../images/header_gradient.jpg);">
                                                <td style="height: 20px" valign="middle">
                                                    &nbsp;<asp:Label runat="server" ID="lblAccountInformation" Text="Personal Information"
                                                        Font-Bold="True" meta:resourcekey="lblAccountInformationResource1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="2" cellspacing="0">
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label runat="server" ID="lblFirstName" Text="First Name" Font-Bold="True" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtFirstName" MaxLength="100" Width="250px" />
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator Text="*" runat="server" ID="rfvFirstName" InitialValue=""
                                                                    ControlToValidate="txtFirstName" ToolTip="First Name is required" ErrorMessage="First Name is required" />
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
                                                                <asp:Label runat="server" ID="lblLastName" Text="Last Name" Font-Bold="True" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtLastName" MaxLength="100" Width="250px" />
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator Text="*" runat="server" ID="rfvLastName" InitialValue=""
                                                                    ControlToValidate="txtLastName" ToolTip="Last Name is required" ErrorMessage="Last Name is required" />
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
                                                                <asp:Label runat="server" ID="lblUserName" Text="Username" Font-Bold="True" meta:resourcekey="lblUserNameResource1" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtUserName" MaxLength="16" meta:resourcekey="txtUserNameResource1" />
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator Text="*" InitialValue="" runat="server" ID="rfvUserName"
                                                                    ControlToValidate="txtUserName" ToolTip="UserName is required" ErrorMessage="Username is required"
                                                                    meta:resourcekey="rfvUserNameResource1" Display="Dynamic" />
                                                                <asp:RegularExpressionValidator Text="*" runat="server" ID="revUserName" ControlToValidate="txtUserName"
                                                                    ToolTip="UserName cannot accept non-english characters" ErrorMessage="UserName cannot accept non-english characters"
                                                                    meta:resourcekey="revUserNameResource1" Display="Dynamic" ValidationExpression="[A-Za-z][A-Za-z0-9._]{3,15}" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label runat="server" ID="lblUserNameNotes" Font-Italic="True" meta:resourcekey="lblUserNameNotesResource">
                                                                        Username must be between 4 and 16 characters
                                                                </asp:Label>
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
                                                                <asp:Label runat="server" ID="lblPassword" Text="Password" Font-Bold="True" meta:resourcekey="lblPasswordResource1" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtPassword" MaxLength="12" Width="100px" TextMode="Password"
                                                                    meta:resourcekey="txtPasswordResource1" />
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator InitialValue="" Text="*" runat="server" ID="rfvPassword"
                                                                    ControlToValidate="txtPassword" ToolTip="Password is required" ErrorMessage="Password is required"
                                                                    meta:resourcekey="rfvPasswordResource1" />
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
                                                                <asp:Label runat="server" ID="lblConfirmPassword" Text="Confirm Password" Font-Bold="True"
                                                                    meta:resourcekey="lblConfirmPasswordResource1" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox runat="server" ID="txtConfirmPassword" MaxLength="16" Width="100px"
                                                                                TextMode="Password" meta:resourcekey="txtConfirmPasswordResource1" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:CompareValidator runat="server" ID="cmvPassword" ControlToValidate="txtPassword"
                                                                                ControlToCompare="txtConfirmPassword" Text="*" ToolTip="Password and its confirmation not matching"
                                                                                ErrorMessage="Password and its confirmation not matching" Display="Dynamic" meta:resourcekey="cmvPasswordResource1" />
                                                                            <asp:RegularExpressionValidator runat="server" ID="revPassword" ControlToValidate="txtPassword"
                                                                                Text="*" ToolTip="Password length not accepted" ErrorMessage="Password length not accepted"
                                                                                Display="Dynamic" ValidationExpression="\w{6,12}" meta:resourcekey="revPasswordResource1" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label runat="server" ID="lblPasswordNotes" Font-Italic="True" meta:resourcekey="lblPasswordNotesResource1">
                                                                        Password must be between 6 and 10 characters
                                                                </asp:Label>
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
                                                                <asp:Label runat="server" ID="lblEmail" Text="Email" Font-Bold="True" meta:resourcekey="lblEmailResource1" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox runat="server" ID="txtEmail" MaxLength="100" Width="300px" meta:resourcekey="txtEmailResource1" />
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator InitialValue="" Text="*" runat="server" ID="rfvEmail"
                                                                    ControlToValidate="txtEmail" ToolTip="Email is required" ErrorMessage="Email is required"
                                                                    Display="Dynamic" meta:resourcekey="rfvEmailResource1" />
                                                                <asp:RegularExpressionValidator runat="server" ID="revEmail" ControlToValidate="txtEmail"
                                                                    Text="*" ToolTip="Email format is invalid" ErrorMessage="Email format is invalid"
                                                                    ValidationExpression="^[\w-.]+(?:\+[\w]*)?@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                                                                    meta:resourcekey="revEmailResource1" />
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
                                                                <asp:Label runat="server" ID="lblConfirmEmail" Text="Confirm Email" Font-Bold="True"
                                                                    meta:resourcekey="lblConfirmEmailResource1" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox runat="server" ID="txtConfirmEmail" MaxLength="100" Width="300px" meta:resourcekey="txtConfirmEmailResource1" />
                                                                        </td>
                                                                        <td>
                                                                            <asp:CompareValidator runat="server" ID="cmvEmail" ControlToValidate="txtEmail" ControlToCompare="txtConfirmEmail"
                                                                                Text="*" ToolTip="Email and its confirmation not matching" ErrorMessage="Email and its confirmation not matching"
                                                                                meta:resourcekey="cmvEmailResource1" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="2" cellspacing="0">
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:Label runat="server" ID="lblNationality" Text="Nationality" Font-Bold="True"
                                                                    meta:resourcekey="lblNationalityResource1" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList runat="server" ID="ddlNationality" Width="300px" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlNationality_SelectedIndexChanged" meta:resourcekey="ddlNationalityResource1" />
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="uplNationalityFlag" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:Image ID="imgNationalityFlag" runat="server" BorderColor="Black" BorderWidth="1px"
                                                                            meta:resourcekey="imgNationalityFlagResource1" />
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="ddlNationality" EventName="SelectedIndexChanged" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator InitialValue="" Text="*" runat="server" ID="rfvNationality"
                                                                    ControlToValidate="ddlNationality" ToolTip="Nationality is required" ErrorMessage="Nationality is required"
                                                                    meta:resourcekey="rfvNationalityResource1" />
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
                                                                <asp:Label runat="server" ID="lblGender" Text="Gender" Font-Bold="True" meta:resourcekey="lblGenderResource1" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButtonList runat="server" ID="rblGender" RepeatDirection="Horizontal" meta:resourcekey="rblGenderResource1">
                                                                    <asp:ListItem Value="1" Text="Male" Selected="True" meta:resourcekey="ListItemResource7" />
                                                                    <asp:ListItem Value="0" Text="Female" meta:resourcekey="ListItemResource6" />
                                                                </asp:RadioButtonList>
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
                                                                <asp:Label runat="server" ID="lblBirthDate" Text="Date of Birth" Font-Bold="True"
                                                                    meta:resourcekey="lblBirthDateResource1" />
                                                                <span style="color: red">*</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <_WFHStepsControl:Calendar runat="server" ID="cdrBirthDate" UseCalendarMinimumDate="true"
                                                                    ShowDayDropdown="true" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="1" cellspacing="1" width="100%" class="Grid">
                                                        <tr style="background-image: url(../../images/header_gradient.jpg);">
                                                            <td style="height: 20px" valign="middle">
                                                                &nbsp;<asp:Label runat="server" ID="lblContactSettings" Text="Contact Information"
                                                                    Font-Bold="True" meta:resourcekey="lblContactSettingsResource1" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="2" cellspacing="0">
                                                                    <tr>
                                                                        <td style="height: 5px" />
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table border="0" cellpadding="2" cellspacing="0">
                                                                                <tr>
                                                                                    <td />
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblMobilePhone" Text="Mobile Phone" Font-Bold="True"
                                                                                            meta:resourcekey="lblMobilePhoneResource1" />
                                                                                        <span style="color: red">*</span>
                                                                                    </td>
                                                                                    <td />
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblHomePhone" Text="Home Phone" Font-Bold="True" meta:resourcekey="lblHomePhoneResource1" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        +1
                                                                                    </td>
                                                                                    <td>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:TextBox runat="server" ID="txtMobilePhone" MaxLength="8" Width="60px" meta:resourcekey="txtMobilePhoneResource1" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RequiredFieldValidator InitialValue="" Text="*" runat="server" ID="rfvMobilePhone"
                                                                                                        ControlToValidate="txtMobilePhone" ToolTip="Mobile phone is required" ErrorMessage="Mobile phone is required"
                                                                                                        Display="Dynamic" meta:resourcekey="rfvMobilePhoneResource1" />
                                                                                                    <asp:RegularExpressionValidator runat="server" ID="revMobilePhone" ControlToValidate="txtMobilePhone"
                                                                                                        Text="*" ToolTip="Mobile phone should be 8 digits" ErrorMessage="Mobile phone should be 8 digits"
                                                                                                        ValidationExpression="\d{8}" Display="Dynamic" meta:resourcekey="revMobilePhoneResource1" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td>
                                                                                        +1
                                                                                    </td>
                                                                                    <td>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:TextBox runat="server" ID="txtHomePhone" MaxLength="8" Width="60px" meta:resourcekey="txtHomePhoneResource1" />
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:RegularExpressionValidator runat="server" ID="revHomePhone" ControlToValidate="txtHomePhone"
                                                                                                        Text="*" ToolTip="Home phone should be 8 digits" ErrorMessage="Home phone should be 8 digits"
                                                                                                        ValidationExpression="\d{8}" Display="Dynamic" meta:resourcekey="revHomePhoneResource1" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
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
                                                                                        <asp:Label runat="server" ID="lblAddress" Text="Address" Font-Bold="True" meta:resourcekey="lblAddressResource1" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label runat="server" ID="lblPostalCode" Text="Zip Code" Font-Bold="True" meta:resourcekey="lblPostalCodeResource1" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <asp:TextBox runat="server" ID="txtAddress" MaxLength="200" TextMode="MultiLine"
                                                                                            Rows="3" Width="315px" meta:resourcekey="txtAddressResource1" />
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:TextBox runat="server" ID="txtZipCode" MaxLength="8" Width="70px" meta:resourcekey="txtPostalCodeResource1" />
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
                                                                                        <asp:Label runat="server" ID="lblCity" Text="State" Font-Bold="True" meta:resourcekey="lblCityResource1" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    <asp:DropDownList runat="server" ID="ddlState" Width="120px" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlState_SelectedIndexChanged" meta:resourcekey="ddlCityResource1" />                                                                                       
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
                                                                                        <asp:Label runat="server" ID="lblNotificationPreference" Text="Notification Preference method through"
                                                                                            Font-Bold="True" meta:resourcekey="lblNotificationPreferenceResource1" />
                                                                                    </td>
                                                                                    <td style="width: 5px" />
                                                                                    <td>
                                                                                        <asp:CheckBox runat="server" ID="chkNotificationByEmail" Text="Email" Checked="True"
                                                                                            meta:resourcekey="chkNotificationByEmailResource1" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox runat="server" ID="chkNotificationBySMS" Text="Mobile" meta:resourcekey="chkNotificationBySMSResource1" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
            <tr>
                <td style="height: 15px" />
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:CheckBox runat="server" ID="chkDisclaimerYes" meta:resourcekey="chkDisclaimerResource1"
                                                Text="I Agree" />
                                        </td>
                                        <td style="width: 5px" />
                                        <td>
                                            <asp:CustomValidator Text="*" runat="server" ID="cvrDisclaimer" meta:resourcekey="cvrDisclaimerResource1"
                                                ClientValidationFunction="validateDisclaimer" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HyperLink ID="hypDisclaimer" runat="server" Text="Terms &amp; Conditions" NavigateUrl="http://www.google.com"></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 15px" />
            </tr>
            <tr>
                <td align="center">
                    <asp:Button runat="server" ID="Submit" Text="Submit" Width="100px" OnClick="btnSubmit_Click"
                        meta:resourcekey="SubmitResource1" />
                </td>
            </tr>
            <tr>
                <td style="height: 5px" />
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
