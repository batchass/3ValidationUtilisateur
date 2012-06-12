using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.WebPartPages.Communication;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Utilities;


namespace _3ValiderUtilisateur.VisualWebPart1
{

    public partial class VisualWebPart1UserControl : UserControl
    {

        SPContext spCtx = SPContext.Current;
        //varibale de recuperation de l'utilisateur actuel
        string[] stringSep = new string[] { "\\" };
        string[] result;
        SPWeb currentWeb = SPContext.Current.Web;
        //variable de recuperation des information pour la requete CAML
        string login = "";
        string caml;
        // variable de recuperation de l'url du serveur
        string url;
        // variable de stockage de l'objet Demande
        SPListItem Demande;
        // variables d'identification de l'etat de la demande et de l'utilisateur du formulaire
        string etatDemande = "inconnu";
        string code = "";
        //string user = "";
        // variable de recuperation du matricule lors de validation RH
        string matricule;
        // variable de validation de la page
        bool pageValidate;

        protected void Page_Load(object sender, EventArgs e)
        {
            // recuperation de l'url du serveur
            url = SPContext.Current.Web.Url;
            // recuperation des parametre de l'url
            //user = Request.QueryString["resu"];
            login = Request.QueryString["nigol"];
            code = Request.QueryString["edoc"];

            verifParam(code);
        }

        //========================================================= verifParam() ================================================================
        public void verifParam(string code)
        {
            try
            {
                // si l'utilisateur est du SIT ou utilisateur est des RH
                if (code == "102030")
                {
                    // requete recuperation de la demande
                    caml = "<Where><Eq><FieldRef Name=\"Login\" /><Value Type=\"Text\">" + login + "</Value></Eq></Where>";
                    InitPage();
                    if ( etatDemande != "Etape2" )
                    {
                        Response.Redirect(url + "/SitePages/Nouvel arrivant.aspx");
                    }
                }
                else if (code == "112131")
                {
                    // requete recuperation de la demande
                    caml = "<Where><Eq><FieldRef Name=\"Login\" /><Value Type=\"Text\">" + login + "</Value></Eq></Where>";
                    InitPage();
                    if ( etatDemande != "Etape3" )
                    {
                        Response.Redirect(url + "/SitePages/Nouvel arrivant.aspx");
                    }
                }
                // sinon l'utilisateur est redirigé vers la page d'accueil
                else
                {
                    Response.Redirect(url + "/SitePages/Nouvel arrivant.aspx");
                }
            }
            catch
            {
                Response.Redirect(url + "/SitePages/Nouvel arrivant.aspx?v=1.0.3&url=" + url + "&etatDemande=" + etatDemande + "&login=" + login + "&caml" + caml);
            }
            
        }

