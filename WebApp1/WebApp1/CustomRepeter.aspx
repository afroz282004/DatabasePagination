<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomRepeter.aspx.cs" Inherits="WebApp1.CustomRepeter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <asp:Repeater ID="rptStudentData" runat="server">
            <HeaderTemplate>
                <table id="tbDetails" style="width: 500px; border-collapse: collapse;" border="1" cellpadding="5" cellspacing="0">
                    <tr style="background-color: #ff0000; height: 20px; color: #fff">
                        <th>Student Id</th>
                        <th>Student Name</th>
                        <th>Student Qualification</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr style="height: 25px;">
                    <td>
                        <%#Eval("StudentId").ToString()%>
                    </td>
                    <td>
                        <%#Eval("StudentName").ToString()%>
                    </td>
                    <td>
                        <%#Eval("StudentQualification").ToString()%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <br />
        <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
            <ItemTemplate>
                <asp:LinkButton ID="lnkPage" style="padding: 8px; margin: 2px; color: #fff; font-weight: bold" Font-Underline="false"
                    CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                    runat="server" Font-Bold="True"><%# Container.DataItem %>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
