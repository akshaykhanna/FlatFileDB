<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilesInFoldersUploader.aspx.cs" Inherits="DashBoard.FilesInFoldersUploader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 26px;
            text-align: center;
        }
        .auto-style3 {
            text-align: center;
        }
        .auto-style4 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td colspan="3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="4" style="text-align: center">
                    <asp:Label ID="lbHeading" runat="server" CssClass="auto-style1" Font-Bold="True" Font-Size="Larger" Text="Uplod file"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style2">
                    <asp:ListBox ID="ListBox1" runat="server" style="text-align: center" ></asp:ListBox>
                </td>
                <td class="auto-style2" colspan="2">
                    <asp:Button ID="btMoveToRigt" runat="server" OnClick="btMoveToRigt_Click" Text="&gt;" />
                </td>
                <td class="auto-style2">
                    <asp:ListBox ID="lbFinalItems" runat="server"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"></td>
                <td colspan="3" class="auto-style4"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3" class="auto-style3">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td style="text-align: center">
                    <asp:Button ID="btGenerateDashboard" runat="server" Height="26px" Text="Dashboard&gt;" style="text-align: center" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3" class="auto-style3">
                    <asp:Button ID="btAddFileToFolder" runat="server" OnClick="btAddFileToFolder_Click" Text="Add file" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td colspan="3" class="auto-style3">
                    <asp:Label ID="lbMsg" runat="server" Text="Msg"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="btPrev" runat="server" OnClick="btPrev_Click" Text="&lt;Prev" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnNextFile" runat="server" OnClick="btnNextFile_Click" Text=" Next&gt;" />
                </td>
                <td colspan="2" class="auto-style3">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
