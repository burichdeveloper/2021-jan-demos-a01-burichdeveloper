<%@ Page Title="Filter Search Demo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchByDDL.aspx.cs" Inherits="WebApp.SamplePages.SearchByDDL" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search Albums by Artist</h1>
    <div class="row">
        <div class="offset-3">
            <asp:Label ID="Label1" runat="server" Text="Select an artist: "></asp:Label>
            <asp:DropDownList ID="ArtistList" runat="server"></asp:DropDownList>
            <asp:LinkButton ID="SearchAlbums" runat="server" OnClick="SearchAlbums_Click">Search <i class="fa fa-search"></i></asp:LinkButton>
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="offset-3">
            <uc1:messageusercontrol runat="server" id="MessageUserControl" />
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="offset-3">
            <asp:GridView ID="ArtistAlbumsList" runat="server" 
                AutoGenerateColumns="False"
                CssClass="table table-striped"
                GridLines="Horizontal"
                BorderStyle="None">
                <Columns>
                    <asp:TemplateField HeaderText="Album">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" 
                                Text='<%# Eval("Title") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Released">
                         <ItemTemplate>
                             <asp:Label ID="Label3" runat="server" 
                                 Text='<%# Eval("ReleasedYear") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center">
                        </ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Artist">
                         <ItemTemplate>
                             <asp:DropDownList ID="ArtistNameList" runat="server" 
                                 DataSourceID="ArtistNameListODS" 
                                 DataTextField="DisplayField" 
                                 DataValueField="ValueField" Width="250"
                                 SelectedValue ='<%# Eval("ArtistId") %>'>
                             </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No Albums for selected Artist
                </EmptyDataTemplate>
            </asp:GridView>
            
            <asp:ObjectDataSource ID="ArtistNameListODS" runat="server" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="Artists_DDL_List" 
                TypeName="ChinookSystem.BLL.ArtistController">
            </asp:ObjectDataSource>

        </div>
    </div>

</asp:Content>
