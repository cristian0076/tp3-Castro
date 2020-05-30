<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerCarrito.aspx.cs" Inherits="TP3_Castro.VerCarrito" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Carrito de Articulos</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
    <link rel="stylesheet" href="CSS/estilos.css" type="text/css" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">


         <nav class="navbar navbar-expand-lg navbar-light  bg-dark text-white-50" >

        <a class="navbar-brand" style="color:white" href="#">Catalogo de productos</a>

        <div class="collapse navbar-collapse" id="navbarTogglerDemo03">
            <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                <li class="nav-item active">
                    <a class="nav-link" href="Index.aspx" style="color:white">Home <span class="sr-only">(current)</span></a>
                </li>
            </ul>
        </div>
        <span class="navbar-text">
            <asp:Label  style="color:white" id="lblPrecio" Text="" runat="server" />
            <a href="VerCarrito.aspx">
                <img
                    src="CSS/Images/supermercado.png" />
            </a>
             <asp:Label style="color:white" id="lblcant" Text="" runat="server" />
        </span>
    </nav>



        <h1 style="text-align: center;">Carrito de Compras</h1>

         
       
        <a href="Index.aspx" class="btn btn-outline-primary btn-block">Seguir Comprando</a>
    
          
        <div class="container">
            <asp:GridView class="table table-dark" ID="GridCarrito" runat="server" OnRowCommand="GridCarrito_RowCommand">

           <columns>
               <asp:ButtonField HeaderText="Opcion" ButtonType="Link" text="Quitar" CommandName="btnAddArt_Click"/>
               </columns>

            </asp:GridView>
        </div>
        <div>
            <asp:Button runat="server" class="btn-block btn btn-outline-primary" ID="btnComprar" Text="" OnClick="btnComprar_Click" />
            <asp:Button runat="server" class="btn-block btn btn-outline-primary" ID="btActulizar" Text="Limpiar Carrito"
                OnClick="btActulizar_Click" />
        </div>
        
        <footer id="sticky-footer" class="py-4 bg-dark text-white-50">
            <div class="container text-center">
                <span class="logo-text">© 2020 - By Cristian Gabriel Castro(CGC) - todos los derechos reservados </span>
            </div>
        </footer>
    </form>
</body>
</html>
