<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="3ValiderUtilisateurUserControl.ascx.cs" Inherits="_3ValiderUtilisateur.VisualWebPart1.VisualWebPart1UserControl" %>
        <style type="text/css">
            .style1
            {
                width: 211px;
            }
            .style2
            {
                width: 366px;
            }
            </style>

        <asp:Image ID="Image1" runat="server" AlternateText="Fiche Nouvel Arrivant" ImageUrl="~/_layouts/images/3ValiderUtilisateur/_nouvelarrivantentete.jpg" />

        <table style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: solid" >
            <tr>
                <td style="width: 150px">
                    Nom bénéficiaire :</td>
                <td class="style1">
                <asp:Label ID="lblNom" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Prénom bénéficiaire :</td>
                <td class="style1">
                <asp:Label ID="lblPrenom" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Login :</td>
                <td class="style1">
                <asp:Label ID="lblLogin" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Date d&#39;entrée :</td>
                <td class="style1">
                <asp:Label ID="lblDateEntrée" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Date de sortie :</td>
                <td class="style1">
                <asp:Label ID="lblDateSortie" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Statut :</td>
                <td class="style1">
                <asp:Label ID="lblStatut" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Fonction :</td>
                <td class="style1">
                <asp:Label ID="lblFonction" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Service :</td>
                <td class="style1">
                <asp:Label ID="lblService" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Lieu de travail :</td>
                <td class="style1">
                <asp:Label ID="lblLieu" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    N° bureau :</td>
                <td class="style1">
                <asp:Label ID="lblBureau" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Remplacement :</td>
                <td class="style1">
                <asp:Label ID="lblRemplacement" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    <asp:Label ID="lbltxtRemp" runat="server" Text="Agents remplacé :" Visible="False"></asp:Label>
                    </td>
                <td class="style1">
                <asp:Label ID="lblAgentRemp" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Téléphone fixe :</td>
                <td class="style1">
                <asp:Label ID="lblTelFixe" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Téléphone Portable :</td>
                <td class="style1">
                <asp:Label ID="lblTelPort" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    <asp:Label ID="lbltxtTel" runat="server" Text="Justification Téléphone Portable :" Visible="False"></asp:Label></td>
                <td class="style1">
                <asp:Label ID="lblJustifTel" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Jour d&#39;utilisation :</td>
                <td class="style1">
                <asp:Label ID="lblJourUtilisation" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Portée d&#39;utilisation :</td>
                <td class="style1">
                <asp:Label ID="lblPorteeUtilisation" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Poste de travail :</td>
                <td class="style1">
                <asp:Label ID="lblPosteTravail" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    <asp:Label ID="lbltxtPoste" runat="server" 
                        Text="Justification du poste de travail :" Visible="False"></asp:Label></td>
                <td class="style1">
                <asp:Label ID="lblJustifPoste" runat="server" Text="Label" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Accés Internet :</td>
                <td class="style1">
                <asp:Label ID="lblInternet" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Accés Mail :</td>
                <td class="style1">
                <asp:Label ID="lblMail" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Accés à Post-Office :</td>
                <td class="style1">
                <asp:Label ID="lblPostOffice" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Accés à Actes-Office :</td>
                <td class="style1">
                <asp:Label ID="lblActesOffice" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Accés au logiciel de finance :</td>
                <td class="style1">
                <asp:Label ID="lblFinance" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Accés à la saisie d&#39;information DRH :</td>
                <td class="style1">
                <asp:Label ID="lblDRH" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Besoins spécifiques :</td>
                <td class="style1">
                <asp:Label ID="lblBesoins" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Demandeur :</td>
                <td class="style1">
                <asp:Label ID="lblDemandeur" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Focntion du demandeur :</td>
                <td class="style1">
                <asp:Label ID="lblFonctionDem" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Service du demandeur :</td>
                <td class="style1">
                <asp:Label ID="lblServiceDem" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                    Date de la demande :</td>
                <td class="style1">
                <asp:Label ID="lblDateDem" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="pnlRH" runat="server" Visible="False">
            <table style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: solid" >
                <tr>
                    <td class="style2">
                    Veuillez entrer un numero de matricule :
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:TextBox ID="txtMatricule" runat="server" class="style2"></asp:TextBox>
                        <asp:Label ID="lblVerifMatricule" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>
        <asp:Button ID="btAccepter" runat="server" Text="Accepter la demande" 
            Width="170px" onclick="btAccepter_Click" />
        <asp:Button ID="btRefuser" runat="server" Text="Rejeter la demande" 
            Width="170px" onclick="btRefuser_Click" />


<p>
    &nbsp;</p>
<p>
    version 1.0.2</p>



