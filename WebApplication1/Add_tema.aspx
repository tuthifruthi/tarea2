<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Add_tema.aspx.cs" Inherits="WebApplication1.WebForm7" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .icon-save
    {}
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>
                       Crear tema
                    </h2>
                    <br />
         <asp:Label ID="AddComment" runat="server">Nombre:</asp:Label>
         <br />
         <asp:TextBox ID="ThemeName" runat="server" CssClass="textEntry" 
        Height="23px" Width="201px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server">Descripción:</asp:Label>
         <br />
         <asp:TextBox ID="Descr" runat="server" CssClass="textEntry" 
        Height="24px" Width="201px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server">Mensaje:</asp:Label>
         <br />
         <asp:TextBox ID="Message" runat="server" CssClass="textEntry" 
        Height="25px" Width="201px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server">Público:</asp:Label>

         <br />
    <asp:DropDownList ID="Publico" runat="server">
     <asp:ListItem>Publico</asp:ListItem>
     <asp:ListItem>Privado</asp:ListItem>
    </asp:DropDownList>

         <br />
         <br />
         <br />
         <asp:Button ID="add_theme" runat="server" Text="Crear" CssClass="icon-save" onclick="Crear_Click" />
</asp:Content>