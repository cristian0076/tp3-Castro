<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TP3_Castro.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%try
    {%>
        <h1>Detalle de Articulo</h1>
    <div class="card" style="width: 18rem; height: 500px; overflow:auto;" >
        <img class="card-img-top img-fluid" style="height: 200px; width: 200px; display: block; margin-left: auto; margin-right: auto;" src="<%=articulo.imagen %>" alt="Card image cap">
        <div class="card-body">
            <h5 class="card-title" style="text-align: center;"><%=articulo.nombre %></h5>
            <h5 style="text-align: center; color: darkgreen">$ <%=articulo.precio.ToString("G29") %></h5>
            <p class="card-text" style="text-align: center;"><%=articulo.descripcion %></p>
              <asp:Button id="btnAdd" Text="Add"  class="btn btn-outline-primary btn-block" OnClick="btnAddcant_Click" runat="server" /> 
                        <asp:Label Text="Cant: " id="lblCantArt" runat="server" /><asp:Label Text="0" id="lblNum" runat="server" />
                        <asp:Button id="btnRemove" Text="Remove"  class="btn btn-outline-primary btn-block" OnClick="btnremovecant" runat="server" />
            <asp:Button id="btnAddCarrito" Text="Agregar al carrito"  class="btn btn-outline-primary btn-block" OnClick="btnAddCarrito_Click" runat="server" />
        </div>
    </div>

    <%}
        catch (Exception ex)
        {

           Session.Add("Error",ex.ToString());
           Response.Redirect("Error.aspx");
        }%>
       
</asp:Content>