        //========================================================== InitPage() ================================================================
        public void InitPage()
        {
            // recuperation de la demande
            SPList list = spCtx.Web.Lists["Demande Nouvel Arrivant"];
            SPQuery myquery = new SPQuery();
            myquery.Query = caml;
            SPListItemCollection items = list.GetItems(myquery);
            String valeurNulle = "";

            foreach (SPListItem item in items)
            {
                Demande = item;
            }
            // recuperation de l'etat de la demande
            etatDemande = Demande["Titre"].ToString();

            //==============================================================================)
            if (etatDemande == "Validé")
            {
                Response.Redirect(url + "/SitePages/Utilisateur_Valide.aspx");
            }
            else if (etatDemande == "Rejeté (Service Informatique)" || etatDemande == "Rejeté (DRH)")
            {
                Response.Redirect(url + "/SitePages/Utilisateur_Rejet.aspx");
            }

            //==============================================================================
            // recuperation information dans les labels
            // si pas de besoin spécifier
            try
            {
                lblBesoins.Text = Demande["Besoins spécifiques"].ToString();
            }
            catch
            {
                lblBesoins.Text = "Pas de besoins specifique renseignés";
            } 
            try
            {
                valeurNulle = "Nom bénéficiaire";
                lblNom.Text = Demande["Nom bénéficiaire"].ToString();

                valeurNulle = "Prénom bénéficiaire";
                lblPrenom.Text = Demande["Prénom bénéficiaire"].ToString();

                valeurNulle = "Login";
                lblLogin.Text = Demande["Login"].ToString();

                valeurNulle = "date d'entrée";
                lblDateEntrée.Text = Demande["date d'entrée"].ToString();

                valeurNulle = "date de sortie";
                lblDateSortie.Text = Demande["date de sortie"].ToString();

                valeurNulle = "Statut";
                lblStatut.Text = Demande["Statut"].ToString();

                valeurNulle = "Fonction";
                lblFonction.Text = Demande["Fonction"].ToString();

                valeurNulle = "Lieu de travail";
                lblLieu.Text = Demande["Lieu de travail"].ToString();

                valeurNulle = "N° bureau";
                lblBureau.Text = Demande["N° bureau"].ToString();

                valeurNulle = "Remplacement";
                lblRemplacement.Text = Demande["Remplacement"].ToString();

                valeurNulle = "Téléphone fixe";
                lblTelFixe.Text = Demande["Téléphone fixe"].ToString();

                valeurNulle = "lblTelPort";
                lblTelPort.Text = Demande["Téléphone portable"].ToString();

                valeurNulle = "lblJourUtilisation";
                lblJourUtilisation.Text = Demande["Jour d'utilisation"].ToString();

                valeurNulle = "lblPorteeUtilisation";
                lblPorteeUtilisation.Text = Demande["Portée d'utilisation"].ToString();

                valeurNulle = "lblPosteTravail";
                lblPosteTravail.Text = Demande["Poste de travail"].ToString();

                valeurNulle = "lblInternet";
                lblInternet.Text = Demande["Accés Internet"].ToString();

                valeurNulle = "lblMail";
                lblMail.Text = Demande["Accés Mail"].ToString();

                valeurNulle = "lblPostOffice";
                lblPostOffice.Text = Demande["Accés à Post-Office"].ToString();

                valeurNulle = "lblActesOffice";
                lblActesOffice.Text = Demande["Accés à Actes-Office"].ToString();

                valeurNulle = "lblFinance";
                lblFinance.Text = Demande["Accés au logiciel Finance"].ToString();

                valeurNulle = "lblDRH";
                lblDRH.Text = Demande["Accés à la saisie information DRH"].ToString();

                valeurNulle = "lblService";
                lblService.Text = Demande["Service"].ToString();

                valeurNulle = "lblDemandeur";
                lblDemandeur.Text = Demande["Demandeur"].ToString();

                valeurNulle = "lblFonctionDem";
                lblFonctionDem.Text = Demande["Fonction du demandeur"].ToString();

                valeurNulle = "lblServiceDem";
                lblServiceDem.Text = Demande["Service du demandeur"].ToString();

                valeurNulle = "lblDateDem";
                lblDateDem.Text = Demande["Date_demande"].ToString();
            }
            catch
            {
                lblBesoins.Text = "valeurNulle: " + valeurNulle;
            }

 
            //================================================================================================================
            // si remplacement on recupere la justification et on l'affiche
            if (lblRemplacement.Text == "oui")
            {
                try
                {
                    lblAgentRemp.Text = Demande["Agent Remplacé"].ToString();
                }
                catch
                {
                    lblAgentRemp.Text = "Pas de justification";
                }

                lbltxtRemp.Visible = true;
                lblAgentRemp.Visible = true;
            }

            //================================================================================================================
            // si telephone portbale on recupere la justification et on l'affiche
            if (lblTelPort.Text == "oui")
            {
                try
                {
                    lblJustifTel.Text = Demande["Justification téléphone portable"].ToString();
                }
                catch
                {
                    lblJustifTel.Text = "Pas de justification";
                }

                lbltxtTel.Visible = true;
                lblJustifTel.Visible = true;
            }

            //================================================================================================================
            //si poste speciale on recupere la justification et on l'affiche
            if (lblPosteTravail.Text == "Ordinateur Portable")
            {
                try
                {
                    lblJustifPoste.Text = Demande["Justification du poste de travail"].ToString();
                }
                catch
                {
                    lblJustifPoste.Text = "Pas de justification";
                }
                lbltxtPoste.Visible = true;
                lblJustifPoste.Visible = true;
            }

            if (lblPosteTravail.Text == "Station Graphique")
            {
                try
                {
                    lblJustifPoste.Text = Demande["Justification du poste de travail"].ToString();
                }
                catch
                {
                    lblJustifPoste.Text = "Pas de justification";
                }
                lbltxtPoste.Visible = true;
                lblJustifPoste.Visible = true;
            }

            // permet l'affichage d'une fenetre de confirmation
            //btRefuser.Attributes.Add("onclick", "javascript: return confirm('Etes-vous sûr de vouloir rejeter la demande ?');");
            //btAccepter.Attributes.Add("onclick", "javascript: return confirm('Etes-vous sûr de Valider la demande ?');");

            if (code == "112131")
            {
                // champs de saisie matricule visible
                pnlRH.Visible = true;
            }

        }

