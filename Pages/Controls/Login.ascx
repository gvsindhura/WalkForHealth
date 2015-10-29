<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="WebApplication1.Pages.Controls.Login" %>
<asp:HiddenField runat="server" ID="hidLoginTrialCount" Value="0" />
<table border="0" cellpadding="0" cellspacing="0" width="280px">
    <tr class="GridHeader_AL" style="">
        <td valign="middle" runat="server" id="tdLoginHeader" style="height: 25px; width: 100%; border-left: 0;
            border-right: 0; border-top-left-radius: 10px; -moz-border-top-left-radius: 10px;
            -webkit-border-top-left-radius: 10px; border-top-right-radius: 10px; -moz-border-top-right-radius: 10px;
            -webkit-border-top-right-radius: 10px;">
            &nbsp;&nbsp;<asp:Label Font-Bold="true" ForeColor="White" runat="server" ID="lblMemberLoginHeader"
                Text="Member Login" meta:resourcekey="lblMemberLoginHeaderResource" />
        </td>
    </tr>
    <tr>
        <td style="background-color: rgb(238,238,238); height: 149px; border-color: Green;
            border-style: solid; border-width: 1px; ">
            <asp:ValidationSummary runat="server" ID="vdsSummary" ValidationGroup="Login" />
            <table cellpadding="2" cellspacing="1" style="">
                <tr>
                    <td style="width: 60px">
                        <asp:Label runat="server" ID="lblUserName" Font-Bold="true" meta:resourcekey="lblUserNameResource" />
                    </td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtUserName" Width="150" MaxLength="32" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator Text="*" runat="server" ID="rfvUserName" ControlToValidate="txtUserName"
                                        ToolTip="Username is required" Display="Dynamic" meta:resourcekey="rfvUserNameResource"
                                        ValidationGroup="Login" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblPassword" Font-Bold="true" meta:resourcekey="lblPasswordResource" />
                    </td>
                    <td>
                        <table border="0" cellpadding="1" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" Width="150" MaxLength="16" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator Text="*" runat="server" ID="rfvPassword" ControlToValidate="txtPassword"
                                        ToolTip="Password is required" Display="Dynamic" meta:resourcekey="rfvPasswordResource"
                                        ValidationGroup="Login" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td />
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btnSignIn" Text="Sign In" Width="60" Height="25" meta:resourcekey="btnSignInResource"
                                        OnClick="btnSignIn_Click" ValidationGroup="Login" Style="background-color: rgb(150,152,149);
                                        color: White" />
                                </td>
                                <td>
                                    <asp:CheckBox runat="server" ID="chkRememberMe" Text="Remember Me" meta:resourcekey="chkRememberMeResource" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:HyperLink runat="server" ID="lnkForgotPassword" Text="Forgot Password" NavigateUrl="~/ForgotPassword.aspx"
                                        meta:resourcekey="lnkForgotPasswordResource" Style="color: rgb(150,152,149);" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label CssClass="Note" runat="server" Font-Bold="true" ID="lblNotMemberYet" meta:resourcekey="lblNotMemberYet" />
                                </td>
                                <td runat="server" id="tdRegister">
                                    <asp:Button runat="server" ID="btnRegister" CausesValidation="false" Text="Register"
                                        OnClick="btnRegister_Click" meta:resourcekey="btnRegister" Height="30" Width="120"
                                        Style="background-color: rgb(150,152,149); color: White" Font-Size="10" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
