<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TP3_Castro.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      
    <asp:Label id="lblError" Text="text" runat="server" />
    
        <asp:Button class="btn btn-outline-primary btn-block" id="btnError" Text="refresh" runat="server" OnClick="btnError_Click"/>
            </div>


</asp:Content>
