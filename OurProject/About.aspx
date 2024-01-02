<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="OurProject.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:UpdateProgress></asp:UpdateProgress>--%>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
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
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Populate" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Button type="button" runat="server" ID="Populate" OnClick="Populate_Click" Text="Populate" />

    <%--  <asp:TextBox runat="server" ID="t1"></asp:TextBox>
    <asp:DropDownList runat="server" ID="t2">
        <asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
        <asp:ListItem Text="Option 3" Value="3"></asp:ListItem>
    </asp:DropDownList>--%>
</asp:Content>
<%--DataGrid--%>