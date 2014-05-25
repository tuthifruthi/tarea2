<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="WebApplication1.Account.WebForm1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   


   <big><b>Perfil Usuario: <% Response.Write(Session["UserName"].ToString());%></b></big>
   [ <asp:HyperLink ID="tema" runat="server" NavigateUrl="~/Edit_profile.aspx">Editar Perfil</asp:HyperLink> ]
    <br />
    <br />
   <br />
    
    <asp:Repeater id="Repeater2" runat="server">
   <ItemTemplate>
   
   <% string edad = GetAge();
      string tipo = GetTipo();  
   %>

   <table class="style1">
        <tr>
            <td>
                Nombre Usuario:</td>
            <td>
                <%# DataBinder.Eval(Container.DataItem,"nombre") %></td>
        </tr>
        <tr>
            <td>
                Avatar:</td>
            <td>
                <%# DataBinder.Eval(Container.DataItem,"avatar_url") %></td>
        </tr>
        <tr>
            <td>
                Edad:</td>
            <td>
                <%=edad %></td>
        </tr>
        <tr>
            <td>
                Sexo:</td>
            <td>
                <%# DataBinder.Eval(Container.DataItem,"sexo") %></td>
        </tr>
        <tr>
            <td>
                Número de Comentarios:</td>
            <td>
                <%# DataBinder.Eval(Container.DataItem,"cantidad_comentarios") %></td>
        </tr>
        <tr>
            <td>
                Fecha Registro:</td>
            <td>
                <%# DataBinder.Eval(Container.DataItem,"fecha_registro") %></td>
        </tr>
        <tr>
            <td>
                Tipo Usuario:</td>
            <td>
                <%=tipo %></td>
        </tr>
        <tr>
            <td>
            </br>
                5 últimos temas creados:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
               &nbsp; </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                5 últimos temas comentados:</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
   
   </ItemTemplate>
      </asp:Repeater>    

</asp:Content>
