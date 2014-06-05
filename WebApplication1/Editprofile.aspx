<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Editprofile.aspx.cs" Inherits="WebApplication1.WebForm14" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .icon-save
    {}
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>
                       Editar perfil 
                    </h2>
                    <br />
         Contraseña:<br />
         <asp:TextBox ID="Passw" runat="server" TextMode="Password" CssClass="textEntry" 
        Height="23px" Width="201px"></asp:TextBox>
        <br />
        <br />
        Repetir contraseña:<br />
         <asp:TextBox ID="RepeatPassw" runat="server" TextMode="Password" CssClass="textEntry" 
        Height="24px" Width="201px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server">Nombre de Usuario:</asp:Label>

         <br />
    <asp:TextBox ID="username" runat="server" CssClass="textEntry" 
        Height="25px" Width="201px"></asp:TextBox>
        <br />
        <br />
        Avatar:<br />
         <asp:TextBox ID="AvURL" runat="server" CssClass="textEntry" 
        Height="25px" Width="201px"></asp:TextBox>
        <br />
        <br />
        Sexo:<br />
    <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>Mujer</asp:ListItem>
                                <asp:ListItem>Hombre</asp:ListItem>
                                </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server">Tipo de usuario:</asp:Label>
        <br />
   
        <asp:DropDownList ID="Tipo" runat="server">
                                <asp:ListItem>Usuario Común</asp:ListItem>
                                <asp:ListItem>Moderador</asp:ListItem>
                                </asp:DropDownList>
                
         <br />
        <br />
        <asp:Label ID="Label3" runat="server">Fecha de nacimiento(dd/mm/aaaa):</asp:Label>

         <br />
    <asp:TextBox ID="BirthDate" runat="server" CssClass="textEntry" 
        Height="25px" Width="201px"></asp:TextBox>

         <br />
         <br />
         <br />
         <asp:Button ID="add_theme" runat="server" Text="Editar" CssClass="icon-save" onclick="Edit_Click" />
</asp:Content>