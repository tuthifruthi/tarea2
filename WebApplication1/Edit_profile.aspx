<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Edit_profile.aspx.cs" Inherits="WebApplication1.WebForm9" %>

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
    <asp:TextBox ReadOnly="True" ID="username" runat="server" CssClass="textEntry" 
        Height="25px" Width="201px"></asp:TextBox>
        <br />
        <br />
        Avatar:<br />
         <asp:TextBox ID="AvURL" runat="server" CssClass="textEntry" 
        Height="25px" Width="201px"></asp:TextBox>
        <br />
        <br />
        Sexo:<br />
    <asp:TextBox ID="sex1" ReadOnly="True" runat="server" CssClass="textEntry" 
        Height="25px" Width="201px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server">Tipo de usuario:</asp:Label>

         <br />
    <asp:TextBox ID="usergroup" ReadOnly="True" runat="server" CssClass="textEntry" 
        Height="25px" Width="201px"></asp:TextBox>
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