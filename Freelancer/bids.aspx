<%@ Page Title="" Language="C#" MasterPageFile="~/control.Master" AutoEventWireup="true" CodeBehind="bids.aspx.cs" Inherits="Freelancer.bids" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="display-4 text-center" >

        Bids

    </div>

    <asp:GridView ID="GridView1" BorderStyle="None" GridLines="None" runat="server" AutoGenerateColumns="False" DataKeyNames="user_id" DataSourceID="bids_SqlDataSource" CssClass="mt-5">
    <Columns>
        <asp:BoundField DataField="bids_id" HeaderStyle-CssClass="p-3 bg-dark text-center text-white" ItemStyle-CssClass="p-3 bg-white text-dark text-center" HeaderText="Bids Id" ReadOnly="True" SortExpression="bids_id" >
<HeaderStyle CssClass="p-3 bg-dark text-center text-white"></HeaderStyle>

<ItemStyle CssClass="p-3 bg-white text-dark text-center"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="user_id" HeaderStyle-CssClass="p-3 bg-dark text-center text-white" ItemStyle-CssClass="p-3 bg-white text-dark text-center" HeaderText="User Id" ReadOnly="True" SortExpression="user_id" >
<HeaderStyle CssClass="p-3 bg-dark text-center text-white"></HeaderStyle>

<ItemStyle CssClass="p-3 bg-white text-dark text-center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="name" HeaderStyle-CssClass="p-3 bg-dark text-center text-white" ItemStyle-CssClass="p-3 bg-white text-dark text-center" HeaderText="Name" SortExpression="name" >
<HeaderStyle CssClass="p-3 bg-dark text-center text-white"></HeaderStyle>

<ItemStyle CssClass="p-3 bg-white text-dark text-center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="email" HeaderStyle-CssClass="p-3 bg-dark text-center text-white" ItemStyle-CssClass="p-3 bg-white text-dark text-center" HeaderText="Email" SortExpression="email" >
<HeaderStyle CssClass="p-3 bg-dark text-center text-white"></HeaderStyle>

<ItemStyle CssClass="p-3 bg-white text-dark text-center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="phone_no" HeaderStyle-CssClass="p-3 bg-dark text-center text-white" ItemStyle-CssClass="p-3 bg-white text-dark text-center" HeaderText="Phone No" SortExpression="phone_no" >
<HeaderStyle CssClass="p-3 bg-dark text-center text-white"></HeaderStyle>

<ItemStyle CssClass="p-3 bg-white text-dark text-center"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="amount" HeaderStyle-CssClass="p-3 bg-dark text-center text-white" ItemStyle-CssClass="p-3 bg-white text-dark text-center" HeaderText="Amount" SortExpression="amount" >
<HeaderStyle CssClass="p-3 bg-dark text-center text-white"></HeaderStyle>

<ItemStyle CssClass="p-3 bg-white text-dark text-center"></ItemStyle>
        </asp:BoundField>

        <asp:BoundField DataField="date" HeaderStyle-CssClass="p-3 bg-dark text-center text-white" ItemStyle-CssClass="p-3 bg-white text-dark text-center" HeaderText="Date" SortExpression="date" >
<HeaderStyle CssClass="p-3 bg-dark text-center text-white"></HeaderStyle>

<ItemStyle CssClass="p-3 bg-white text-dark text-center"></ItemStyle>
        </asp:BoundField>
        <asp:TemplateField  HeaderStyle-CssClass="p-3 bg-dark text-center text-white" HeaderText="To Hire" ItemStyle-CssClass="p-3 bg-white text-dark text-center">
            <ItemTemplate>
                <asp:Button ID="b_bids" runat="server"  CssClass="btn btn-info" OnCommand="b_bids_Command" Text="Hire" CommandArgument='<%# Container.DataItemIndex %>' />
            </ItemTemplate>

<HeaderStyle CssClass="p-3 bg-dark text-center text-white"></HeaderStyle>

<ItemStyle CssClass="p-3 bg-white text-dark text-center"></ItemStyle>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="bids_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT bids.bids_id,[user].user_id,[user].name,[user].email,[user].phone_no,bids.amount,bids.date FROM [user] INNER JOIN bids ON bids.empe_id = [user].user_id where bids.job_id=@job_id;">
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="0" Name="job_id" QueryStringField="job_id" />
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
