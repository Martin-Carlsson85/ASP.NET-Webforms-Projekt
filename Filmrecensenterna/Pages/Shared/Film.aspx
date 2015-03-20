<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Film.aspx.cs" Inherits="Filmrecensenterna.Pages.FilmView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <asp:ListView ID="FilmList" runat="server"
            
            ItemType="Filmrecensenterna.Model.BLL.Film"
            SelectMethod="Filmrecensionerna_GetData"
            InsertMethod="Filmrecensionerna_InsertItem"
            UpdateMethod="Filmrecensionerna_UpdateItem"
            DeleteMethod="Filmrecensionerna_DeleteItem"
            InsertItemPosition="FirstItem"
            DataKeyNames="FilmID">
            
            <LayoutTemplate>

            <table class="rentTableGrid">
                <tr>
                    <th>
                        Film
                    </th>
                    <th>
                        Årtal
                    </th>
                </tr>
            
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                </table>     
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#: Item.Filmnamn %>
                    </td>
                    <td>
                        <%#: Item.Årtal %>
                    </td>
                    <td >
                        <asp:LinkButton runat="server" CommandName="Edit" Text="Edit" CausesValidation="false"/>
                        <asp:LinkButton runat="server" CommandName="Delete" Text="Delete" CausesValidation="false" OnClientClick='<%# String.Format("return confirm(\"Vill du verkligen ta bort filmen?\")", Item.FilmID) %>'/>
                   </td>
                    
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td>
                        Rent could not be found.
                    </td>
                </tr>
            </EmptyDataTemplate>
            
             <InsertItemTemplate>
               <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"
                           TextMode="SingleLine"
                           MaxLength="30"
                           Text='<%# BindItem.Filmnamn %>'></asp:TextBox>
                    </td>

                   <td>
                       <asp:TextBox ID="TextBox2" runat="server"
                           TextMode="SingleLine"
                           Text='<%# BindItem.Årtal %>'></asp:TextBox>
                   </td>

                    <td>
                        <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till recension" CausesValidation="True"/>
                    </td>
               </tr>
           </InsertItemTemplate>
        <EditItemTemplate>
                    <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"
                           TextMode="SingleLine"
                           MaxLength="30"
                           Text='<%# BindItem.Filmnamn %>'></asp:TextBox>                        
                    </td>
                    <td>
                       <asp:TextBox ID="TextBox2" runat="server"
                           TextMode="SingleLine"
                           Text='<%# BindItem.Årtal %>'></asp:TextBox>
                   </td>
                    <td>
                       <asp:LinkButton runat="server" CommandName="Update" Text="Save" CausesValidation="true"  ValidationGroup="editDate" />
                       <asp:LinkButton runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false"/>
                   </td>
               </tr> 

           </EditItemTemplate>
        </asp:ListView>
</asp:Content>
