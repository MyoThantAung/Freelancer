<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Freelancer.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--card1-->
<div class="card" style="width:100%;margin-top:-75px;">
        <img class="card-img-top" src="image/office.jpg" alt="Card image">
        <div class="card-img-overlay text-center hire_title" >
          <h2 class="card-title">We are hire!</h2>
          <p class="card-text display-4">Join Us & Gain Earn.</p>

          <a href="signup.aspx" class="btn btn-primary">Get Start</a>

        </div>
      </div>


<!-- Gird - job card -->

<div class="row p-5">

        <div class="col text-center h4" style="margin-left:120px">
            Recent Jobs

          

        </div>

      <a class="float-right btn btn-outline-info" href="job.aspx" style="font-size:16px;">See More </a>
    </div>


 <div class="row p-4" id="job_card" runat="server">
               
          
                        </div>





     <!-- card2 -->
<div class="card mt-5" style="width:100%;">
        <img class="card-img-top" src="image/emp.png" alt="Card image">
        <div class="card-img-overlay text-right emp_card" >
         
          <p class="card-text display-4 pb-3 emp_title">Do you need<br>Employee to extend<br>your job</p>
          <a href="person.aspx" class="btn btn-primary">Learn More</a>
        </div>
      </div> 


       <!-- Grid-employee -->

       <div class="row p-5" >

        <div class="col text-center h4" style="margin-left:120px"">
            Our best Freelancer
        </div>
            <a class="float-right btn btn-outline-info" href="person.aspx" style="font-size:16px;">See More </a>
    </div>

        <div class="row" id="d_person" runat="server">
               

                  

                      
        </div>

        

      



        <!-- Footer -->
<footer class="page-footer font-small indigo p-5 mt-5" style="background: black;color: dimgray;height: 300px;">

        <!-- Footer Links -->
        <div class="container-fluid text-center text-md-left">
      
          <!-- Grid row -->
          <div class="row">
      
            <!-- Grid column -->
            <div class="col-md-6 mt-md-0 mt-3">
      
              <!-- Content -->
              <h5 class="text-uppercase">Contact With Us</h5>
              <p> <i class="fas fa-envelope"> myothantaung.pro@gmail.com</i> </p>
      
            </div>
            <!-- Grid column -->
      
            <hr class="clearfix w-100 d-md-none pb-3">
      
            <!-- Grid column -->
            <div class="col-md-3 mb-md-0 mb-3">
      
              <!-- Links -->
              <h5 class="text-uppercase">Site Map</h5>
      
              <ul class="list-unstyled">
                <li>
                  <a href="login.aspx">Login</a>
                </li>
                <li>
                  <a href="signup.aspx">SignUp</a>
                </li>
                <li>
                  <a href="#!">Jobs</a>
                </li>
                <li>
                  <a href="#!">post</a>
                </li>
              </ul>
      
            </div>
            <!-- Grid column -->
      
      
        </div>
        <!-- Footer Links -->
      
        <!-- Copyright -->
       
        <!-- Copyright -->
      
      </footer>
      <!-- Footer -->


    
</asp:Content>
