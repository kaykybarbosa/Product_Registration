<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="RegisterProducts._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="bg-primary-subtle title"> Product Registration </div>
    
    <div class="divForm">
        <div class="fields">
            <asp:Label ID="lblProductid" runat="server" Font-Bold="True" Font-Size="Medium" Text="Nº Product"></asp:Label>
            <asp:TextBox ID="txtProductid" CssClass="textBox" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
        </div>

        <div class="fields">
            <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="Medium" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" CssClass="textBox" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
        </div>
           
        <div class="fields">
            <asp:Label ID="lblQuantity" runat="server" Font-Bold="True" Font-Size="Medium" Text="Quantity"></asp:Label> 
            <asp:TextBox ID="txtQuantity" CssClass="textBox" runat="server" Font-Size="Medium" Width="200px" TextMode="Number"></asp:TextBox>
        </div>

        <div class="fields">
            <asp:Button ID="btnSearch" CssClass="btn btn-outline-secondary btn-sm btnSearch" runat="server" Font-Bold="True" Text="Search" Width="87px"/>
        </div> <br />

        <div class="fields">
            <asp:Label ID="lblColor" runat="server" Font-Bold="True" Font-Size="Medium" Text="Color"></asp:Label> 
            <asp:TextBox ID="txtColor" CssClass="textBox" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
        </div>

        <div class="fields">
            <asp:Label ID="lblRegistrationDate" runat="server" Font-Bold="True" Font-Size="Medium" Text="Registration Date"></asp:Label> 
            <asp:TextBox ID="txtRegistrationDate" runat="server" CssClass="accordion-header textBox" Font-Size="Medium" Height="31px" Width="200px" TextMode="Date"></asp:TextBox>
        </div>

        <div class="fields">
            <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="Medium" Text="Status" ></asp:Label> 
            <asp:CheckBox ID="checkAvailable" CssClass="checkBox" runat="server" Font-Bold="True" Font-Size="Medium" Text="Available" /> <!--AutoPostBack=true-->
            <asp:CheckBox ID="checkUnavailable" CssClass="checkBox left" runat="server" Font-Bold="True" Font-Size="Medium" Text="Unavailable"/>
        </div> 
        
        <br style="clear: both"/>

        <div class="fields"> 
            <asp:Label ID="lblSpecification" runat="server" Font-Bold="True" Font-Size="Medium" Text="Specification"></asp:Label> 
            <asp:TextBox ID="txtSpecification" CssClass="textBox" runat="server" Font-Size="Medium" TextMode="MultiLine"></asp:TextBox>
        </div>
        
    </div>
    
    <div style="clear: both"></div>

    <div class="divBtns">
        <asp:Button ID="btnSave" runat="server" Font-Bold="True" Text="Save" Width="87px" CssClass="btn btn-outline-primary btn-sm"/>
        <asp:Button ID="btnUptade" runat="server" Font-Bold="True" Text="Update" Width="87px" CssClass="btn btn-outline-primary btn-sm"/>
        <asp:Button ID="btnDelete" runat="server" Font-Bold="True" Text="Delete" Width="87px" CssClass="btn btn-outline-primary btn-sm" OnClientClick="return confirm('Are you sure to delete?')" />
        <asp:Button ID="btnClear" runat="server" Font-Bold="True" Text="Clear" Width="87px" CssClass="btn btn-outline-primary btn-sm" />
    </div>

    <div>
        <asp:GridView ID="gridView" CssClass=" table table-responsive table-bordered table-condesed table-hover gridView" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="PRODUCT_ID" HorizontalAlign="Center" AllowSorting="True">
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
            <PagerStyle HorizontalAlign="Center"/>
            <RowStyle BorderStyle="Solid" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PRODUCT_REGISTERConnectionString %>" SelectCommand="SELECT * FROM [PRODUCTS]"></asp:SqlDataSource>
        <asp:Label ID="lblProducts" CssClass="counter badge" runat="server" Text="Label"></asp:Label>
    </div>

</asp:Content>
