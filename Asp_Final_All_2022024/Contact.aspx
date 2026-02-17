<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Asp_Final_All_2022024.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <script>
    
        function validation() {
            // get the input value
            let Name = document.getElementById("txtname").value;

            if (Name.trim() == "") {
                alert("Please enter the name");
                document.getElementById("txtname").focus();
                return false;  // prevent form submission
            }

            // You can add more validations here

            return true;

    </script>

    <div class="container">
        <table>
            <tr>
                <td>Name:</td>
                <td>
                    <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Country:</td>
                <td>
                    <asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true" AppendDataBoundItems="true"  >
                       <%-- <asp:ListItem>Select</asp:ListItem>--%>
                    </asp:DropDownList></td>
            </tr>

            <tr>
                <td>State:</td>
                <td>
                    <asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged"  AutoPostBack="true" AppendDataBoundItems="true">
                         <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>

            <tr>
                <td>City::</td>
                <td> 
                    <asp:DropDownList ID="ddlcity" runat="server" AutoPostBack="true" AppendDataBoundItems="true" >
     <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>

            <tr>
                <td>Gender:</td>
                <td>
                    <asp:RadioButtonList ID="rbl" runat="server" RepeatColumns="3">
                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Otehr" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td>Image Upload:</td>
                <td>
                    <asp:FileUpload ID="fuimg" runat="server" /></td>
            </tr>

            <tr>
                <td>Hobbies:</td>
                <asp:CheckBoxList ID="chkhobbies" runat="server" RepeatColumns="4">
                    <asp:ListItem Text="Cricket" Value="1"></asp:ListItem>
                      <asp:ListItem Text="Dance" Value="1"></asp:ListItem>
                      <asp:ListItem Text="Read Book " Value="1"></asp:ListItem>
                      <asp:ListItem Text="Watching Movie" Value="1"></asp:ListItem>
                </asp:CheckBoxList>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click"  OnClientClick="validation()"/></td>
            </tr>

            <hr/>

           
            <asp:GridView id="Grd" runat="server" AutoGenerateColumns="false" OnRowCommand="Grd_RowCommand" table-width="100%" DataKeyNames="id,Image_Upload">

                <Columns >
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                             <asp:Label ID="lblname" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
               
                 
     <asp:TemplateField HeaderText="Country">
         <ItemTemplate>
               <asp:Label ID="lblcountry" runat="server" Text='<%# Eval("CountryName") %>'></asp:Label>
         </ItemTemplate>
     </asp:TemplateField>
 

                 
     <asp:TemplateField HeaderText="State">
         <ItemTemplate>
               <asp:Label ID="lblstate" runat="server" Text='<%# Eval("StateName") %>'></asp:Label>
         </ItemTemplate>
     </asp:TemplateField>


                
     <asp:TemplateField HeaderText="City">
         <ItemTemplate>
               <asp:Label ID="lblcity" runat="server" Text='<%# Eval("CityName") %>'></asp:Label>
         </ItemTemplate>
     </asp:TemplateField>


              
     <asp:TemplateField HeaderText="Gender">
         <ItemTemplate>
               <%# Eval("Gender").ToString()=="1"?"Male": Eval("Gender").ToString()=="2"?"Female":"Other" %>
               
         </ItemTemplate>
     </asp:TemplateField>
 
               
     <asp:TemplateField HeaderText="Hobbies">
         <ItemTemplate>
                 <asp:Label ID="lblhobbies" runat="server" Text='<%# Eval("Hobbies") %>'></asp:Label>
         </ItemTemplate>
     </asp:TemplateField>
 
     <asp:TemplateField HeaderText="Image_Upload">
         <ItemTemplate>
         <asp:Image runat="server" ID="img1" Height="50px" Width="40px" ImageUrl='<%#Eval("Image_Upload","../PICS/{0}") %>' />
         </ItemTemplate>
     </asp:TemplateField>

            <asp:TemplateField HeaderText="Action">
         <ItemTemplate>
        <asp:LinkButton ID="btnedit" runat="server" Text="Edit"  CommandName="Aus" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>||
      <asp:LinkButton ID="btndelete" runat="server" Text="Delete" CommandName="Bus" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
         </ItemTemplate>
       </asp:TemplateField>
         </Columns>

            </asp:GridView>
                
        </table>
    </div>
    
   
</asp:Content>
