<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Recension.aspx.cs" Inherits="Filmrecensenterna.Pages.Recension" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <asp:ListView ID="Filmrecensenterna" runat="server"
            
            ItemType="Filmrecensenterna.Model.BLL.Recension"
            SelectMethod="Filmrecensionerna_GetData"
            InsertMethod="Filmrecensionerna_InsertItem"
            UpdateMethod="Filmrecensionerna_UpdateItem"
            DeleteMethod="Filmrecensionerna_DeleteItem"
            InsertItemPosition="FirstItem"
            DataKeyNames="RecID" OnSelectedIndexChanged="Filmrecensenterna_SelectedIndexChanged">
            
            <LayoutTemplate>

            <table class="Recensioner1">
                <tr>
                    <th>
                        Film
                    </th>
                    <th>
                        Årtal
                    </th>
                    <th>
                        Recension
                    </th>
                     <th>
                        Namn
                    </th>
                </tr>
            
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                </table>     
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#: Item.Film %>
                    </td>
                    <td>
                        <%#: Item.Årtal %>
                    </td>
                    <td>
                        <%# Item.Recensionen %>
                    </td>
                    <td>
                        <%# GetName(Item.MedlemID) %>
                    </td>
                    <td >
                        <asp:LinkButton runat="server" CommandName="Edit" Text="Ändra" CausesValidation="false"/>
                        <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick='<%# String.Format("return confirm(\"Vill du verkligen ta bort filmen?\")", Item.FilmID) %>'/>
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
                        
                        <asp:DropDownList ID="FilmrecensenternaDropDownList" runat="server"
                         ItemType="Filmrecensenterna.Model.BLL.Film"
                         SelectMethod="FilmDropDownList_GetData"
                         DataTextField="Filmnamn"
                         DataValueField="FilmID"
                         SelectedValue='<%# BindItem.FilmID %>'/>
                    </td>

                   <td>
                   </td>
                   <td>
                       <asp:TextBox ID="TextBox1" runat="server"
                           TextMode="MultiLine"
                           MaxLength="150"
                           Text='<%# BindItem.Recensionen %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="PersonDropDownList" runat="server"
                         ItemType="Filmrecensenterna.Model.BLL.Medlem"
                         SelectMethod="PersonDropDownList_GetData"
                         DataTextField="Namn"
                         DataValueField="MedlemID"
                         SelectedValue='<%# BindItem.MedlemID %>'/>
                    </td>
                    
                    <td>
                        <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till recension" CausesValidation="True"/>
                    </td>
               </tr>
           </InsertItemTemplate>
        <EditItemTemplate>
                    <tr>
                    <td>
                        <asp:DropDownList ID="FilmDropDownList" runat="server"
                         ItemType="Filmrecensenterna.Model.BLL.Film"
                         SelectMethod="FilmDropDownList_GetData"
                         DataTextField="Filmnamn"
                         DataValueField="FilmID" 
                         SelectedValue='<%# BindItem.FilmID %>'   />                         
                    </td>
                    <td>
                       
                   </td>
                   <td>
                       <asp:TextBox ID="TextBox1" runat="server"
                           TextMode="MultiLine"
                           MaxLength="150"
                           Text='<%# BindItem.Recensionen %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="PersonDropDownList" runat="server"
                         ItemType="Filmrecensenterna.Model.BLL.Medlem"
                         SelectMethod="PersonDropDownList_GetData"
                         DataTextField="Namn"
                         DataValueField="MedlemID"
                         SelectedValue='<%# BindItem.MedlemID %>' />
                    </td>
                    <td>
                       <asp:LinkButton runat="server" CommandName="Update" Text="Spara" CausesValidation="true"  ValidationGroup="editDate" />
                       <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false"/>
                   </td>
               </tr> 

           </EditItemTemplate>
        </asp:ListView>
</asp:Content>
