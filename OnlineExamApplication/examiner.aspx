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
        <br />
        <div class="form-group">
            <asp:GridView ID="grdQuestions" runat="server" AllowSorting="True" CellPadding="4" EmptyDataText="No Test  Record Available" ForeColor="Black" GridLines="None" Width="1075px" AutoGenerateColumns="False" BackColor="Black">
                <AlternatingRowStyle BackColor="White" ForeColor="black" />
                <Columns>
                    <asp:BoundField DataField="t_TestDescription" HeaderText="Test Description" SortExpression="t_TestDescription" />
                    <asp:BoundField DataField="Question" HeaderText="Question" SortExpression="Question" />
                    <asp:BoundField DataField="Question_Type" HeaderText="Question Type" SortExpression="Question_Type" />
                    <asp:BoundField DataField="Answer" HeaderText="Answer" SortExpression="Answer">
                    <ItemStyle Width="400px" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#999999" BorderColor="Black" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" BorderColor="Black" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
         <%-- *********************************************************************--%>
    </div>
</asp:Content>
