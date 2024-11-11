<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" EnableEventValidation="false" CodeBehind="AddUser.aspx.cs" Inherits="sampleWbform.Pages.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Insert Record</h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
        ShowSummary="true"
        ShowMessageBox="false"
        CssClass="validation-summary-errors"
        HeaderText="Please correct the following errors:" />
    <div>
        <asp:Panel CssClass="form-group" runat="server">
            <asp:Label ID="lblName" runat="server" AssociatedControlID="txtName" Text="Name:" />
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            <%--<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name is required." CssClass="text-danger" Display="Dynamic" />--%>
        </asp:Panel>

        <asp:Panel CssClass="form-group" runat="server">
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" Text="Email:" />
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required." CssClass="text-danger" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="Invalid email format."
                ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" CssClass="text-danger" Display="Dynamic" />
        </asp:Panel>

        <%-- <asp:Panel CssClass="form-group" runat="server">
            <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone" Text="Phone:" />
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone number is required." CssClass="text-danger" Display="Dynamic" />
        </asp:Panel>--%>
        <asp:Label ID="lblPhone" runat="server" AssociatedControlID="txtPhone" Text="Phone:" />
        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />

        <!-- RequiredFieldValidator to ensure the field is not empty -->
        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
            ErrorMessage="Phone number is required." CssClass="text-danger" Display="Dynamic" />

        <!-- RegularExpressionValidator to enforce the phone number format (e.g., 10 digits) -->
        <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone"
            ErrorMessage="Enter a valid phone numbers 7 to 15 digits " CssClass="text-danger" Display="Dynamic"
             ValidationExpression="^\d{7,15}$"/>

        <asp:DropDownList ID="RegionDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="RegionDropDown_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvRegion" runat="server" ControlToValidate="RegionDropDown" InitialValue="0" ErrorMessage="Region is required." CssClass="text-danger" Display="Dynamic" />

        <asp:DropDownList ID="WiliyaDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="WiliyatDropDown_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvWiliya" runat="server" ControlToValidate="WiliyaDropDown" InitialValue="0" ErrorMessage="Wiliya is required." CssClass="text-danger" Display="Dynamic" />

        <asp:DropDownList ID="AreaDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="AreaDropDown_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvArea" runat="server" ControlToValidate="AreaDropDown" InitialValue="0" ErrorMessage="Area is required." CssClass="text-danger" Display="Dynamic" />

        <asp:DropDownList ID="VillageDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="VillageDropDown_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvVillage" runat="server" ControlToValidate="VillageDropDown" InitialValue="0" ErrorMessage="Village is required." CssClass="text-danger" Display="Dynamic" />

        <asp:DropDownList ID="EntityTypeDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="EntityTypeDropDown_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvEntityType" runat="server" ControlToValidate="EntityTypeDropDown" InitialValue="0" ErrorMessage="Entity Type is required." CssClass="text-danger" Display="Dynamic" />




        <asp:Panel CssClass="form-group" runat="server">
            <asp:Label ID="lblRemark" runat="server" AssociatedControlID="txtRemark" Text="Remark:" />
            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvRemark" runat="server" ControlToValidate="txtRemark" ErrorMessage="Remark is required." CssClass="text-danger" Display="Dynamic" />
        </asp:Panel>

        <asp:Panel CssClass="form-group" runat="server">
            <asp:Label ID="lblDetailODE" runat="server" AssociatedControlID="txtDetailODE" Text="Detail ODE:" />
            <asp:TextBox ID="txtDetailODE" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvDetailODE" runat="server" ControlToValidate="txtDetailODE" ErrorMessage="Detail ODE is required." CssClass="text-danger" Display="Dynamic" />
        </asp:Panel>
        <%-- <asp:Panel CssClass="form-group" runat="server">
            <asp:Label ID="lblRemark" runat="server" AssociatedControlID="txtRemark" Text="Remark:" />
            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
        </asp:Panel>

        <asp:Panel CssClass="form-group" runat="server">
            <asp:Label ID="lblDetailODE" runat="server" AssociatedControlID="txtDetailODE" Text="Detail ODE:" />
            <asp:TextBox ID="txtDetailODE" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" />
        </asp:Panel>--%>

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="false" CssClass="success-message" />

    </div>
</asp:Content>
