<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="WebApplication1.WebForm13" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .icon-save
    {}
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <a href="Users.aspx">Users.aspx</a>
                       Usuarios del Foro</h2>

                           <table class="style1">
    
        <tr>
            <td>
                Nombre de usuario</td>
            <td>
                </td>
        </tr>

          <tr>
        <td>
        <asp:Repeater id="Repeater1" runat="server">
   <ItemTemplate>
        <%# DataBinder.Eval(Container.DataItem,"nombre") %>
        <br />
        <br />
        </ItemTemplate>
   </asp:Repeater>
        </td>
            <td>     
               <% if (Session["is_logged_in"] != null && Session["is_logged_in"].Equals(true) && GetGrupoUser()==1) {%>
      <asp:Repeater id="Repeater2" runat="server">
         <ItemTemplate>
      [ <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Editprofile.aspx?IDuser="+DataBinder.Eval(Container.DataItem, "id_usuario") %>'>Editar Perfil</asp:HyperLink> ]
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