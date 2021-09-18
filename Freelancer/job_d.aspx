<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="job_d.aspx.cs" Inherits="Freelancer.job_d" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row p-5">

                    <div class="col text-center h4">
                        Interest Jobs
                    </div>
                </div>

          
            
            
            <div class="row p-4" id="job_display" runat="server">
               
            
            
            
                

             </div>

    <!-- The Modal -->
<div class="modal" id="myModal" style="background-color:rgba(0, 0, 0, 0.50)">
  <div class="modal-dialog">
    <div class="modal-content">

      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title">Bids Content</h4>
        <button type="button" class="close" onclick="close_model();">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body">
          <div class="row mt-3 mb-3 ml-3 text-danger" id="wage_d" runat="server">
              
          </div>
          <div class="row">
              <div class="col">
                   <input type="text" id="bid_amount" class="form-control mt-3 mb-3" placeholder="Bids Amount"  required autofocus runat="server">
              </div>
              <div class="col">
                  <asp:Button ID="bids" runat="server" Text="Bids" CssClass="btn btn-success mt-3 mb-3" OnClick="bids_Click" />
              </div>
          </div>
       
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" onclick="close_model();">Close</button>
      </div>

    </div>
  </div>
</div>

    <script type="text/javascript">

       
        // Get the modal
        var modal = document.getElementById("myModal");

        // Get the button that opens the modal
        

        // Get the <span> element that closes the modal
       

        // When the user clicks on the button, open the modal 
        function show_model() {
            modal.style.display = "block";
        }

        // When the user clicks on <span> (x), close the modal
        function close_model() {
            modal.style.display = "none";
        }

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        } 

    </script>

</asp:Content>
