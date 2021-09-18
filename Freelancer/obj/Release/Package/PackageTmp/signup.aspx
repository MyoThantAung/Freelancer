<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Freelancer.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
              <div class="row">

                <div class="col">
                        <div class="display-4 " style="margin-top: 200px;margin-left: 150px; ">
                                SignUp & Find Job & Earn
                            </div>
                 
                </div>

                <div class="col-5">
                        <div class="card float-right h-100" style="width:350px;margin-top:-80px;z-index:0;border: 0px;margin-right: 50px;">
     
                                <div class="card-body p-5" style="margin-top: 20px" >
                           
                           
                                 <div class="pl-5 pr-5">
                           
                                     <div  class="ratio img-responsive img-circle" style="background-image: url(image/p-d.jpg);"></div>
                                 </div>
                                   
                           
                                  <h4 class="card-title text-center">SignUp</h4>
                                  
                               
                           
                                   <div class="form-label-group pt-4 pb-4">
                                       
                                     <input type="text" id="username" class="form-control mt-3 mb-3" placeholder="Username" required autofocus runat="server">
                                     <input type="text" id="email" class="form-control mt-3 mb-3" placeholder="Email" required runat="server">
                                     <input type="text" id="phone_no" class="form-control mt-3 mb-3" placeholder="Phone No" required runat="server">
                                     <input type="password" id="pass" class="form-control mt-3 mb-3" placeholder="Password" required runat="server"> 
                                     <input type="password" id="cpass" class="form-control mt-3 mb-3" placeholder="Confrim Password" required runat="server">
                                      
                                       <asp:FileUpload ID="FileUpload" CssClass="w-100" runat="server" />

                                       <span class="text-danger" id="error" runat="server"></span>

                                   </div>
                           
                                   

                           
                             
                                   
                                      <asp:Button ID="Button1" class="btn btn-lg btn-primary btn-block text-uppercase" runat="server" Text="SignUp" OnClick="Button1_Click" />
                                
                           
                                
                                </div>
                           
                               
                              </div> 
                </div>

              </div>


</asp:Content>
