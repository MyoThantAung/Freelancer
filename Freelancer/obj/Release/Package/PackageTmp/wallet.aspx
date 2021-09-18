<%@ Page Title="" Language="C#" MasterPageFile="~/control.Master" AutoEventWireup="true" CodeBehind="wallet.aspx.cs" Inherits="Freelancer.wallet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="display-4 text-center p-5" >

        Wallet 

    </div>

    <div class="display-2 text-center" runat="server" id="d_balance">

     

    </div>

    <div class="text-center mt-5">
      
        <asp:Button ID="deposit" runat="server" Text="Deposit"  CssClass="btn btn-info mt-5 " OnClick="deposit_Click" />
        <asp:Button ID="withdraw" runat="server" Text="Withdraw"  CssClass="btn btn-danger mt-5 " OnClick="withdraw_Click" />
        

    </div>


         
        <!-- The Modal -->
<div class="modal" id="myModal" style="background-color:rgba(0, 0, 0, 0.50)">
  <div class="modal-dialog">
    <div class="modal-content">

      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title" runat="server" id="model_title">Deposit</h4>
        <button type="button" class="close" onclick="close_model();">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body">

          <div class="row mt-3 mb-3 ml-3 text-danger" id="model_text" runat="server">
              Please Enter Your Bank Card Number
          </div>

          <div class="row w-100 ">
              <div class="col">

                  <asp:TextBox CssClass="form-control mt-3 mb-3" ID="ac" runat="server" placeholder="Card Number"></asp:TextBox>
              </div>

                </div>

          
               <div class="row w-100">
                  <div class="col">
                      <asp:TextBox CssClass="form-control mt-3 mb-3" ID="TextBox4" runat="server" placeholder="MM/YY"></asp:TextBox>
                  </div>
                   <div class="col">
                       <asp:TextBox CssClass="form-control mt-3 mb-3" ID="CVV" runat="server" placeholder="CVV"></asp:TextBox>
                  </div>

                </div>
            
          <div class="row w-100  ">
              <div class="col">

                  <asp:TextBox CssClass="form-control mt-3 mb-3" ID="d_amount" runat="server" placeholder="Amount"></asp:TextBox>
              </div>

                </div>
            
         
       
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
          <asp:Button ID="btn_deposit" runat="server" Text="Deposit" OnClick="btn_deposit_Click" CssClass="btn btn-info" />
        <button type="button" class="btn btn-danger" onclick="close_model();">Close</button>
      </div>

    </div>
  </div>
</div>


        <!-- The Modal -->
<div class="modal" id="myModal1" style="background-color:rgba(0, 0, 0, 0.50)">
  <div class="modal-dialog">
    <div class="modal-content">

      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title" runat="server" id="H1">Withdraw</h4>
        <button type="button" class="close" onclick="close_model1();">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body">

          <div class="row mt-3 mb-3 ml-3 text-danger" id="Div1" runat="server">
              Please Enter Your Bank Card Number
          </div>

          <div class="row w-100 ">
              <div class="col">

                  <asp:TextBox CssClass="form-control mt-3 mb-3" ID="TextBox1" runat="server" placeholder="Card Number"></asp:TextBox>
              </div>

                </div>

          
               <div class="row w-100 ">
                  <div class="col">
                      <asp:TextBox CssClass="form-control mt-3 mb-3" ID="TextBox2" runat="server" placeholder="MM/YY"></asp:TextBox>
                  </div>
                   <div class="col">
                       <asp:TextBox CssClass="form-control mt-3 mb-3" ID="TextBox3" runat="server" placeholder="CVV"></asp:TextBox>
                  </div>

                </div>
            
          <div class="row w-100 ">
              <div class="col">

                  <asp:TextBox CssClass="form-control mt-3 mb-3" ID="w_amount" runat="server" placeholder="Amount"></asp:TextBox>
              </div>

                </div>
            
         
       
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
          <asp:Button ID="btn_withdraw" runat="server" Text="Withdraw" OnClick="btn_withdraw_Click" CssClass="btn btn-dark" />
        <button type="button" class="btn btn-danger" onclick="close_model1();">Close</button>
      </div>

    </div>
  </div>
</div>


    <div class="modal" id="myModal2" style="background-color:rgba(0, 0, 0, 0.50)">
  <div class="modal-dialog">
    <div class="modal-content">

      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title" runat="server" id="H2">Withdraw Error</h4>
        <button type="button" class="close" onclick="close_model2();">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body">

          <div class="row mt-3 mb-3 ml-3 text-danger" id="Div2" runat="server">
              Withdraw Amount is greater than Balance
          </div>

            
         
         
       
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
         
        <button type="button" class="btn btn-danger" onclick="close_model2();">Close</button>
      </div>

    </div>
  </div>
</div>

    <script type="text/javascript">

       
        // Get the modal
        var modal = document.getElementById("myModal");
        var modal1 = document.getElementById("myModal1");
        var modal2 = document.getElementById("myModal2");

        // Get the button that opens the modal
        

        // Get the <span> element that closes the modal
       

        // When the user clicks on the button, open the modal 
        function show_model() {
            modal.style.display = "block";
        }

        function show_model1() {
            modal1.style.display = "block";
        }

        function show_model2() {
            modal2.style.display = "block";
        }

        // When the user clicks on <span> (x), close the modal
        function close_model() {
            modal.style.display = "none";
        }

        function close_model1() {
            modal1.style.display = "none";
        }

        function close_model2() {
            modal2.style.display = "none";
        }

        // When the user clicks anywhere outside of the modal, close it

        // When the user clicks anywhere outside of the modal, close it
       
       

   </script>



</asp:Content>
