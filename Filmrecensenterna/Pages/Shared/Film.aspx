<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Film.aspx.cs" Inherits="Filmrecensenterna.Pages.FilmView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
      <%-- PlaceHolder för rättmeddelande. --%>
               <asp:PlaceHolder ID="confirmholder" runat="server" Visible="false">
                   <asp:Label ID="confirmText" runat="server" Text="Label"></asp:Label>
               <asp:Button ID="closeButton" runat="server" Text="Stäng" CausesValidation="false" />
                </asp:PlaceHolder>

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
                   
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Du måste ange ett filmnamn" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                    <td>
                        
                        <asp:TextBox ID="TextBox1" runat="server"
                           TextMode="SingleLine"
                           MaxLength="30"
                           Text='<%# BindItem.Filmnamn %>'></asp:TextBox>
                    </td>

                   <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Endast årtal mellan 1900-2014 accepteras" MinimumValue="1900" MaximumValue="2014" ControlToValidate="TextBox2"></asp:RangeValidator><br />
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Du måste ange ett årtal" ControlToValidate="TextBox2"></asp:RequiredFieldValidator><br />
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

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Du måste ange ett filmnamn" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"
                           TextMode="SingleLine"
                           MaxLength="30"
                           Text='<%# BindItem.Filmnamn %>'></asp:TextBox>                        
                    </td>

                         <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Endast årtal mellan 1900-2014 accepteras" MinimumValue="1900" MaximumValue="2014" ControlToValidate="TextBox2"></asp:RangeValidator>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Du måste ange ett årtal" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
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
