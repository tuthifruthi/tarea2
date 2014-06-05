<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Comentarios.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    .icon-save
    {}
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

  <asp:Repeater id="Repeater5" runat="server">
   <ItemTemplate>
   <big><b>Tema: <%# DataBinder.Eval(Container.DataItem,"nombre") %></b></big>
   <%if (Session["is_logged_in"] != null && Session["is_logged_in"].Equals(true))
     { %>
    [ <asp:HyperLink ID="tema" runat="server" NavigateUrl='<%# "~/Add_comentario.aspx?IDTema="+DataBinder.Eval(Container.DataItem, "id_tema") %>'>Responder Tema</asp:HyperLink> ]
   
    <%} %>
   </ItemTemplate>
   </asp:Repeater>
   <br />
   <br />
    <table class="style1">
    
        <tr>
            <td>
                Usuario</td>
            <td>
                Avatar</td>
            <td>
                Mensaje</td>
                 <td>
                </td>
        </tr>

        <tr>

        <td><asp:Repeater id="Repeater4" runat="server">
         <ItemTemplate>
         <%# DataBinder.Eval(Container.DataItem,"nombre") %>
          <br />
         <br>
    	 </ItemTemplate>
      </asp:Repeater> </td>

            <td>
               <asp:Repeater id="Repeater2" runat="server">
         <ItemTemplate>
         <%# DataBinder.Eval(Container.DataItem,"avatar_url") %>
          <br />
         <br>
    	 </ItemTemplate>
      </asp:Repeater>
                        
                </td>

            <td>
                <asp:Repeater id="Repeater1" runat="server">
         <ItemTemplate>
         <%# DataBinder.Eval(Container.DataItem,"mensaje") %>
          <br />
         <br>
    	 </ItemTemplate>
      </asp:Repeater>
      
      </td>

      <td>
      <asp:Repeater id="Repeater3" runat="server">
         <ItemTemplate>
       <% if (Session["is_logged_in"] != null && Session["is_logged_in"].Equals(true))
     { %>
      [ <asp:HyperLink ID="tema" runat="server" NavigateUrl='<%# "~/Edit_comentario.aspx?IDComentario="+DataBinder.Eval(Container.DataItem, "id_comentario") %>'>Editar</asp:HyperLink> ]
      [ <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Delete_comentario.aspx?IDComentario="+DataBinder.Eval(Container.DataItem, "id_comentario") %>'>Eliminar</asp:HyperLink> ]
      <%} %>
      <br />

         <br>
    	 </ItemTemplate>
      </asp:Repeater>
        </td>
        </tr>
    </table>
</asp:Content>
