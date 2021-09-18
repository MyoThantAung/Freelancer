<%@ Page Title="" Language="C#" MasterPageFile="~/control.Master" AutoEventWireup="true" CodeBehind="employer.aspx.cs" Inherits="Freelancer.employer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="display-4 text-center" >

        Employer

    </div>

    <asp:GridView ID="GridView1" GridLines="None" CellPadding="4" runat="server" AutoGenerateColumns="False" DataSourceID="empr_SqlDataSource" CssClass="mt-5">
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
            <asp:BoundField DataField="payment_status" HeaderText="payment_status" SortExpression="payment_status" />
        </Columns>

           <HeaderStyle CssClass="p-3 bg-dark text-center text-white" />
        
        <RowStyle CssClass="p-3 bg-white text-dark text-center" />
    </asp:GridView>
    <asp:SqlDataSource ID="empr_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="select [user].profile,[user].name,[user].phone_no,[user].email,job.title,bids.amount,contract.finish_date,contract.payment_status
from [user]
inner join job on [user].user_Id=job.empr_id
inner join bids on job.job_id = bids.job_id
inner join contract on bids.bids_id = contract.bids_id
where bids.empe_id = @empe_id">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="empe_id" SessionField="user_id" />
        </SelectParameters>
    </asp:SqlDataSource>



</asp:Content>
