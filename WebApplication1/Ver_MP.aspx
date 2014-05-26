<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Ver_MP.aspx.cs" Inherits="WebApplication1.WebForm10" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  

   <big><b>Mensaje de <%=GetNombreRemitente() %></b></big>
   [ <asp:HyperLink ID="mp" runat="server" NavigateUrl='<%"~/Responder_MP.aspx?IDMsj="+Request.QueryString["IDMsj"] %>'>Responder</asp:HyperLink> ]
   <br />
   <br />

    
    <table class="style1">
    
        <tr>
            <td>
                Asunto</td>
            <td>
                Fecha de Envío</td>
             <td>
             Mensaje
                </td>
        </tr>

        <tr>
        <td>
        <%=GetAsunto() %>
        <br />

        </td>
            <td>     
                <%=GetFechaEnvio() %>        
                        <br />
                </td>

            <td>
               <%=GetMensaje() %>        
                        <br />
               </td>
        </tr>
    </table>


</asp:Content>
