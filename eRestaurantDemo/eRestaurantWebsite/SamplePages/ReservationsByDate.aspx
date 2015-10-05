<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReservationsByDate.aspx.cs" Inherits="SamplePages_ReservationsByDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Reservations By Date (Repeater) </h1>
    <table style="width: 70%">
        <tr>
            <td align="right">Enter reservation date (mm/dd/yyyy):
            </td>
            <td>
                <asp:TextBox ID="ReservationDateArg" runat="server"
                ToolTip="mm/dd/yyy" Text="01/01/1990"></asp:TextBox>
                &nbsp;<asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
        </tr>
        <tr>

            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;
                <div class="row col-md-12">
                    <asp:Repeater ID="EventReservations" runat="server" DataSourceID="EventReservation">
                        <ItemTemplate>
                            <h3><%# Eval("Description") %></h3>
                            <asp:Repeater ID="ReservationList" runat="server" 
                                DataSource='<%# Eval("Reservations") %>'>
                                <ItemTemplate>
                                    <h5>
                                        <%# Eval("CustomerName") %>
                                        <%# Eval("ContactPhone") %>
                                    </h5>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:Repeater>

                    <asp:ObjectDataSource ID="EventReservation" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByDate" TypeName="eRestaurantSystem.BLL.AdminController">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="ReservationDateArg" Name="reservationdate" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </td>
        </tr>
    </table>

</asp:Content>

