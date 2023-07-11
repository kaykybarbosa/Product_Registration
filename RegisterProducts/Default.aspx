<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="RegisterProducts._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color:gray; color: black; font-size:xx-large;" align="center">
        Product Registration
    </div>
    <br />
    <div style="display: flex; flex-direction: column; align-items: center; justify-content: center; padding: 15px" align="center">

        <table class="w-100" style="display: flex; align-items: center; justify-content: center;">
            <tr>
                <td style="width: 326px; height: 27px;">
                    <asp:Label ID="labelproductid" runat="server" Font-Bold="True" Font-Size="Medium" Text="Product_Id"></asp:Label>
                </td>
                <td style="height: 27px">
                    <asp:TextBox ID="txtproductid" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 27px;">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="Name"></asp:Label>
                </td>
                <td style="height: 27px">
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
                    <asp:CheckBox ID="checkregular" runat="server" BorderStyle="None" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Text="Available" Width="94px" Style="margin-left: 0px" />
                    <asp:CheckBox ID="checkinregular" runat="server" Font-Bold="True" Font-Size="Medium" Height="20px" Style="margin-left: 0px" Text="Unavailable" />
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 23px;"></td>
                <td style="height: 23px"></td>
            </tr>
        </table>
        <div style="display: flex; justify-content: flex-start; margin-bottom: 12px;">
            <asp:Button ID="btnsave" runat="server" BackColor="Gray" BorderColor="#666666" Font-Bold="True" Font-Size="Medium" Text="Save" Width="87px" CssClass="offset-sm-0" BorderStyle="Double" />
            <asp:Button ID="btndelete" runat="server" BackColor="Gray" BorderColor="#666666" Font-Bold="True" Font-Size="Medium" Text="Delete" Width="87px" OnClientClick="return confirm('Are you sure to delete?')" />
            <asp:Button ID="btnuptade" runat="server" BackColor="Gray" BorderColor="#666666" Font-Bold="True" Font-Size="Medium" Text="Update" Width="87px" />
            <asp:Button ID="btnsearch" runat="server" BackColor="Gray" BorderColor="#666666" Font-Bold="True" Font-Size="Medium" Text="Search" Width="87px" CssClass="offset-sm-0" />
        </div>
        <div align="center">
            <br />
            <asp:GridView ID="gridview" runat="server" Width="80%" BackColor="Silver" BorderColor="#666666" ShowHeaderWhenEmpty="True" AllowPaging="True"
                AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="PRODUCT_ID" ForeColor="White" Height="106px">
                <Columns>
                    <asp:BoundField DataField="PRODUCT_ID" HeaderText="PRODUCT_ID" SortExpression="PRODUCT_ID">
                        <HeaderStyle BackColor="Black" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME">
                        <HeaderStyle BackColor="Black" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SPECIFICATION" HeaderText="SPECIFICATION" SortExpression="SPECIFICATION">
                        <HeaderStyle BackColor="Black" />
                    </asp:BoundField>
                    <asp:BoundField DataField="QUANTITY" HeaderText="QUANTITY" SortExpression="QUANTITY">
                        <HeaderStyle BackColor="Black" />
                    </asp:BoundField>
                    <asp:BoundField DataField="COLOR" HeaderText="COLOR" SortExpression="COLOR">
                        <HeaderStyle BackColor="Black" />
                    </asp:BoundField>
                    <asp:BoundField DataField="REGISTRATION_DATE" HeaderText="REGISTRATION_DATE" SortExpression="REGISTRATION_DATE" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle BackColor="Black" s/>
                    </asp:BoundField>
                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS">
                        <HeaderStyle BackColor="Black" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PRODUCT_REGISTERConnectionString %>" ProviderName="<%$ ConnectionStrings:PRODUCT_REGISTERConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [PRODUCTS]"></asp:SqlDataSource>
            <br />

        </div>

    </div>

</asp:Content>
