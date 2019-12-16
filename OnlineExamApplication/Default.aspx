<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnlineExamApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 style="font-weight:bold;">Exam</h3>
        <p class="lead"><%:msg %><p>
        <p><a href="<%:link %>" class=" btn-primary btn"><%:head %> &raquo;</a></p>
    </div>

</asp:Content>
