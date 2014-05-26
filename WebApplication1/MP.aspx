<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="MP.aspx.cs" Inherits="WebApplication1.WebForm12" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  

   <big><b>MP's Usuario: <% Response.Write(Session["UserName"].ToString());%></b></big>
   [ <asp:HyperLink ID="tema" runat="server" NavigateUrl="~/Send_MP.aspx">Enviar MP</asp:HyperLink> ]

   <br />
   <br />


   <b>Mensajes Recibidos: <%=CountMensajesRecibidos() %></b>
   <b>
    <br />
    Mensajes no leídos: <%=GetMensajesNoLeidos() %><br />
    </b>&nbsp;
    
    <table class="style1">
    
        <tr>
            <td>
                Remitente</td>
            <td>
                Asunto</td>
            <td>
                Fecha de Envío</td>
            <td>
                Leído</td>
             <td>
                </td>
        </tr>

        <tr>
        <td>
        <asp:Repeater id="Repeater4" runat="server">
   <ItemTemplate>
        <%# DataBinder.Eval(Container.DataItem,"nombre") %>
        <br />
        </ItemTemplate>
   </asp:Repeater>
        </td>
            <td>
                     <asp:Repeater id="Repeater1" runat="server">
   <ItemTemplate>
                <%# DataBinder.Eval(Container.DataItem,"asunto") %>        
                                <br />
                     </ItemTemplate>
   </asp:Repeater>
                </td>

            <td>
               <asp:Repeater id="Repeater2" runat="server">
   <ItemTemplate>
            <%# DataBinder.Eval(Container.DataItem,"fecha_de_envio") %>
                           <br />
    </ItemTemplate>
   </asp:Repeater>
               </td>

            <td>
                 <br /></td>
            <td>
            <asp:Repeater id="Repeater3" runat="server">
   <ItemTemplate>
    [ <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/Ver_MP.aspx?IDMsj="+DataBinder.Eval(Container.DataItem, "id_mensaje") %>'>Ver</asp:HyperLink> ]
                 <br />
                    </ItemTemplate>
   </asp:Repeater>
            </td>
        </tr>
    </table>


</asp:Content>
