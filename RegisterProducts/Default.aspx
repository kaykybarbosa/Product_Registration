<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="RegisterProducts._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Css\GridView.css" rel="stylesheet" type="text/css"/>

    <style>
        .myPagination{
            margin: 0 10px;
            color: mediumpurple;
        }
    </style>

    <div style=" font-size:xx-large;" align="center" class="bg-primary-subtle"> Product Registration </div>
    <br />
    
    <div class="container" style="display: flex; flex-direction: row; align-items: center; justify-content: center">
        <table class="w-50" style="display: flex; align-items: center; justify-content: center;">
            <tr>
                <td style="width: 326px; height: 36px;">
                    <asp:Label ID="lblProductid" runat="server" Font-Bold="True" Font-Size="Medium" Text="Nº Product"></asp:Label>
                </td>
                <td style="height: 27px">
                    <asp:TextBox ID="txtProductid" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 36px;">
                    <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="Medium" Text="Name"></asp:Label>
                </td>
                <td style="height: 27px">
                    <asp:TextBox ID="txtName" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 36px;">
                    <asp:Label ID="lblSpecification" runat="server" Font-Bold="True" Font-Size="Medium" Text="Specification"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSpecification" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 36px;">
                    <asp:Label ID="lblQuantity" runat="server" Font-Bold="True" Font-Size="Medium" Text="Quantity"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server" Font-Size="Medium" Width="200px" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 36px;">
                    <asp:Label ID="lblColor" runat="server" Font-Bold="True" Font-Size="Medium" Text="Color"></asp:Label>
                </td>
                <td style="height: 21px">
                    <asp:TextBox ID="txtColor" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 36px;">
                    <asp:Label ID="lblRegistrationDate" runat="server" Font-Bold="True" Font-Size="Medium" Text="Registration Date"></asp:Label>
                </td>
                <td style="height: 36px">
                    <asp:TextBox ID="txtRegistrationDate" runat="server" CssClass="accordion-header" Font-Size="Medium" Height="25px" Width="200px" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 326px; height: 36px;">
                    <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="Medium" Text="Status" ></asp:Label>
                </td>
                <td style="height: 36px">
                    <asp:CheckBox ID="checkAvailable" runat="server" BorderStyle="None" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Text="Available" Width="94px" Style="margin-left: 0px" />
                    <asp:CheckBox ID="checkUnavailable" runat="server" Font-Bold="True" Font-Size="Medium" Height="20px" Style="margin-left: 0px" Text="Unavailable" />
                </td>
            </tr>
        </table>
        <div style=" align-self: flex-start;">
            <asp:Button ID="btnSearch" runat="server" Font-Bold="True" Font-Size="Medium" Text="Search" Width="87px" CssClass="btn btn-outline-secondary btn-sm"/>
        </div>
    </div>
        
    <br />
    <div style="display: inline-block; align-items: center; display: flex; justify-content: center">
        <div style="display: inline-block; margin-right: 13px;"> <asp:Button ID="btnSave" runat="server" Font-Bold="True" Font-Size="Medium" Text="Save" Width="87px" CssClass="btn btn-outline-primary btn-sm"/> </div>
        <div style="display: inline-block; margin-right: 13px;"> <asp:Button ID="btnUptade" runat="server" Font-Bold="True" Font-Size="Medium" Text="Update" Width="87px" CssClass="btn btn-outline-primary btn-sm"/> </div>
        <div style="display: inline-block; border-radius: 13px;"> <asp:Button ID="btnClear" runat="server" Font-Bold="True" Font-Size="Medium" Text="Clear" Width="87px" CssClass="btn btn-outline-primary btn-sm" /> </div>
        <div style="display: inline-block; margin-left: 13px;"> <asp:Button ID="btnDelete" runat="server" Font-Bold="True" Font-Size="Medium" Text="Delete" Width="87px" CssClass="btn btn-outline-primary btn-sm" OnClientClick="return confirm('Are you sure to delete?')" /> </div>
    </div>
    <br />

    <br />
    <div class="container">
        <asp:GridView ID="gridView" CssClass=" table table-responsive table-bordered table-condesed table-hover " runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="PRODUCT_ID" HorizontalAlign="Center" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="PRODUCT_ID" HeaderText="Nº" SortExpression="PRODUCT_ID" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                <asp:BoundField DataField="SPECIFICATION" HeaderText="SPECIFICATION" SortExpression="SPECIFICATION" />
                <asp:BoundField DataField="QUANTITY" HeaderText="QUANTITY" SortExpression="QUANTITY" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="COLOR" HeaderText="COLOR" SortExpression="COLOR"/>
                <asp:BoundField DataField="REGISTRATION_DATE" HeaderText="REGISTRATION_DATE" SortExpression="REGISTRATION_DATE" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" ItemStyle-HorizontalAlign="Center"/>
            </Columns>
            <HeaderStyle HorizontalAlign="Center" Font-Size="Medium" CssClass="table table-primary"/>
            <PagerStyle HorizontalAlign="Center" BorderStyle="Solid" Font-Size="Larger" VerticalAlign="Bottom" BorderWidth="3px" />
            <RowStyle BorderStyle="Solid" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PRODUCT_REGISTERConnectionString %>" SelectCommand="SELECT * FROM [PRODUCTS]"></asp:SqlDataSource>
        <asp:Label ID="lblProducts" runat="server" Text="Label" CssClass="badge" BackColor="#66CCFF"></asp:Label>
    </div>

</asp:Content>
