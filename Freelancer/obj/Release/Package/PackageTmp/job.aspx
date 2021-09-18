<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="job.aspx.cs" Inherits="Freelancer.job" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
              <div class="row p-5">

                    <div class="col text-center display-4 p-lg-5">
                        Find Jobs
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                            <input type="text" id="txt_search" class="form-control mt-3 mb-3 float-right " style="width: 200px" placeholder="Search.." runat="server"> 
                    </div>
                    <div class="col text-center">

                        <asp:DropDownList ID="d_skill" runat="server" CssClass="btn btn-light mt-3 mb-3 text-center" Width="200px" OnSelectedIndexChanged="d_skill_SelectedIndexChanged"></asp:DropDownList>
                            
                    </div>

                     <div class="col">
                    <asp:Button ID="search" runat="server" Text="Search" CssClass="btn btn-success float-left mt-3 mb-3" OnClick="search_Click" />

                         </div>
                </div>
            
            
                <div class="row p-4" id="jobs_post" runat="server">
               
                      
</div>
                     


</asp:Content>
