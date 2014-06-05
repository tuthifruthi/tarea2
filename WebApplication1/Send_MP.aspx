<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Send_MP.aspx.cs" Inherits="WebApplication1.WebForm11" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .icon-save
    {}
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>
                       ENVIAR MP</h2>
                    <br />
         <asp:Label ID="AddComment" runat="server">Usuario:</asp:Label>
         <br />

      <asp:TextBox ID="TextBox1" runat="server" CssClass="textEntry" 
        Height="24px" Width="201px"></asp:TextBox>

        <br />
        <br />
        <asp:Label ID="Label1" runat="server">Asunto:</asp:Label>
         <br />
         <asp:TextBox ID="Asunto" runat="server" CssClass="textEntry" 
        Height="24px" Width="201px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server">Mensaje:</asp:Label>
         <br />
         <asp:TextBox ID="Message" runat="server" CssClass="textEntry" 
        Height="25px" Width="201px"></asp:TextBox>
        <br />
         <br />
         <br />
         <asp:Button ID="add_theme" runat="server" Text="Enviar" CssClass="icon-save" onclick="Send_Click" />
</asp:Content>