<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Asp_Final_All_2022024.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asp_Final_All</title>

        <style>

   form{
    height: 520px;
    width: 400px;
    background-color:sandybrown;
    position: absolute;
    transform: translate(-50%,-50%);
    top: 50%;
    left: 50%;
    border-radius: 10px;
    backdrop-filter: blur(10px);
    border: 2px solid rgba(255,255,255,0.1);
    box-shadow: 0 0 40px rgba(8,7,16,0.6);
    padding: 50px 35px;
    text-align:center;
    }
   td{
       height: 20px;
    width: 50%;
 text-align:center;
 display: block;
    margin-top: 30px;
    font-size: 16px;
    font-weight: 500;
   }

    </style>
</head>

<body>
    <form id="form1" runat="server">

        <h3 >Member Login</h3>
      
            <table>
                 <tr>
                    <td>User Name:</td>
                    <td><asp:TextBox ID="txtuser" runat="server"></asp:TextBox></td>
                 </tr>

     <tr>
        <td>Password:</td>
        <td><asp:TextBox ID="txtpass" runat="server"></asp:TextBox></td>
    </tr>

     <tr>
       <td></td>
       <td><asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click"></asp:Button></td>
    </tr>
      </table>
      
    </form>
</body>
</html>
