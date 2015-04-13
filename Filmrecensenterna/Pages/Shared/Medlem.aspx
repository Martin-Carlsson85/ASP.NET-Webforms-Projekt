<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Medlem.aspx.cs" Inherits="Filmrecensenterna.Pages.Shared.WebForm1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      

    <asp:ListView ID="Medlemslist" runat="server"
        ItemType="Filmrecensenterna.Model.BLL.Medlem"
        SelectMethod="Medlemslist_GetData"
        >
        <LayoutTemplate>
                    <table class="grid">
                        <tr>
                            <th>
                                Namn
                            </th>
                            <th>
                                Address
                            </th>
                            <th>
                                Postnr
                            </th>
                            <th>
                                Ort
                            </th>
                            <th>
                            </th>
                        </tr>
                        <%-- Platshållare för nya rader --%>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
         <ItemTemplate>
                    <%-- Mall för nya rader. --%>
                    <tr>
                        <td>
                            <%#: Item.Namn %>
                        </td>
                        <td>
                            <%#: Item.Adress %>
                        </td>
                        <td>
                            <%#: Item.Postnr %>
                        </td>
                        <td>
                            <%# Item.Ort %>
                        </td>
                       
                    </tr>
                </ItemTemplate>




    </asp:ListView>
</asp:Content>
