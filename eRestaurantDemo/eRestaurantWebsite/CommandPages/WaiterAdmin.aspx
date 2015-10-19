<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterAdmin.aspx.cs" Inherits="CommandPages_WaiterAdmin" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Waiter Admin</h1>
    <uc1:MessageUserControl ID="MessageUserControl" runat="server" />
    <br />
    <table align="center" style="width: 70%">
       <tr> <td><asp:DropDownList ID="WaiterList" runat="server" DataSourceID="ODSWaiters" DataTextField="FullName" DataValueField="FullName" AppendDataBoundItems="True">
                </asp:DropDownList></td>
        <td><asp:LinkButton ID="FetchWaiter" runat="server">Fetch Waiter</asp:LinkButton></td>
        <asp:ObjectDataSource ID="ODSWaiters" runat="server" DataObjectTypeName="eRestaurantSystem.Entities.Waiter" DeleteMethod="Waiters_Delete" InsertMethod="Waiters_Add" OldValuesParameterFormatString="original_{0}" SelectMethod="Waiter_List" TypeName="eRestaurantSystem.BLL.AdminController" UpdateMethod="Waiters_Update"></asp:ObjectDataSource>
           </tr>
        <tr>
            <td>ID</td>
            <td>
                <asp:Label ID="WaiterID" runat="server" Text="WaiterID"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Phone Number</td>
            <td>
                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Address</td>
            <td>
                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Date Hired (MM/DD/YYYY)</td>
            <td>
                <asp:TextBox ID="DateHired" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Date Released (MM/DD/YYY)</td>
            <td>
                <asp:TextBox ID="DateReleased" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="Insert" runat="server" OnClick="Insert_Click">Insert</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="Update" runat="server">Update</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />

</asp:Content>

