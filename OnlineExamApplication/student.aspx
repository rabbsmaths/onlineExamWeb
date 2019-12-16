<%@ Page Title="Write Exam" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="OnlineExamApplication.student" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal" runat="server" id="mainDIv">
        <hr />
          <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="dlSelectTest" CssClass="col-md-2 control-label">Select Exam</asp:Label>
            <div class="col-md-10">
                 <asp:DropDownList CssClass="dropdopwn-menu form-control" ID="dlSelectTest" runat="server" Width="281px" AppendDataBoundItems="False" />
            </div>
        </div>
            <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server"  Text="Start Exam" CssClass="btn btn-default" ID="btnStartExam" OnClick="btnStartExam_Click"  />
            </div>
       </div>

    </div>
</asp:Content>
