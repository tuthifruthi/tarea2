<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Tema.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
   <asp:Repeater id="Repeater5" runat="server">
   <ItemTemplate>
   <big><b>Categoría: <%# DataBinder.Eval(Container.DataItem,"nombre") %></b></big>
   <%if (Session["is_logged_in"] != null && Session["is_logged_in"].Equals(true))
     { %>
   [ <asp:HyperLink ID="tema" runat="server" NavigateUrl='<%# "~/Add_tema.aspx?IDCat="+Request.QueryString["IDCat"] %>'>Crear Tema</asp:HyperLink> ]
   <%} %>
   </ItemTemplate>
   </asp:Repeater>
   <br />
   <br />

    <table class="style1">
    
        <tr>
            <td>
                Nombre</td>
            <td>
                Autor</td>
            <td>
                Descripción</td>
            <td>
                Cantidad Comentarios</td>
                 <td>
                </td>
        </tr>

        <tr>
        <td><asp:Repeater id="Repeater2" runat="server">
         <ItemTemplate>
         <asp:HyperLink ID="tema" runat="server" NavigateUrl='<%# "~/Comentarios.aspx?IDTema="+DataBinder.Eval(Container.DataItem, "id_tema") %>'><b><big><%# DataBinder.Eval(Container.DataItem,"nombre") %></big></b></asp:HyperLink>
          <br />
         <br>
    	 </ItemTemplate>
      </asp:Repeater> </td>

            <td>
               <asp:Repeater id="Repeater4" runat="server">
         <ItemTemplate>
         <%# DataBinder.Eval(Container.DataItem,"nombre") %>
            <br />
         <br>
    	 </ItemTemplate>
      </asp:Repeater>
                        
                </td>

            <td>
               <asp:Repeater id="Repeater3" runat="server">
         <ItemTemplate>
         <%# DataBinder.Eval(Container.DataItem,"descripcion") %>
          <br />

         <br>
    	 </ItemTemplate>
      </asp:Repeater></td>
            <td>
                 <br /></td>
                   <td>
      <% if (Session["is_logged_in"] != null && Session["is_logged_in"].Equals(true) && (GetGrupoUser()==1 || GetGrupoUser()==2)) {%>
      <asp:Repeater id="Repeater1" runat="server">
         <ItemTemplate>
      
      [ <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Delete_tema.aspx?IDTema="+DataBinder.Eval(Container.DataItem, "id_tema") %>'>Eliminar</asp:HyperLink> ]
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
