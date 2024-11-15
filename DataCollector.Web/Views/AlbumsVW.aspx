<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="AlbumsVW.aspx.vb" Inherits="DataCollector.Web.AlbumsVW" Async="true" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Albums</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Albums</h2>

            <div>
                <label for="titleFilter">Filter by Title: </label>
                <asp:TextBox ID="titleFilter" runat="server" placeholder="Enter title to filter" />
                <asp:Button ID="FilterButton" runat="server" Text="Filter" OnClick="FilterAlbums" />
            </div>
            <div>
                <label for="SourceSelect">Choose data source: </label>
                <asp:RadioButtonList ID="SourceSelect" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SourceSelect_SelectedIndexChanged">
                    <asp:ListItem Text="From API" Value="True" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="From Database" Value="False"></asp:ListItem>
                </asp:RadioButtonList>
            </div>

        <asp:Repeater ID="AlbumsRepeater" runat="server" OnItemDataBound="AlbumsRepeater_ItemDataBound">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th>Album ID</th>
                            <th>Title</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Id") %></td>
                    <td>
                        <asp:LinkButton ID="AlbumLink" runat="server" OnClick="Album_Click" CommandArgument='<%# Eval("Id") %>'>
                            <%# Eval("Title") %>
                        </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </table>
            </FooterTemplate>
        </asp:Repeater>

        </div>
    </form>
</body>
</html>
