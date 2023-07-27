<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="RegisterProducts._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="form-container">
    <div class="form-image">
        <asp:Image ID="imgInformation" runat="server" ImageUrl="/Images/Avg/undraw_add_information_j2wg.svg"/>
    </div>

    <div class="form">

        <div class="information-box">
            <asp:Label ID="lblInformation" CssClass="" runat="server" Text="" Visible="false"></asp:Label>
        </div>

        <header class="form-header">
            <div class="title">
                <h1>Product Registration</h1>
            </div>

            <div class="search-button">
                <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="\Images\lupa.png" ToolTip="Search" width="30px" Height="30px"/>
            </div>
        </header>
            
        <main class="input-group">
            <div class="fields">
                <asp:Label ID="lblProductId" CssClass="labelForm" runat="server" Text="Nº Product"></asp:Label>
                <asp:TextBox ID="txtProductid" CssClass="textBox" runat="server" TextMode="Number"></asp:TextBox>
            </div>

            <div class="fields">
                <asp:Label ID="lblName" CssClass="labelForm" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="txtName" CssClass="textBox" runat="server"></asp:TextBox>
                <asp:Label ID="lblRulesName" CssClass="rule-message" runat="server" Text="Name length cannot be longer than 60 characters." Visible="false"></asp:Label>
            </div>
           
            <div class="fields">
                <asp:Label ID="lblQuantity" CssClass="labelForm" runat="server" Text="Quantity"></asp:Label> 
                <asp:TextBox ID="txtQuantity" CssClass="textBox" runat="server" TextMode="Number"></asp:TextBox>
            </div>

            <div class="fields">
                <asp:Label ID="lblColor" CssClass="labelForm" runat="server" Text="Color"></asp:Label> 
                <asp:TextBox ID="txtColor" CssClass="textBox" runat="server"></asp:TextBox>
                <asp:Label ID="lblRulesColor" CssClass="rule-message" runat="server" Text="Make sure it doesn't exceed 30 characters." Visible="false"></asp:Label>
            </div>

            <div class="fields">
                <asp:Label ID="lblRegistrationDate" CssClass="labelForm" runat="server" Text="Registration Date"></asp:Label> 
                <asp:TextBox ID="txtRegistrationDate" CssClass="accordion-header textBox registerDate" runat="server" TextMode="Date"></asp:TextBox>
            </div>

             <div class="fields">
                <asp:Label ID="lblStatus" CssClass="labelForm" runat="server" Text="Status" ></asp:Label> 
                 <asp:CheckBoxList ID="checkStatus" runat="server" CssClass="textBox" RepeatDirection="Horizontal">
                     <asp:ListItem Text="Available"></asp:ListItem>
                     <asp:ListItem Text="Unavailable"></asp:ListItem>
                 </asp:CheckBoxList>
            </div> 

            <div class="fields"> 
                <asp:Label ID="lblSpecification" CssClass="labelForm" runat="server" Text="Specification"></asp:Label> 
                <asp:TextBox ID="txtSpecification" CssClass="textBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                <asp:Label ID="lblRulesSpecification" CssClass="rule-message" runat="server" Text="Make sure it doesn't exceed 255 characters." Visible="false"></asp:Label>
            </div>
        </main>

        <div class="buttons">
            <asp:Button ID="btnSave" CssClass="btn btnHover btn-sm" runat="server" Text="Save" Width="87px"/>
            <asp:Button ID="btnUpdate" CssClass="btn btnHover btn-sm" runat="server" Text="Update" Width="87px"/>
            <asp:Button ID="btnClear" CssClass="btn btnHover btn-sm" runat="server" Text="Clear" Width="87px"/>
        </div>
    </div>

</div>

<div class="gridProducts">
    <asp:GridView ID="gridView" CssClass=" table table-responsive table-bordered table-condesed gridView" runat="server" AllowPaging="true" PageSize="5" AutoGenerateColumns="False" DataKeyNames="PRODUCT_ID"
        HorizontalAlign="Center" AllowSorting="True" BorderColor="MidnightBlue" HeaderStyle-BorderColor="MidnightBlue">
            
        <Columns>
            <asp:BoundField DataField="PRODUCT_ID" HeaderText="Nº" SortExpression="PRODUCT_ID" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
            <asp:BoundField DataField="SPECIFICATION" HeaderText="SPECIFICATION" SortExpression="SPECIFICATION" />
            <asp:BoundField DataField="QUANTITY" HeaderText="QUANTITY" SortExpression="QUANTITY" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="COLOR" HeaderText="COLOR" SortExpression="COLOR"/>
            <asp:BoundField DataField="REGISTRATION_DATE" HeaderText="REGISTRATION_DATE" SortExpression="REGISTRATION_DATE" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" ItemStyle-HorizontalAlign="Center"/>

            <asp:ButtonField DataTextField="PRODUCT_ID" ButtonType="Image" CommandName="Select" HeaderText="" ShowHeader="True" Text="SELECT" ImageUrl="/Images/selecione.png"
                ControlStyle-Width="21px" ItemStyle-HorizontalAlign="Center"/>
            
            <asp:ButtonField DataTextField="PRODUCT_ID" CommandName="Delete" ButtonType="Image" HeaderText="" ShowHeader="True" ImageUrl="/Images/excluir.png"
                ControlStyle-Width="20px" ItemStyle-HorizontalAlign="Center"/>

        </Columns>
            
        <HeaderStyle HorizontalAlign="Center" CssClass="table table-primary" Font-Size="Medium" ForeColor="MidnightBlue"/>
        <PagerStyle HorizontalAlign="Center"/>
        <RowStyle BorderStyle="Solid" />

    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StringConectionRegisterProduct%>" SelectCommand="SELECT * FROM [PRODUCTS]"></asp:SqlDataSource>
</div>
<asp:Label ID="lblCounter" CssClass="counter badge" runat="server" Text="Label"></asp:Label>

</asp:Content>