<%@ Page Title="" Language="C#" MasterPageFile="~/control.Master" AutoEventWireup="true" CodeBehind="employee.aspx.cs" Inherits="Freelancer.employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="display-4 text-center" >

        Employee

    </div>
    
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataSourceID="empeSqlDataSource" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" CssClass="mt-5">
    
        <Columns>
            <asp:TemplateField HeaderText="profile" SortExpression="profile">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("profile") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("profile") %>' Width="40px" Height="40px" CssClass="rounded-circle"/>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="phone_no" HeaderText="phone_no" SortExpression="phone_no" />
            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
            <asp:BoundField DataField="finish_date" HeaderText="finish_date" SortExpression="finish_date" />
            <asp:BoundField DataField="con_id" HeaderText="con_id" SortExpression="con_id" ItemStyle-CssClass="text-hide" HeaderStyle-CssClass="text-hide"/>
            <asp:BoundField DataField="balance" HeaderText="Balance" SortExpression="balance" ItemStyle-CssClass="text-hide" HeaderStyle-CssClass="text-hide" />
             <asp:BoundField DataField="user_id" HeaderText="user_id" SortExpression="user_id" ItemStyle-CssClass="text-hide" HeaderStyle-CssClass="text-hide" />
            <asp:TemplateField HeaderText="Payment">
                <ItemTemplate>

                    <asp:Label  ID = "labell" runat = "server" Text = "Paid" CssClass = '<%# isPaid(Eval("payment_status").ToString()) %>' />
                    <asp:Button  ID = "btn_paid" runat="server" Text = "Pay" CssClass = '<%# isUnPaid(Eval("payment_status").ToString()) %>' OnCommand="btn_paid_Command"  CommandArgument='<%# Container.DataItemIndex %>'  />
                    
               

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>


        <HeaderStyle CssClass="p-3 bg-dark text-center text-white" />
        
        <RowStyle CssClass="p-3 bg-white text-dark text-center" />


    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
<asp:SqlDataSource ID="empeSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select [user].profile,[user].name,[user].phone_no,[user].email,job.title,bids.amount,contract.finish_date,contract.payment_status,contract.con_id,[user].balance,[user].user_id
from [user]
inner join bids on [user].user_Id=bids.empe_id
inner join contract on bids.bids_id = contract.bids_id
inner join job on bids.job_id = job.job_id
where job.empr_id = @user_id">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="0" Name="user_id" SessionField="user_id" />
    </SelectParameters>
    </asp:SqlDataSource>


 
        <!-- The Modal -->
<div class="modal" id="myModal" style="background-color:rgba(0, 0, 0, 0.50)">
  <div class="modal-dialog">
    <div class="modal-content">

      <!-- Modal Header -->
      <div class="modal-header">
        <h4 class="modal-title">Info</h4>
        <button type="button" class="close" onclick="close_model();">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body">
          <div class="row mt-3 mb-3 ml-3 text-danger" id="model_text" runat="server">
              
          </div>
         
       
      </div>

      <!-- Modal footer -->
      <div class="modal-footer">
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
      <div class="modal-header" style="background-color:#f3f3f3">
        <h4 class="modal-title">Rating</h4>
        <button type="button" class="close" onclick="close_model1();">&times;</button>
      </div>

      <!-- Modal body -->
      <div class="modal-body" style="background-color:#f3f3f3">
          
         
          <div class="row p-5">
              <div class="col m-2">
                  <asp:ImageButton ID="r1" src="image/r1.png" class="img-fluid zoom" runat="server" OnClick="r1_Click" />
                  
              </div>
              <div class="col m-2">
                 <asp:ImageButton ID="r2" src="image/r2.png" class="img-fluid zoom" runat="server" OnClick="r1_Click" />
              </div>
              <div class="col m-2">
                  <asp:ImageButton ID="r3" src="image/r3.png" class="img-fluid zoom" runat="server" OnClick="r1_Click" />
              </div>
              <div class="col m-2">
                  <asp:ImageButton ID="r4" src="image/r4.png" class="img-fluid zoom" runat="server" OnClick="r1_Click" />
              </div>
          </div>
       
      </div>

    

    </div>
  </div>
</div>





    <script type="text/javascript">

       
        // Get the modal
        var modal = document.getElementById("myModal");
        var modal1 = document.getElementById("myModal1");

        // Get the button that opens the modal
        

        // Get the <span> element that closes the modal
       

        // When the user clicks on the button, open the modal 
        function show_model() {
            modal.style.display = "block";
        }
        function show_model1() {
            modal1.style.display = "block";
        }

        // When the user clicks on <span> (x), close the modal
        function close_model() {
            modal.style.display = "none";
        }
        function close_model1() {
            modal1.style.display = "none";
        }

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
                modal1.style.display = "none";
            }
        } 

    </script>


</asp:Content>
