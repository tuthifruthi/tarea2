<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
    <h2>
        BIENVENIDO AL FORO DE MAGIC
        </h2>
        </br>
    <b>Categorías</b>
    <table class="style1">
    
        <tr>
            <td>
                Nombre</td>
            <td>
                Cantidad de Temas</td>
            <td>
                Total Mensajes</td>
            <td>
                Último tema comentado</td>
                <td>
                </td>
        </tr>

        <tr>
        <td><asp:Repeater id="Repeater1" runat="server">
         <ItemTemplate>
         <asp:HyperLink ID="tema" runat="server" NavigateUrl='<%# "~/Tema.aspx?IDCat="+DataBinder.Eval(Container.DataItem, "id_categoria") %>'><b><big><%# DataBinder.Eval(Container.DataItem,"nombre") %></big></b></asp:HyperLink>
         <br />
         <br />
         <br>
    	 </ItemTemplate>
      </asp:Repeater> </td>
            <td>

                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
                <td>
      <% if (Session["is_logged_in"] != null && Session["is_logged_in"].Equals(true) && GetGrupoUser()==1) {%>
      <asp:Repeater id="Repeater2" runat="server">
         <ItemTemplate>
      [ <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Delete_cat.aspx?IDCat="+DataBinder.Eval(Container.DataItem, "id_categoria") %>'>Eliminar</asp:HyperLink> ]
      <br />
      <br />
         <br>
    	 </ItemTemplate>
      </asp:Repeater>

      <%}else{ %>
      &nbsp;
      <% } %>
        </td>
        </tr>
    </table>
</asp:Content>
