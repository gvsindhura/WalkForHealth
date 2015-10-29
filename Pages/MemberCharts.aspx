<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberCharts.aspx.cs" Inherits="WebApplication1.Pages.MemberCharts"
    MasterPageFile="MasterPage.Master" %>

<%@ Register Assembly="am.Charts" Namespace="am.Charts" TagPrefix="ac" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder">
    <table>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>&nbsp;Display Charts By</b>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2">
                <table>
                    <tr>
                        <td style="width: 100px;">
                            <asp:RadioButton ID="rbtnChartGender" runat="server" GroupName="Charts" Text="Gender"
                                Font-Size="Large" AutoPostBack="true" OnCheckedChanged="rbtnChart_CheckedChanged" />
                        </td>
                        <td style="width: 100px;">
                            <asp:RadioButton ID="rbtnChartState" runat="server" GroupName="Charts" Checked="true"
                                Text="State" AutoPostBack="true" Font-Size="Large" OnCheckedChanged="rbtnChart_CheckedChanged" />
                        </td>
                        <td style="width: 100px;">
                            <asp:RadioButton ID="rbtnChartAge" runat="server" GroupName="Charts" Text="Age" AutoPostBack="true"
                                Font-Size="Large" OnCheckedChanged="rbtnChart_CheckedChanged" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div runat="server" id="pnlChartGender">
        <br />
        <table border="0" cellpadding="1" cellspacing="1" width="100%" class="Grid">
            <tr class="GridHeader_AL">
                <td colspan="2">
                    <b>&nbsp;Members Chart By Gender</b>
                </td>
            </tr>
            <tr class="GridRow_AL">
                <td style="width: 70px">
                    &nbsp;State:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlStateByGender" Width="120" />
                </td>
            </tr>
            <tr class="GridAlter_AL">
                <td>
                    &nbsp;Age:
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                From
                            </td>
                            <td>
                                To
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlFromAgeByGender" Width="60" />
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlToAgeByGender" Width="60" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="GridRow_AL">
                <td colspan="2">
                    <asp:Button runat="server" Text="Search" ID="btnSearchByGender" OnClick="btnSearchByGender_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:XmlDataSource ID="xmlDSGenderSummaryReport" runat="server" XPath="/Metadata/AllValues/Row"
                        EnableCaching="false" EnableViewState="true" />
                    <ac:LineChart ID="lctGender" runat="server" DataSeriesIDField="Gender" Width="700"
                        Height="400" VerticalLinesClustered="true" EnableViewState="false" UseAjaxIfAvailable="true"
                        Bullet="RoundOutlined" VerticalLinesWidth="25" Colors="Green,LightGreen" LegendMaxColumns="3"
                        XGridApproxLineCount="36" YRightGridApproxLineCount="100" XValuesRotate="90"
                        LegendEnabled="false" Connect="true" Precision="0" DigitsAfterDecimal="0" BalloonColor="Black"
                        BalloonAlpha="50" BackColor="Transparent" AddTimeStamp="true" LegendAlign="Center"
                        ThousandsSeparator=",">
                        <Graphs>
                            <ac:LineChartGraph ID="lcgGender" runat="server" DataSeriesItemIDField="Gender" DataValueField="MemberCount"
                                Title="MemberCount" BulletSize="3" VerticalLines="true" LineAlpha="0" DataLabelPosition="Above"
                                LineWidth="25">
                            </ac:LineChartGraph>
                        </Graphs>
                    </ac:LineChart>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblGender" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div id="pnlChartState" runat="server">
        <br />
        <table border="0" cellpadding="1" cellspacing="1" width="100%" class="Grid">
            <tr class="GridHeader_AL">
                <td colspan="2">
                    <b>&nbsp;Members Chart By State</b>
                </td>
            </tr>
            <tr class="GridRow_AL">
                <td style="width: 70px">
                    &nbsp;Gender:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlGenderByState" Width="120">
                        <asp:ListItem Text="-Any-" Value="" />
                        <asp:ListItem Text="Female" Value="0" />
                        <asp:ListItem Text="Male" Value="1" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="GridAlter_AL">
                <td>
                    &nbsp;Age:
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                From
                            </td>
                            <td>
                                To
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlFromAgeByState" Width="60" />
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlToAgeByState" Width="60" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="GridRow_AL">
                <td colspan="2">
                    <asp:Button runat="server" Text="Search" ID="btnSearchByState" OnClick="btnSearchByState_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:XmlDataSource ID="xmlDSStateSummaryReport" runat="server" XPath="/Metadata/AllValues/Row"
                        EnableCaching="false" EnableViewState="true" />
                    <ac:LineChart ID="lctState" runat="server" DataSeriesIDField="State" Width="700"
                        Height="400" VerticalLinesClustered="true" EnableViewState="false" UseAjaxIfAvailable="true"
                        Bullet="RoundOutlined" VerticalLinesWidth="25" Colors="Orange,Blue" LegendMaxColumns="3"
                        XGridApproxLineCount="36" YRightGridApproxLineCount="100" XValuesRotate="90"
                        LegendEnabled="false" Connect="true" Precision="0" DigitsAfterDecimal="0" BalloonColor="Black"
                        BalloonAlpha="50" BackColor="Transparent" AddTimeStamp="true" LegendAlign="Center"
                        ThousandsSeparator=",">
                        <Graphs>
                            <ac:LineChartGraph ID="lcgState" runat="server" DataSeriesItemIDField="State" DataValueField="MemberCount"
                                Title="MemberCount" BulletSize="3" VerticalLines="true" LineAlpha="0" DataLabelPosition="Above"
                                LineWidth="25">
                            </ac:LineChartGraph>
                        </Graphs>
                    </ac:LineChart>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="lblState" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <div id="pnlChartAge" runat="server">
        <br />
        <table border="0" cellpadding="1" cellspacing="1" width="100%" class="Grid">
            <tr class="GridHeader_AL">
                <td colspan="2">
                    <b>&nbsp;Members Chart By Age</b>
                </td>
            </tr>
            <tr class="GridRow_AL">
                <td style="width: 70px">
                    &nbsp;State:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlStateByAge" Width="120" />
                </td>
            </tr>
            <tr class="GridAlter_AL">
                <td>
                    &nbsp;Gender:
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlGenderByAge" Width="120">
                        <asp:ListItem Text="-Any-" Value="" />
                        <asp:ListItem Text="Female" Value="0" />
                        <asp:ListItem Text="Male" Value="1" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="GridRow_AL">
                <td colspan="2">
                    <asp:Button runat="server" Text="Search" ID="btnSearchByAge" OnClick="btnSearchByAge_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:XmlDataSource ID="xmlDSAgeSummaryReport" runat="server" XPath="/Metadata/AllValues/Row"
                        EnableCaching="false" EnableViewState="true" />
                    <ac:LineChart ID="lctAge" runat="server" DataSeriesIDField="Age" Width="700" Height="400"
                        VerticalLinesClustered="true" EnableViewState="false" UseAjaxIfAvailable="true"
                        Bullet="RoundOutlined" VerticalLinesWidth="25" Colors="Red,Orange" LegendMaxColumns="3"
                        XGridApproxLineCount="36" YRightGridApproxLineCount="100" XValuesRotate="90"
                        LegendEnabled="false" Connect="true" Precision="0" DigitsAfterDecimal="0" BalloonColor="Black"
                        BalloonAlpha="50" BackColor="Transparent" AddTimeStamp="true" LegendAlign="Center"
                        ThousandsSeparator=",">
                        <Graphs>
                            <ac:LineChartGraph ID="lcgAge" runat="server" DataSeriesItemIDField="Age" DataValueField="MemberCount"
                                Title="MemberCount" BulletSize="3" VerticalLines="true" LineAlpha="0" DataLabelPosition="Above"
                                LineWidth="25">
                            </ac:LineChartGraph>
                        </Graphs>
                    </ac:LineChart>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblAge" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hidWalkingStepCalculatorTypesByAge" runat="server" />
    <asp:HiddenField ID="hidWalkingStepCalculatorTypesByGender" runat="server" />
    <asp:HiddenField ID="hidWalkingStepCalculatorTypesByState" runat="server" />
</asp:Content>
