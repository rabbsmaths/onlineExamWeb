<%@ Page Title="Add Exam" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="examiner.aspx.cs" Inherits="OnlineExamApplication.examiner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
       <%-- *********************************************************************--%>
        <div id="divTestTitle" runat ="server">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtTestTitle" CssClass="col-md-2 control-label">Exam Title</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtTestTitle" CssClass="form-control" TextMode="MultiLine" Width="280px" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTestTitle"
                    CssClass="text-danger" ErrorMessage="The test title field is required." />
            </div>
        </div>
         <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server"  Text="Add Exam Title" CssClass="btn btn-default" ID="btnTestTitle" OnClick="btnTestTitle_Click" />
            </div>
        </div>
        </div>
        <%-- *********************************************************************--%>

        <div id="divSelectTest" runat ="server">
          <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="dlSelectTest" CssClass="col-md-2 control-label">Select Exam</asp:Label>
            <div class="col-md-10">
                 <asp:DropDownList CssClass="dropdopwn-menu form-control" ID="dlSelectTest" runat="server" Width="281px" AppendDataBoundItems="False" />
            </div>
        </div>
         </div>

         <%-- *********************************************************************--%>
         <div id="divAddQ" runat ="server">
            <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtQuestion" CssClass="col-md-2 control-label">Question</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtQuestion" CssClass="form-control" TextMode="MultiLine" Width="280px" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtQuestion"
                    CssClass="text-danger" ErrorMessage="The question field is required." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="dlQuestionType" CssClass="col-md-2 control-label">Question Type</asp:Label>
            <div class="col-md-10">
                 <asp:DropDownList CssClass="dropdopwn-menu form-control" ID="dlQuestionType" runat="server" Width="281px" AppendDataBoundItems="False" />
            </div>
        </div>
           <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtAnswer" CssClass="col-md-2 control-label">Answer</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAnswer" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAnswer"
                    CssClass="text-danger" ErrorMessage="The answer field is required." />
            </div>
        </div>
       <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server"  Text="Add Question" CssClass="btn btn-default" ID="btnAddQuestion" OnClick="btnAddQuestion_Click"  />
            </div>
        </div>
        </div>
         <%-- *********************************************************************--%>
    </div>
</asp:Content>
