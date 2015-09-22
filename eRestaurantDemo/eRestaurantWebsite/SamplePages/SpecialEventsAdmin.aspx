<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventsAdmin.aspx.cs" Inherits="SamplePages_SpecialEventsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Special Events Administration  </h1>
    <table align="center" style="width:80%;">
        <tr>
            <td align="right" style="width:50%; height: 22px;">Select an event:&nbsp;&nbsp;</td>
            <td style="height: 22px"></td>
            <td style="height: 22px"></td>
        </tr>
        <tr>
            <td>
            <asp:DropDownList ID="SpecialEventList" runat="server"
                width="200px" OnSelectedIndexChanged="SpecialEventList_SelectedIndexChanged">
            </asp:DropDownList>&nbsp;&nbsp;
            <asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <asp:GridView ID="ReservationList" runat="server"></asp:GridView>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
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
    <asp:ObjectDataSource ID="ODSSpecialEvents" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSReservations" runat="server"></asp:ObjectDataSource>
</asp:Content>

