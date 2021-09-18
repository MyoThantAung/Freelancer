<%@ Page Title="" Language="C#" MasterPageFile="~/control.Master" AutoEventWireup="true" CodeBehind="mypost.aspx.cs" Inherits="Freelancer.mypost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="display-4 text-center" >

        My Post

    </div>

    <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False"  BorderStyle="None"  CellPadding="3" DataKeyNames="job_id" DataSourceID="mypost_SqlDataSource" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CssClass="mt-5">
        
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="job_id"  HeaderText="Job Id" ReadOnly="True" SortExpression="job_id" />
            <asp:BoundField DataField="title"  HeaderText="Title" SortExpression="title" />
            <asp:BoundField DataField="description"  HeaderText="Description" SortExpression="description" />
            <asp:BoundField DataField="skill"  HeaderText="Skill" SortExpression="skill" />
            <asp:BoundField DataField="duration"  HeaderText="Duration" SortExpression="duration" />
            <asp:BoundField DataField="wage"  HeaderText="Wages" SortExpression="wage" />
            <asp:BoundField DataField="job_status"  HeaderText="Job Status" ReadOnly="True" SortExpression="job_status" />
            <asp:BoundField DataField="date" HeaderText="Date" ReadOnly="True" SortExpression="date" />
            <asp:ButtonField ButtonType="Button" CommandName="Delete" ControlStyle-CssClass="btn btn-danger" HeaderText="Change Job Status" ShowHeader="True" Text="Complete" />
            <asp:TemplateField HeaderText="Bids">
                <ItemTemplate>
                    <asp:Button ID="show_bids_btn" CssClass="btn btn-dark" runat="server" OnCommand="show_bids_btn_Command" Text="Show Bids" CommandArgument='<%# Container.DataItemIndex %>'/>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
       
        <HeaderStyle CssClass="p-3 bg-dark text-center text-white" />
        
        <RowStyle CssClass="p-3 bg-white text-dark text-center" />

      
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
    <asp:SqlDataSource ID="mypost_SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="update job set job_status=@jobstatus
where job_id=@job_id" SelectCommand="SELECT [job_id], [title], [description], [skill], [duration], [wage], [job_status], [date] FROM [job] WHERE ([empr_id] = @empr_id)" UpdateCommand="UPDATE job SET title =@title, description =@description, skill =@skill, duration =@duration, wage =@wage where job_id=@job_id">
        <DeleteParameters>
            <asp:Parameter DefaultValue="Complete" Name="jobstatus" />
            <asp:ControlParameter ControlID="GridView1" DefaultValue="0" Name="job_id" PropertyName="SelectedValue" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="empr_id" SessionField="user_id" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="title" />
            <asp:Parameter Name="description" />
            <asp:Parameter Name="skill" />
            <asp:Parameter Name="duration" />
            <asp:Parameter Name="wage" />
            <asp:Parameter Name="job_id" />
        </UpdateParameters>
    </asp:SqlDataSource>

        

</asp:Content>