        //======================================================= verifParam(string user) ====================================================================
        public void verifParam(string user,int i)
        {
            string currentUser;
            // recuperation de l'utilisateur actuel
            result = currentWeb.CurrentUser.LoginName.Split(stringSep, StringSplitOptions.None);
            currentUser = result[1];

            if (user == currentUser)
            {
                // requete recuperation de la demande
                caml = "<Where><Eq><FieldRef Name=\"Login\" /><Value Type=\"Text\">" + login + "</Value></Eq></Where>";
                InitPage();
            }
            else
            {
                Response.Redirect(url + "/SitePages/Accueil.aspx");
            }
        }

        //====================================================================== event ========================================================================

        //=================================================================================================
        //====================== Clique sur bouton Accepter ===============================================
        //=================================================================================================
        protected void btAccepter_Click(object sender, EventArgs e)
        {
            // si la demande est à l'etape2 et que l'utilisateur est du SIT
            if (etatDemande == "Etape2" && code == "102030")
            {
                Demande["Titre"] = "Etape3";
                Demande.Update();
                Response.Redirect(url + "/SitePages/Utilisateur_Valide.aspx");
            }
            // sinon si la demande est a l'etape3 et que l'utilisateur est des RH
            else if (etatDemande == "Etape3" && code == "112131")
            {
                matricule = txtMatricule.Text;
                // si le matricule n'est pas renseigné
                if (matricule == null || matricule == "" )
                {
                    pageValidate = false;
                    lblVerifMatricule.Text = "* Veuillez saisir un numéro de matricule ou 0 si compte générique";

                }
                // sinon
                else 
                {
                    // controle de saisie si matricule est un matricule
                    try // oui
                    {
                        int.Parse(matricule); 
                        pageValidate = true;
                    }
                    catch // non
                    {
                        pageValidate = false;
                        lblVerifMatricule.Text = "* Veuillez saisir un numéro de matricule valide ou 0 si compte générique";
                    }
                }
                // si la page est valide
                if (pageValidate == true)
                {
                    Demande["Titre"] = "Validé";
                    Demande["Matricule"] = matricule;
                    Demande.Update();
                    Response.Redirect(url + "/SitePages/Utilisateur_Valide.aspx");
                }
            }
        }

        //=================================================================================================
        //====================== Clique sur bouton refuser ================================================
        //=================================================================================================
        protected void btRefuser_Click(object sender, EventArgs e)
        {
            if (etatDemande == "Etape2" && code == "102030")
            {
                Demande["Titre"] = "Rejeté (Service Informatique)";
                Demande.Update();
                Response.Redirect(url + "/SitePages/Utilisateur_Rejet.aspx");
            }
            else if (etatDemande == "Etape3" && code == "112131")
            {
                Demande["Titre"] = "Rejeté (DRH)";
                Demande.Update();
                Response.Redirect(url + "/SitePages/Utilisateur_Rejet.aspx");
            }
        }
    }
}