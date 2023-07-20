﻿<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="RegisterProducts._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="form-container">
    <div class="form-image">
        <asp:Image ID="imgInformation" runat="server" ImageUrl="/Images/Avg/undraw_add_information_j2wg.svg"/>
    </div>

    <div class="form">
            
        <div class="form-header">
            <div class="title">
                <h1>Product Registration</h1>
            </div>

            <div class="search-button">
                <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="\Images\lupa.png" ToolTip="Search" width="30px" Height="30px"/>
            </div>
        </div>
            
        <div class="input-group" style="left: 0px; top: 0px">

            <div class="fields">
                <asp:Label ID="lblProductId" CssClass="labelForm" runat="server" Text="Nº Product"></asp:Label>
                <asp:TextBox ID="txtProductid" CssClass="textBox" runat="server"></asp:TextBox>
            </div>

            <div class="fields">
                <asp:Label ID="lblName" CssClass="labelForm" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="txtName" CssClass="textBox" runat="server"></asp:TextBox>
            </div>
           
            <div class="fields">
                <asp:Label ID="lblQuantity" CssClass="labelForm" runat="server" Text="Quantity"></asp:Label> 
                <asp:TextBox ID="txtQuantity" CssClass="textBox" runat="server" TextMode="Number"></asp:TextBox>
            </div>

            <div class="fields">
                <asp:Label ID="lblColor" CssClass="labelForm" runat="server" Text="Color"></asp:Label> 
                <asp:TextBox ID="txtColor" CssClass="textBox" runat="server"></asp:TextBox>
            </div>

            <div class="fields">
                <asp:Label ID="lblRegistrationDate" CssClass="labelForm" runat="server" Text="Registration Date"></asp:Label> 
                <asp:TextBox ID="txtRegistrationDate" CssClass="accordion-header textBox" runat="server" TextMode="Date" Width="255px"></asp:TextBox>
            </div>

             <div class="fields">
                <asp:Label ID="lblStatus" CssClass="labelForm" runat="server" Text="Status" ></asp:Label> 
                 <asp:CheckBoxList ID="checkStatus" runat="server" CssClass="textBox" Width="245px" RepeatDirection="Horizontal">
                     <asp:ListItem>Available</asp:ListItem>
                     <asp:ListItem>Unavailable</asp:ListItem>
                 </asp:CheckBoxList>
            </div> 

            <div class="fields"> 
                <asp:Label ID="lblSpecification" CssClass="labelForm" runat="server" Text="Specification"></asp:Label> 
                <asp:TextBox ID="txtSpecification" CssClass="textBox" runat="server" TextMode="MultiLine" Width="254px"></asp:TextBox>
            </div>

        </div>

        <div class="buttons">
            <asp:Button ID="btnSave" CssClass="btn btnHover btn-sm" runat="server" Text="Save" Width="87px"/>
            <asp:Button ID="btnUpdate" CssClass="btn btnHover btn-sm" runat="server" Text="Update" Width="87px"/>
            <asp:Button ID="btnClear" CssClass="btn btnHover btn-sm" runat="server" Text="Clear" Width="87px"/>
        </div>
    </div>
</div>

        <asp:CheckBox ID="checkAvailable" CssClass="checkBox" runat="server" Text="Available" /> <!--AutoPostBack=true-->
        <asp:CheckBox ID="checkUnavailable" CssClass="checkBox" runat="server" Text="Unavailable"/>

<div class="gridProducts">
    <asp:GridView ID="gridView" CssClass=" table table-responsive table-bordered table-condesed gridView" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="PRODUCT_ID"
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
            
        <HeaderStyle HorizontalAlign="Center" Font-Size="Medium" CssClass="table table-primary" ForeColor="MidnightBlue"/>
        <PagerStyle HorizontalAlign="Center"/>
        <RowStyle BorderStyle="Solid" />

    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StringConectionRegisterProduct%>" SelectCommand="SELECT * FROM [PRODUCTS]"></asp:SqlDataSource>
    <asp:Label ID="lblCounter" CssClass="counter badge" runat="server" Text="Label"></asp:Label>
