<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TP3_Castro.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <h1 style="text-align:center;">Lista de articulos</h1>
        <asp:Label Text="Marcas" runat="server" /> <asp:DropDownList class="dropdown btn btn-secondary dropdown-toggle" ID="cboMarca" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="cboMarca_SelectedIndexChanged" ></asp:DropDownList>     
         <asp:Label Text="Categoria" runat="server" /> <asp:DropDownList class="dropdown btn btn-secondary dropdown-toggle" ID="cboCategoria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboCategoria_SelectedIndexChanged"></asp:DropDownList>
        <asp:Button class="dropdown btn btn-secondary dropdown-toggle" id="btnAll" Text="All" runat="server" OnClick="btnAll_Click" />
        <div class="row">
            <div class="card-columns" style="margin-left:10px;margin-right:10px; margin-top:20px;">
                <%foreach (var item in ListaArticulos)
                    { %>
                <div class="card" style="width: 18rem;  height: 360px; overflow:auto;">
                    
                    <img src="<%=item.imagen%>" class="card-img-top img-fluid" style=" height: 200px; width:200px; display: block; margin-left: auto; margin-right: auto;"  alt="...">
                   
                    <div class="card-body">
                        <h5 class="card-title" style="text-align:center;"><%=item.nombre%></h5>
                        <p class="card-text" style="text-align:center;"><%=item.descripcion %></p>

                        <a href="DetalleArticulo.aspx?idArt=<%= item.codigo.ToString() %>" class="btn btn-outline-primary btn-block">Detalle</a>
                    </div>
                </div>

                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
