<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="itemList.aspx.cs" Inherits="sampleWbform.Pages.itemList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:DropDownList ID="RegionDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="RegionDropDown_SelectedIndexChanged">
    </asp:DropDownList>

    <asp:DropDownList ID="WiliyaDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="RegionDropDown_SelectedIndexChanged">
    </asp:DropDownList>

    <asp:DropDownList ID="AreaDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="RegionDropDown_SelectedIndexChanged">
    </asp:DropDownList>

    <asp:DropDownList ID="VillageDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="RegionDropDown_SelectedIndexChanged">
    </asp:DropDownList>

    <asp:DropDownList ID="EntityDropDown" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="RegionDropDown_SelectedIndexChanged">
    </asp:DropDownList>

    <asp:GridView ID="ItemGridView" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowCommand="ItemGridView_RowCommand">
        <Columns>
            <%--<asp:BoundField DataField="Id" HeaderText="ID" />--%>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="EntityTypeName" HeaderText="EntityTypeName" />
            <asp:BoundField DataField="VillageName" HeaderText="VillageName" />
            <asp:BoundField DataField="WillayaName" HeaderText="WillayaName" />
            <asp:BoundField DataField="RegionName" HeaderText="RegionName" />
            <asp:BoundField DataField="AreaName" HeaderText="AreaName" />

            <asp:TemplateField HeaderText="Edit">
            <ItemTemplate>
                <asp:LinkButton ID="EditButton" runat="server" CommandName="EditRecord" CommandArgument='<%# Eval("Id") %>'>
                    <i class="fa fa-edit"></i>  Edit
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>


    <%-- <asp:GridView ID="ItemGridView" runat="server" CssClass="table" AutoGenerateColumns="true">
            <asp:TemplateField>
                <Columns>
            <ItemTemplate>
                <asp:LinkButton ID="EditButton" runat="server" CommandName="EditRecord" CommandArgument='<%# Eval("Id") %>'>
                    <i class="fa fa-edit"></i> <!-- Edit icon -->
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>
</asp:Content>
