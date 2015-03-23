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

            <table class="Film1">
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
                        <asp:Label ID="RightMessage" CssClass="RightMessage" runat="server" />
                        <asp:LinkButton runat="server" CommandName="Edit" Text="Ändra" CausesValidation="false" /> 
                        <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick='<%# String.Format("return confirm(\"Vill du verkligen ta bort filmen {0}? \")", Item.Filmnamn) %>'/>
                   </td>
                    
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <tr>
                    <td>
                       
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
                           MaxLength="4"
                           Text='<%# BindItem.Årtal %>'></asp:TextBox>
                   </td>

                    <td>
                        <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till film" CausesValidation="True"/>
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
                       <asp:LinkButton runat="server" CommandName="Update" Text="Spara" CausesValidation="true"  ValidationGroup="editDate" />
                       <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false"/>
                   </td>
               </tr> 

           </EditItemTemplate>
        </asp:ListView>
</asp:Content>
