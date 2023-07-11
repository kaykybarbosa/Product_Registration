<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="RegisterProducts._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color:gray; color: black; font-size:xx-large;" align="center">
        Product Registration
    </div>
    <br />
    <div style="display: flex; flex-direction: row; align-items: center; justify-content: center;padding:15px" align="center"> 

        <table class="w-100">
            <tr>
                <td style="width: 326px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtname" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="Specification"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtspecification" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" Text="Quantity"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtquantity" runat="server" Font-Size="Medium" Width="200px" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 21px;">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" Text="Color"></asp:Label>
                </td>
                <td style="height: 21px">
                    <asp:TextBox ID="txtcolor" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 19px;">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" Text="Registration Date"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtregistrationdate" runat="server" CssClass="accordion-header" Font-Size="Medium" Height="25px" Width="200px" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 22px;">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" Text="Status"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:CheckBox ID="checkregular" runat="server" BorderStyle="None" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Text="Available" Width="94px" style="margin-left: 0px" />
                    <asp:CheckBox ID="checkinregular" runat="server" Font-Bold="True" Font-Size="Medium" Height="20px" style="margin-left: 0px" Text="Unavailable" />
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 23px;"></td>
                <td style="height: 23px"></td>
            </tr>
            <tr>
                <td style="width: 326px">&nbsp;</td>
                <td style="margin: 20px 15px 30px 40px;">
                    <asp:Button ID="btnsave" runat="server" BackColor="Gray" BorderColor="#666666" Font-Bold="True" Font-Size="Medium" Text="Save" Width="87px" />
                    <asp:Button ID="btndelete" runat="server" BackColor="Gray" BorderColor="#666666" Font-Bold="True" Font-Size="Medium" Text="Delete" Width="87px" />
                </td>
            </tr>
        </table>
        <div align="center">
            <br />
            <asp:GridView ID="gridview" runat="server" BackColor="#999999" ForeColor="#333333" Width="80%">
            </asp:GridView>

        </div>

    </div>

</asp:Content>
