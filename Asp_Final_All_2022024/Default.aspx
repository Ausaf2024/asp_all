<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Asp_Final_All_2022024._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  <div class="row" style="margin-top:10px;">
    <div class="col-md-4">
         <asp:Image ID="image1" runat="server" Width="300px" Height="200px" ImageUrl="images/image3.jpg" />
        <h2>Getting started</h2>
        <p>
           ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
        A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
        </p>
        <p>
            <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
        </p>
    </div>
    <div class="col-md-4">
          <asp:Image ID="image2" runat="server" Width="300px" Height="200px" ImageUrl="images/Atomy1.jpg" />
        <h2>Get more libraries</h2>
        <p>
            NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
        </p>
        <p>
            <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
        </p>
    </div>
    <div class="col-md-4">
          <asp:Image ID="image3" runat="server" Width="300px" Height="200px" ImageUrl="images/banar1.jpg" />
        <h2>Web Hosting</h2>
        <p>
            You can easily find a web hosting company that offers the right mix of features and price for your applications.
        </p>
        <p>
            <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
        </p>
    </div>
</div>
</asp:Content>

