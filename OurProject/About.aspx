<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="OurProject.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <thead>
            <tr>
                <th>ID</th>
                <th>NAME</th>
                <th>Date of Birth</th>
                <th>EMAIL</th>
                <th>USER NAME</th>
            </tr>
        </thead>

            <asp:Repeater ID="user" runat="server">
                <HeaderTemplate>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("DOB") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("UserName") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                </FooterTemplate>
            </asp:Repeater>

    </table>
    <asp:Button type="button" runat="server" ID="Populate" onclick="Populate_Click" Text="Populate"/>
    <asp:TextBox runat="server" ID="t1"></asp:TextBox>
    <asp:DropDownList runat="server" ID="t2">
        <asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
        <asp:ListItem Text="Option 3" Value="3"></asp:ListItem>
    </asp:DropDownList>
</asp:Content>
