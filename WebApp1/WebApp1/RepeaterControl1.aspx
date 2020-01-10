<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepeaterControl1.aspx.cs" Inherits="WebApp1.RepeaterControl1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Repeater Control with Stored Procedure</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table id="tbDetails" style="width: 100%; border-collapse: collapse;" border="1" cellpadding="5" cellspacing="0">
                        <tr style="background-color: lightgray; height: 30px; color: black; text-align: center">
                            <th>Id</th>
                            <th>Customer Name</th>
                            <th>Company Name</th>
                            <th>Phone</th>
                            <th>Address</th>
                            <th>E-Mail</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="height: 25px;">
                        <td>
                            <%#Eval("Id").ToString()%>
                        </td>
                        <td>
                            <%#Eval("Name").ToString()%>
                        </td>
                        <td>
                            <%#Eval("Company").ToString()%>
                        </td>
                        <td>
                            <%#Eval("Phone").ToString()%>
                        </td>
                        <td>
                            <%#Eval("Address").ToString()%>, <%#Eval("Country").ToString()%>
                        </td>
                        <td>
                            <%#Eval("Email").ToString()%>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <br />
        <div style="text-align:center">
            <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkPage"
                        Style="padding: 8px; margin: 2px; background: lightgray; border: solid 1px #666; color: black; font-weight: bold"
                        CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" Font-Bold="True"><%# Container.DataItem %>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
