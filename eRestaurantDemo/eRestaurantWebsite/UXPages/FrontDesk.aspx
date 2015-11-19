<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FrontDesk.aspx.cs" Inherits="UXPages_FrontDesk" %>

<%@ Register Src="~/UserControls/DateTimeMocker.ascx" TagPrefix="uc1" TagName="DateTimeMocker" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:DateTimeMocker runat="server" id="DateTimeMocker" />
    <!-- this is the presentation markup code for the reservation display -->
        <div class="pull-right col-md-5">
            <!-- details is a bootstrap collapsable area -->
        <details open>
            <!-- the text displayed beside the detail icon -->
            <summary>Reservations by Date/Time</summary>
            <h4>Today's Reservations</h4>
            <!-- ItemType= parameters must be directed to your current application locations -->
            <asp:Repeater ID="ReservationsRepeater" runat="server"
                ItemType="eRestaurantSystem.Entities.DTOs.ReservationCollection" DataSourceID="ReservationsDataSource">
                <ItemTemplate>
                    <div>
                        <h4><%# Item.SeatingTime %></h4>
                        <asp:ListView ID="ReservationSummaryListView" runat="server"
                                ItemType="eRestaurantSystem.Entities.POCOs.ReservationSummary"
                                DataSource="<%# Item.Reservations %>">
                            <LayoutTemplate>
                                <div class="seating">
                                    <span runat="server" id="itemPlaceholder" />
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div>
                                    <%# Item.Name %> —
                                    <%# Item.NumberInParty %> —
                                    <%# Item.Status %> —
                                    PH:
                                    <%# Item.Contact %>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource runat="server" ID="ReservationsDataSource" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="ReservationsByTime" 
                TypeName="eRestaurantSystem.BLL.AdminController">
                <SelectParameters>
                    <asp:ControlParameter ControlID="SearchTime" PropertyName="Text" Name="date" Type="DateTime"></asp:ControlParameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </details>
    </div>
</asp:Content>