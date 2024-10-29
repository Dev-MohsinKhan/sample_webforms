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

        


        <asp:GridView ID="ItemGridView" runat="server" CssClass="table" AutoGenerateColumns="true">
        </asp:GridView>
   </asp:Content>