</div>

    <%--Old--%>
 <%--   <div class="title">
        Product Registration 
    </div>--%>
    
    <%--<div class="divMain">--%>
        
       <%-- <div class="input-group form-check">
            
            <div class="fields">
                <asp:Label ID="lblProductId" CssClass="labelForm" runat="server" Font-Bold="True" Font-Size="Medium" Text="Nº Product"></asp:Label>
                <asp:TextBox ID="txtProductid" CssClass="textBox" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
            </div>

            <div class="fields">
                <asp:Label ID="lblName" CssClass="labelForm" runat="server" Font-Bold="True" Font-Size="Medium" Text="Name"></asp:Label>
                <asp:TextBox ID="txtName" CssClass="textBox" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
            </div>
           
            <div class="fields">
                <asp:Label ID="lblQuantity" CssClass="labelForm" runat="server" Font-Bold="True" Font-Size="Medium" Text="Quantity"></asp:Label> 
                <asp:TextBox ID="txtQuantity" CssClass="textBox" runat="server" Font-Size="Medium" Width="200px" TextMode="Number"></asp:TextBox>
            </div>

            <div class="fields">
                <asp:Label ID="lblColor" CssClass="labelForm" runat="server" Font-Bold="True" Font-Size="Medium" Text="Color"></asp:Label> 
                <asp:TextBox ID="txtColor" CssClass="textBox " runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
            </div>

            <div class="fields">
                <asp:Label ID="lblRegistrationDate" CssClass="labelForm" runat="server" Font-Bold="True" Font-Size="Medium" Text="Registration Date"></asp:Label> 
                <asp:TextBox ID="txtRegistrationDate" runat="server" CssClass="accordion-header textBox" Font-Size="Medium" Height="31px" Width="200px" TextMode="Date"></asp:TextBox>
            </div>

            <div class="fields">
                <asp:Label ID="lblStatus" CssClass="labelForm" runat="server" Font-Bold="True" Font-Size="Medium" Text="Status" ></asp:Label> 
                <asp:CheckBox ID="checkAvailable" CssClass="checkBox" runat="server" Font-Bold="True" Font-Size="Medium" Text="Available" /> <!--AutoPostBack=true-->
                <asp:CheckBox ID="checkUnavailable" CssClass="checkBox" runat="server" Font-Bold="True" Font-Size="Medium" Text="Unavailable"/>
            </div> 

        </div>--%>

      <%--  <div class="divBtnSearch">
            <asp:ImageButton ID="ImageButton1d" runat="server" ImageUrl="\Images\lupa.png" ToolTip="Search" width="50px" Height="50px"/>
        </div>--%>

    <%--</div>--%>
      
    <%--<div class="fields lblLeft"> 
        <asp:Label ID="lblSpecification" CssClass="labelForm" runat="server" Font-Bold="True" Font-Size="Medium" Text="Specification"></asp:Label> 
        <asp:TextBox ID="txtSpecification" CssClass="textBox" runat="server" Font-Size="Medium" TextMode="MultiLine" Width="410px"></asp:TextBox>
    </div>--%>
    
<%--    <br style="clear: both"/>

    <div class="divBtns">
        <asp:Button ID="btnSave" CssClass="btn btnHover btn-sm" runat="server" Font-Bold="True" Text="Save" Width="87px"/>
        <%--<asp:Button ID="btnDelete" CssClass="btn btnHover btn-sm" runat="server" Font-Bold="True" Text="Delete" Width="87px" OnClientClick="return confirm('Are you sure to delete?')" />--%>
    <%--    <asp:Button ID="btnClear" CssClass="btn btnHover btn-sm" runat="server" Font-Bold="True" Text="Clear" Width="87px"/>
    </div>--%>

    <%--<div>
        <asp:GridView ID="gridView" CssClass=" table table-responsive table-bordered table-condesed gridView" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="False" DataKeyNames="PRODUCT_ID"
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
            
            <HeaderStyle HorizontalAlign="Center" Font-Size="Medium" CssClass="table table-primary" ForeColor="MidnightBlue"/>
            <PagerStyle HorizontalAlign="Center"/>
            <RowStyle BorderStyle="Solid" />

        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StringConectionRegisterProduct%>" SelectCommand="SELECT * FROM [PRODUCTS]"></asp:SqlDataSource>
        <asp:Label ID="lblCounter" CssClass="counter badge" runat="server" Text="Label"></asp:Label>
    </div>--%>

</asp:Content>
