using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers
{
    public class LoginController
    {
        private string resourceName = "My App";


        public void Login(Gebruiker gebruiker, string password)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            // check hier de inloggegevens
            try
            {
                vault.Retrieve(resourceName, gebruiker.username);
                //get via webAPI
            }
            catch (Exception ex)
            {
                //check via restapi passwoord
                //Als oke login anders exception throw
                throw new Exception("De username of passwoord is niet correct");
            }
            User.Username = gebruiker.username;
            User.isKlant =  (gebruiker.GetType() == typeof(Klant)) ;

        }



        public void LoginNieuweGebruiker(string gebruiker, string password)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            vault.Add(new Windows.Security.Credentials.PasswordCredential(
                "My App", gebruiker, password));
            User.Username = gebruiker;
        }


        public void LogOut(Gebruiker gebruiker)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            var credentials = vault.Retrieve(resourceName, gebruiker.username);
            credentials.RetrievePassword();
            vault.Remove(new Windows.Security.Credentials.PasswordCredential(
                resourceName, gebruiker.username, credentials.Password));
            User.Username = "";
        }

        /*
        private Windows.Security.Credentials.PasswordCredential GetCredentialFromLocker(string username)
        {
            Windows.Security.Credentials.PasswordCredential credential = null;

            var vault = new Windows.Security.Credentials.PasswordVault();
            var credentialList = vault.FindAllByResource(resourceName);
            if (credentialList.Count > 0)
            {
                if (credentialList.Count == 1)
                {
                    credential = credentialList[0];
                }
                else
                {
                    // When there are multiple usernames,
                    // retrieve the default username. If one doesn't
                    // exist, then display UI to have the user select
                    // a default username.

                   // defaultUserName = GetDefaultUserNameUI();

                    credential = vault.Retrieve(resourceName, username);
                }
            }

            return credential;
        }*/
    }
}
