<%@ Page Title="" Language="C#" MasterPageFile="~/control.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Freelancer.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="display-4 text-center mb-5" style="margin-top:-20px;" >

        Profile

      </div>

        
    
    <asp:ListView ID="ListView1" runat="server" DataSourceID="Profile_SqlDataSource">
        <AlternatingItemTemplate>
            <span style="">name:
            <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
            <br />
            email:
            <asp:Label ID="emailLabel" runat="server" Text='<%# Eval("email") %>' />
            <br />
            phone_no:
            <asp:Label ID="phone_noLabel" runat="server" Text='<%# Eval("phone_no") %>' />
            <br />
            address:
            <asp:Label ID="addressLabel" runat="server" Text='<%# Eval("address") %>' />
            <br />
            degree:
            <asp:Label ID="degreeLabel" runat="server" Text='<%# Eval("degree") %>' />
            <br />
            experience:
            <asp:Label ID="experienceLabel" runat="server" Text='<%# Eval("experience") %>' />
            <br />
            self_description:
            <asp:Label ID="self_descriptionLabel" runat="server" Text='<%# Eval("self_description") %>' />
            <br />
            profile:
            <asp:Label ID="profileLabel" runat="server" Text='<%# Eval("profile") %>' />
            <br />
            identify_document:
            <asp:Label ID="identify_documentLabel" runat="server" Text='<%# Eval("identify_document") %>' />
            <br />
            <br />
            </span>
        </AlternatingItemTemplate>
        <EditItemTemplate>


              
        <div class="row text-center" style="margin-top:70px;">

              <div class="col">
                  Name
              </div>
             
              <div class="col">
                   
                   <asp:TextBox CssClass="form-control mt-1 mb-1" ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
              </div>


          </div>


          <div class="row text-center">

              <div class="col">
                 Email
              </div>
             
              <div class="col">
                    <asp:TextBox CssClass="form-control mt-1 mb-1" ID="emailTextBox" runat="server" Text='<%# Bind("email") %>' />
              </div>


          </div>
          
        
          <div class="row text-center">

              <div class="col">
                 Phone_No
              </div>
             
              <div class="col">
                    <asp:TextBox CssClass="form-control mt-1 mb-1" ID="phone_noTextBox" runat="server" Text='<%# Bind("phone_no") %>' />
              </div>


          </div>
         
        
           <div class="row text-center">

              <div class="col">
                 Address
              </div>
             
              <div class="col">
                     <asp:TextBox CssClass="form-control mt-1 mb-1" ID="addressTextBox" runat="server" Text='<%# Bind("address") %>' />
              </div>


          </div>
         
          
           <div class="row text-center">

              <div class="col">
                  Degree
              </div>
             
              <div class="col">
                     <asp:TextBox CssClass="form-control mt-1 mb-1" ID="degreeTextBox" runat="server" Text='<%# Bind("degree") %>' />
              </div>


          </div>
         
         <div class="row text-center">

              <div class="col">
                  Experience
              </div>
             
              <div class="col">
                    <asp:TextBox CssClass="form-control mt-1 mb-1" ID="experieneTextBox" runat="server" Text='<%# Bind("experience") %>' />
              </div>


          </div>
        
         
         <div class="row text-center">

              <div class="col">
                   Self_description
              </div>
             
              <div class="col">
                    <asp:TextBox CssClass="form-control mt-1 mb-1" ID="self_descriptionTextBox" runat="server" Text='<%# Bind("self_description") %>' />
              </div>


          </div>
          
          
       <div class="row text-center">

              <div class="col">
                    Profile
              </div>
             
              <div class="col">


                  <asp:FileUpload ID="File_Upload" runat="server" />
                 <asp:Button ID="fileupload" runat="server" Text="Upload" CssClass="btn btn-info" OnClick="fileupload_Click" />
                    <asp:TextBox CssClass="form-control mt-1 mb-1" ID="profileTextBox" runat="server"  Text='<%# Bind("profile") %>' />
              </div>


          </div>


            <div class="row text-center">

              <div class="col">
                     Identify_Document
              </div>
             
              <div class="col">


                  <asp:FileUpload ID="File_Upload1" runat="server" />
                 <asp:Button ID="flie1upload" runat="server" Text="Upload" CssClass="btn btn-info" OnClick="flie1upload_Click" />
                   <asp:TextBox CssClass="form-control mt-1 mb-1" ID="identify_documentTextBox" runat="server" Text='<%# Bind("identify_document") %>' />
              </div>


          </div>


    <div class="row text-center">

        <div class="col">

        </div>

        <div class="col m-5">

             <asp:Button ID="Button1" runat="server" CommandName="Update" Text="Update" CssClass="btn btn-info" />
             <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-danger" />
        </div>

    </div>


           
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span style="">name:
            <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
            <br />
            email:
            <asp:TextBox ID="emailTextBox" runat="server" Text='<%# Bind("email") %>' />
            <br />
            phone_no:
            <asp:TextBox ID="phone_noTextBox" runat="server" Text='<%# Bind("phone_no") %>' />
            <br />
            address:
            <asp:TextBox ID="addressTextBox" runat="server" Text='<%# Bind("address") %>' />
            <br />
            degree:
            <asp:TextBox ID="degreeTextBox" runat="server" Text='<%# Bind("degree") %>' />
            <br />
            experience:
            <asp:TextBox ID="experienceTextBox" runat="server" Text='<%# Bind("experience") %>' />
            <br />
            self_description:
            <asp:TextBox ID="self_descriptionTextBox" runat="server" Text='<%# Bind("self_description") %>' />
            <br />
            profile:
            <asp:TextBox ID="profileTextBox" runat="server" Text='<%# Bind("profile") %>' />
            <br />
            identify_document:
            <asp:TextBox ID="identify_documentTextBox" runat="server" Text='<%# Bind("identify_document") %>' />
            <br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
            <br />
            <br />
            </span>
        </InsertItemTemplate>
        <ItemTemplate>



              <div class="row text-center p-3" style="margin-top:70px;">

              <div class="col">
                  Name
              </div>
             
              <div class="col">
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("name") %>' CssClass="mt-1 mb-1 text-monospace" />
              </div>


          </div>


          <div class="row text-center p-2">

              <div class="col">
                 Email
              </div>
             
              <div class="col">
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("email") %>' CssClass="mt-1 mb-1 text-monospace"/>
              </div>


          </div>
          
        
          <div class="row text-center p-2">

              <div class="col">
                 Phone_No
              </div>
             
              <div class="col">
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("phone_no") %>' CssClass="mt-1 mb-1 text-monospace"/>
              </div>


          </div>
         
        
           <div class="row text-center p-2">

              <div class="col">
                 Address
              </div>
             
              <div class="col">
                     <asp:Label ID="Label4" runat="server" Text='<%# Eval("address") %>' CssClass="mt-1 mb-1 text-monospace" />
              </div>


          </div>
         
          
           <div class="row text-center p-2">

              <div class="col">
                  Degree
              </div>
             
              <div class="col">
                     <asp:Label ID="Label5" runat="server" Text='<%# Eval("degree") %>' CssClass="mt-1 mb-1 text-monospace"/>
              </div>


          </div>
         
         <div class="row text-center p-2">

              <div class="col">
                  Experience
              </div>
             
              <div class="col">
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("experience") %>' CssClass="mt-1 mb-1 text-monospace"/>
              </div>


          </div>
        
         
         <div class="row text-center p-2">

              <div class="col">
                   Self_description
              </div>
             
              <div class="col">
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("self_description") %>' CssClass="mt-1 mb-1 text-monospace"/>
              </div>


          </div>
          
          
       <div class="row text-center p-2">

              <div class="col">
                     Profile
              </div>
             
              <div class="col">
                   
            <asp:Label ID="Label8" runat="server" Text='<%# Eval("profile") %>' CssClass="mt-1 mb-1 text-monospace"/>
              </div>


          </div>


            <div class="row text-center p-2">

              <div class="col">
                  Identify_Document
              </div>
             
              <div class="col">
                   
             <asp:Label ID="identify_documentLabel" runat="server" Text='<%# Eval("identify_document") %>' CssClass="mt-1 mb-1 text-monospace"/>
              </div>


          </div>

      <div class="row text-center p-2">

          <div class="col">


          </div>

           <div class="col">

                <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-dark m-5" />
          </div>

          </div>


           
           
        </ItemTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="">
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <span style="">name:
            <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
            <br />
            email:
            <asp:Label ID="emailLabel" runat="server" Text='<%# Eval("email") %>' />
            <br />
            phone_no:
            <asp:Label ID="phone_noLabel" runat="server" Text='<%# Eval("phone_no") %>' />
            <br />
            address:
            <asp:Label ID="addressLabel" runat="server" Text='<%# Eval("address") %>' />
            <br />
            degree:
            <asp:Label ID="degreeLabel" runat="server" Text='<%# Eval("degree") %>' />
            <br />
            experience:
            <asp:Label ID="experienceLabel" runat="server" Text='<%# Eval("experience") %>' />
            <br />
            self_description:
            <asp:Label ID="self_descriptionLabel" runat="server" Text='<%# Eval("self_description") %>' />
            <br />
            profile:
            <asp:Label ID="profileLabel" runat="server" Text='<%# Eval("profile") %>' />
            <br />
            identify_document:
            <asp:Label ID="identify_documentLabel" runat="server" Text='<%# Eval("identify_document") %>' />
            <br />
            <br />
            </span>
        </SelectedItemTemplate>
    </asp:ListView>
        
        <asp:SqlDataSource ID="Profile_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [name], [email], [phone_no], [address], [degree], [experience], [self_description],[profile],[identify_document] FROM [user] WHERE ([user_Id] = @user_Id)" OnSelecting="Profile_SqlDataSource_Selecting" UpdateCommand="UPDATE [user] SET name =@name, email = @email, phone_no = @phone_no, address = @address, degree = @degree, experience = @experience, self_description = @self_description, profile = @profile, identify_document = @identify_document where user_id=@user_id">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="user_Id" SessionField="user_id" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter ConvertEmptyStringToNull="False" Name="name" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="email" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="phone_no" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="address" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="degree" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="experience" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="self_description" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="profile" />
                <asp:Parameter ConvertEmptyStringToNull="False" Name="identify_document" />
                <asp:SessionParameter DefaultValue="0" Name="user_id" SessionField="user_id" />
            </UpdateParameters>
        </asp:SqlDataSource>




</asp:Content>
