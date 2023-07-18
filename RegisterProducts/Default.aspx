<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="RegisterProducts._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="title">
        Product Registration 
    </div>
    
    <div class="divMain">
        
        <div class="divForm form-check">
            
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
                <asp:Label ID="lblColor" runat="server" Font-Bold="True" Font-Size="Medium" Text="Color"></asp:Label> 
                <asp:TextBox ID="txtColor" CssClass="textBox " runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
            </div>

            <div class="fields">
                <asp:Label ID="lblRegistrationDate" runat="server" Font-Bold="True" Font-Size="Medium" Text="Registration Date"></asp:Label> 
                <asp:TextBox ID="txtRegistrationDate" runat="server" CssClass="accordion-header textBox" Font-Size="Medium" Height="31px" Width="200px" TextMode="Date"></asp:TextBox>
            </div>

            <div class="fields">
                <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Size="Medium" Text="Status" ></asp:Label> 
                <asp:CheckBox ID="checkAvailable" CssClass="checkBox" runat="server" Font-Bold="True" Font-Size="Medium" Text="Available" /> <!--AutoPostBack=true-->
                <asp:CheckBox ID="checkUnavailable" CssClass="checkBox marginLeft" runat="server" Font-Bold="True" Font-Size="Medium" Text="Unavailable"/>
            </div> 

        </div>

        <div class="divBtnSearch">
            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="\Images\lupa.png" ToolTip="Search" width="50px" Height="50px"/>
        </div>

    </div>
      
    <div class="fields lblLeft"> 
        <asp:Label ID="lblSpecification" runat="server" Font-Bold="True" Font-Size="Medium" Text="Specification"></asp:Label> 
        <asp:TextBox ID="txtSpecification" CssClass="textBox" runat="server"  Font-Size="Medium" TextMode="MultiLine" Width="418px"></asp:TextBox>
    </div>
    
    <br style="clear: both"/>

    <div class="divBtns">
        <asp:Button ID="btnSave" CssClass="btn btnHover btn-sm" runat="server" Font-Bold="True" Text="Save" Width="87px"/>
        <asp:Button ID="btnUptade" CssClass="btn btnHover btn-sm" runat="server" Font-Bold="True" Text="Update" Width="87px"/>
        <asp:Button ID="btnDelete" CssClass="btn btnHover btn-sm" runat="server" Font-Bold="True" Text="Delete" Width="87px" OnClientClick="return confirm('Are you sure to delete?')" />
        <asp:Button ID="btnClear" CssClass="btn btnHover btn-sm" runat="server" Font-Bold="True" Text="Clear" Width="87px"/>
    </div>

    <div>
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
                
                
               <%-- <asp:TemplateField HeaderText="EDITE">
                    <ItemTemplate>
                        <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="\Images\excluir.png" ToolTip="Delete" width="20px" Height="20px"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>--%>

                <asp:ButtonField CommandName="Delete" ButtonType="Image" HeaderText="EDITE" ShowHeader="True" ImageUrl="/Images/excluir.png"
                    ControlStyle-Width="20px" ItemStyle-HorizontalAlign="Center"/>



                
            </Columns>
            
            <HeaderStyle HorizontalAlign="Center" Font-Size="Medium" CssClass="table table-primary" ForeColor="MidnightBlue"/>
            <PagerStyle HorizontalAlign="Center"/>
            <RowStyle BorderStyle="Solid" />

        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PRODUCT_REGISTERConnectionString %>" SelectCommand="SELECT * FROM [PRODUCTS]"></asp:SqlDataSource>
        <asp:Label ID="lblProducts" CssClass="counter badge" runat="server" Text="Label"></asp:Label>
    </div>

</asp:Content>
