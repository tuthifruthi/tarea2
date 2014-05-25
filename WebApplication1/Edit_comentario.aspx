<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Edit_comentario.aspx.cs" Inherits="WebApplication1.WebForm8" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .icon-save
    {}
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>
                       Editar Respuesta
                    </h2>
                    <br />
         <asp:Label ID="AddComment" runat="server">Mensaje:</asp:Label>
         <br />
         <asp:TextBox ID="Message" runat="server" CssClass="textEntry" 
        Height="76px" Width="318px"></asp:TextBox>
         <br />
         <br />
         <asp:Button ID="add_comment" runat="server" Text="Responder" CssClass="icon-save" onclick="Edit_Click" />
</asp:Content>