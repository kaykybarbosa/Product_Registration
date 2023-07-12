<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="RegisterProducts._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <html>
    <head>
        <title></title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-9ndCyUaIbzAi2FUVXJi0CjmCapSmO7SnpJef0486qhLnuZ2cdeRhO02iuK6FUUVM" crossorigin="anonymous">
    </head>
    <body>
        <div style="background-color:gray; color: black; font-size:xx-large;" align="center"> Product Registration </div>
    <br />
    <div style="display: flex; flex-direction: column; align-items: center; justify-content: center; padding: 15px" align="center">
        
        <div style="display: flex;">
            <table class="w-100" style="display: flex; align-items: center; justify-content: center;">
                <tr>
                    <td style="width: 326px; height: 36px;">
                        <asp:Label ID="labelproductid" runat="server" Font-Bold="True" Font-Size="Medium" Text="Product_Id"></asp:Label>
                    </td>
                    <td style="height: 27px">
                        <asp:TextBox ID="txtproductid" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                    
                    </td>
                </tr>
                <tr>
                    <td style="width: 326px; height: 36px;">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="Name"></asp:Label>
                    </td>
                    <td style="height: 27px">
                        <asp:TextBox ID="txtname" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 326px; height: 36px;">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" Text="Specification"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtspecification" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 326px; height: 36px;">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" Text="Quantity"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtquantity" runat="server" Font-Size="Medium" Width="200px" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 326px; height: 36px;">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" Text="Color"></asp:Label>
                    </td>
                    <td style="height: 21px">
                        <asp:TextBox ID="txtcolor" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 326px; height: 36px;">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Medium" Text="Registration Date"></asp:Label>
                    </td>
                    <td style="height: 19px">
                        <asp:TextBox ID="txtregistrationdate" runat="server" CssClass="accordion-header" Font-Size="Medium" Height="25px" Width="200px" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 326px; height: 36px;">
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Medium" Text="Status"></asp:Label>
                    </td>
                    <td style="height: 36px">
                        <asp:CheckBox ID="checkregular" runat="server" BorderStyle="None" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Text="Available" Width="94px" Style="margin-left: 0px" />
                        <asp:CheckBox ID="checkinregular" runat="server" Font-Bold="True" Font-Size="Medium" Height="20px" Style="margin-left: 0px" Text="Unavailable" />
                    </td>
                </tr>
            </table>
            <div style=" margin-left: 20px; border-radius: 12px;">
                <asp:Button ID="btnsearch" runat="server" BackColor="#0099FF" BorderColor="#666666" Font-Bold="True" Font-Size="Medium" Text="Search" Width="87px" CssClass="btn" />
            </div>
        </div>
        
        <br />
        <div style="display: inline-block; align-items: center;">
            <div style="display: inline-block; margin-right: 13px; border-radius: 12px;"> <asp:Button ID="btnsave" runat="server" BackColor="#0099FF" BorderColor="#666666" Font-Bold="True" Font-Size="Medium" Text="Save" Width="87px" CssClass="btn"/> </div>
            <div style="display: inline-block; margin-right: 13px; border-radius: 12px;"> <asp:Button ID="btnuptade" runat="server" BackColor="#0099FF" BorderColor="#666666" Font-Bold="True" Font-Size="Medium" Text="Update" Width="87px" CssClass="btn" /> </div>
            <div style="display: inline-block; border-radius: 13px;"> <asp:Button ID="btnclear" runat="server" BackColor="#0099FF" BorderColor="#666666" Font-Bold="True" Font-Size="Medium" Text="Clear" Width="87px" CssClass="btn" /> </div>
            <div style="display: inline-block; margin-left: 13px; border-radius: 12px;"> <asp:Button ID="btndelete" runat="server" BackColor="#CC3300" BorderColor="#666666" Font-Bold="True" Font-Size="Medium" Text="Delete" Width="87px" CssClass="btn" OnClientClick="return confirm('Are you sure to delete?')" /> </div>
        </div>
        <br />

        <br />
        <div class="container">
            <asp:GridView ID="gridview" CssClass="table table-responsive table-bordered table-condesed table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="PRODUCT_ID" HorizontalAlign="Center" AutoGenerateSelectButton="True">
                <Columns>
                    <asp:BoundField DataField="PRODUCT_ID" HeaderText="PRODUCT_ID" InsertVisible="False" ReadOnly="True" SortExpression="PRODUCT_ID" />
                    <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                    <asp:BoundField DataField="SPECIFICATION" HeaderText="SPECIFICATION" SortExpression="SPECIFICATION" />
                    <asp:BoundField DataField="QUANTITY" HeaderText="QUANTITY" SortExpression="QUANTITY" />
                    <asp:BoundField DataField="COLOR" HeaderText="COLOR" SortExpression="COLOR" />
                    <asp:BoundField DataField="REGISTRATION_DATE" HeaderText="REGISTRATION_DATE" SortExpression="REGISTRATION_DATE" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                </Columns>
                <HeaderStyle HorizontalAlign="Center" Font-Size="Medium" CssClass="table table-primary"/>
                <PagerStyle BorderStyle="Solid" />
                <RowStyle BorderStyle="Solid" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PRODUCT_REGISTERConnectionString %>" SelectCommand="SELECT * FROM [PRODUCTS]"></asp:SqlDataSource>
        </div>

    </div>

    </body>
    </html>

</asp:Content>
