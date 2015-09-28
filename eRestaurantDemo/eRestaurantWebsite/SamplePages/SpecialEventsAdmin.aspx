<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventsAdmin.aspx.cs" Inherits="SamplePages_SpecialEventsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Special Events Administration  </h1>
    <table align="center" style="width:80%;">
        <tr>
            <td align="right" style="width:50%; height: 22px;">Select an event:&nbsp;&nbsp;</td>
            <td style="height: 22px">
            <asp:DropDownList ID="SpecialEventList" runat="server"
                width="200px" AppendDataBoundItems="True" DataSourceID="ODSSpecialEvents" DataTextField="EventCode" DataValueField="EventCode">
                <asp:ListItem Value="z">Special Event</asp:ListItem>
            </asp:DropDownList>
            <asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
            <td style="height: 22px"></td>
        </tr>
        <tr>
            
               <td colspan="2">&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;
            <asp:GridView ID="ReservationList" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSReservations">
                <Columns>
                    <asp:BoundField DataField="CustomerName" HeaderText="Name" SortExpression="CustomerName" />
                    <asp:BoundField DataField="ReservationDate" HeaderText="Date" SortExpression="ReservationDate" />
                    <asp:BoundField DataField="ReservationStatus" HeaderText="Status" SortExpression="ReservationStatus" />
                    <asp:BoundField DataField="ContactPhone" HeaderText="Phone" SortExpression="ContactPhone" />
                    <asp:BoundField DataField="NumberInParty" HeaderText="Size" SortExpression="NumberInParty" />
                </Columns>
                <EmptyDataTemplate>
                    No data to display at this time
                </EmptyDataTemplate>
            </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align-"center">&nbsp;
            <asp:DetailsView ID="ReservationsListDT" runat="server" Height="50px" Width="125px" DataSourceID="ODSReservations">
                <EmptyDataTemplate>
                    No data to display at this time
                </EmptyDataTemplate>
            </asp:DetailsView></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
    <asp:ObjectDataSource ID="ODSSpecialEvents" runat="server" OldValuesParameterFormatString="original_{0}"
         SelectMethod="SpecialEvent_List" TypeName="eRestaurantSystem.BLL.AdminController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSReservations" runat="server" OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetReservationByEventCode" TypeName="eRestaurantSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SpecialEventList" Name="eventcode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

