<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="PhotosVW.aspx.vb" Inherits="DataCollector.Web.PhotosVW" Async="true" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Photos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Photos for Album ID: <asp:Label ID="AlbumTitle" runat="server" Text=""></asp:Label></h2>

            <div>
                <label for="SourceSelect">Choose data source: </label>
                <asp:RadioButtonList ID="SourceSelect" runat="server" AutoPostBack="true" Enabled="false">
                    <asp:ListItem Text="From API" Value="True" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="From Database" Value="False"></asp:ListItem>
                </asp:RadioButtonList>
            </div>

            <asp:Repeater ID="PhotosRepeater" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>Photo ID</th>
                                <th>Title</th>
                                <th>URL</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Title") %></td>
                        <td><a href="<%# Eval("Url") %>" target="_blank">View</a></td>
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
