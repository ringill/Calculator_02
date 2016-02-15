<%@ Page Title="Вычисление" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="Calculator.UI.AspApp._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h4>Операция</h4>
    <fieldset>
        <legend></legend>
        <div class="editor-label">
            <asp:Label ID="lbl_OperationType" runat="server" Text="Тип операции"></asp:Label>
        </div>
        <div class="editor-field">
            <asp:DropDownList ID="list_OpertionTypes" runat="server"></asp:DropDownList>
        </div>

        <div class="editor-label">
            <asp:Label ID="lbl_Argument1" runat="server" Text="Аргумент 1"></asp:Label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="txt_Argument1" runat="server"></asp:TextBox>
        </div>

        <div class="editor-label">
            <asp:Label ID="lbl_Argument2" runat="server" Text="Аргумент 2"></asp:Label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="txt_Argument2" runat="server"></asp:TextBox>
        </div>

        <div class="editor-label">
            <asp:Label ID="lbl_OperationResult" runat="server" Text="Результат операции"></asp:Label>
        </div>
        <div class="editor-field">
            <asp:TextBox ID="txt_OperationResult" runat="server"></asp:TextBox>
        </div>

        <p>
            <asp:Button ID="btn_Calculate" runat="server" Text="Вычислить" />
        </p>
    </fieldset>













</asp:Content>
