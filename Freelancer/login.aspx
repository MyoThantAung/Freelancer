<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Freelancer.login" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

                <div class="col">
                        <div class="display-4 " style="margin-top: 200px;margin-left: 150px; ">
                                Login & Find Job & Earn
                            </div>
                 
                </div>

                <div class="col-5">
                        <div class="card float-right " style="width:350px;margin-top:-50px;z-index:0;border: 0px;margin-right: 50px;height:700px;">
     
                                <div class="card-body p-5" style="margin-top: 20px" >
                           
                           
                                 <div class="pl-5 pr-5">
                           
                                     <div  class="ratio img-responsive img-circle" style="background-image: url(image/p-d.jpg);"></div>
                                 </div>
                                   
                           
                                  <h4 class="card-title text-center">LogIn</h4>
                                  
                                  <form class="form-signin">
                           
                                   <div class="form-label-group pt-4 pb-4">
                                       
                                     <input type="text" id="username" class="form-control mt-3 mb-3" placeholder="Username"  required autofocus runat="server">
                       
                                     <input type="password" id="pass" class="form-control mt-3 mb-3" placeholder="Password" required runat="server"> 
                               
                                     <span id="error" class="text-danger p-2" runat="server"></span>
                                     
                                   </div>
                           
                                   
                           
                             
                                  
                                   
                                      <asp:Button ID="btn_login" runat="server" Text="Login" CssClass="btn btn-lg btn-primary btn-block text-uppercase" OnClick="btn_login_Click"/>

                                 </form>
                           
                                
                                </div>
                           
                               
                              </div> 
                </div>

              </div>


</asp:Content>
