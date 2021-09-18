<%@ Page Title="" Language="C#" MasterPageFile="~/control.Master" AutoEventWireup="true" CodeBehind="post.aspx.cs" Inherits="Freelancer.post" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="display-4 text-center" >

        Upload Post

    </div>

    <div class="mt-5 text-center">

        <asp:TextBox CssClass="form-control mt-3 mb-3 w-100" ID="title" runat="server" placeholder="Title"></asp:TextBox>
        <asp:TextBox CssClass="form-control mt-3 mb-3 w-100" ID="des" runat="server" placeholder="Description" TextMode="MultiLine" Rows="5"></asp:TextBox>
        <asp:TextBox CssClass="form-control mt-3 mb-3 w-100" ID="type" runat="server" placeholder="Skill"></asp:TextBox>
        <asp:TextBox CssClass="form-control mt-3 mb-3 w-100" ID="dur" runat="server" placeholder="Duration"></asp:TextBox>
        <asp:TextBox CssClass="form-control mt-3 mb-3 w-100" ID="wage" runat="server" placeholder="Wage"></asp:TextBox>


        <asp:Button ID="btn_post" runat="server" Text="Post" CssClass="w-100 btn btn-info" OnClick="btn_post_Click" />


        

    </div>

        
   
</asp:Content>
