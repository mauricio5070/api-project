<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="api_project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:Label ID="Label1" runat="server" Text="Lista de universidades por pais"></asp:Label>
    <br />
    <asp:Image ID="Image2" runat="server" Height="189px" ImageUrl="https://www.marquette.edu/_images/students-campus.jpg" Width="401px" />
    <br />

    
<asp:DropDownList ID="ddlPais" runat="server" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

    
<asp:GridView ID="gvDatos" runat="server" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged"></asp:GridView>
    </asp:Content>
