<%@ Page Title="FORO MAGIC" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  
 
                    <h2>
                       Registro
                    </h2>

                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                    <div class="accountInfo">
                        <fieldset class="register">
                            <legend>Información de cuenta</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                 
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                     CssClass="failureNotification" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirmar contraseña:</asp:Label>
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirmar contraseña es obligatorio." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirmar contraseña es obligatorio." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="Contraseña y Confirmar contraseña deben coincidir."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                            </p>
                            <p>
                                <asp:Label ID="BirthDateLabel" runat="server" AssociatedControlID="BirthDate">Fecha de nacimiento (dd/mm/aaaa):</asp:Label>
                                <asp:TextBox ID="BirthDate" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="DateBirthRequired" runat="server" ControlToValidate="BirthDate" 
                                     CssClass="failureNotification" ErrorMessage="La fecha de nacimiento es obligatoria." ToolTip="La fecha de nacimiento es obligatoria." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="Gender" runat="server" AssociatedControlID="Gender1">Sexo:</asp:Label>
                                <asp:DropDownList ID="Gender1" runat="server">
                                <asp:ListItem>Hombre</asp:ListItem>
                                <asp:ListItem>Mujer</asp:ListItem>
                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Gender1" 
                                     CssClass="failureNotification" ErrorMessage="Escoja una opción." ToolTip="Escoja una opción." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="Avatar" runat="server" AssociatedControlID="AvURL">URL Avatar:</asp:Label>
                                <asp:TextBox ID="AvURL" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="AvURL" 
                                     CssClass="failureNotification" ErrorMessage="El avatar es obligatorio." ToolTip="El avatar es obligatorio." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
           
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Registrarse" OnClick="btnSubmit_Click"
                                 ValidationGroup="RegisterUserValidationGroup"/>
                        </p>
                    </div>
          
</asp:Content>
