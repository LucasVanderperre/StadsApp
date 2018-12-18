using NL4_Vanderperre_Lucas_Laureyns_Piet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NL4_Vanderperre_Lucas_Laureyns_Piet.Controllers
{
    public class LoginController
    {
        private string resourceName = "My App";

        public async Task LoginBackend(Gebruiker gebruiker)
        {
            HttpClient client = new HttpClient();
            var response = await client.PutAsJsonAsync("http://localhost:51155/api/Gebruikers/login", gebruiker);
             response.EnsureSuccessStatusCode();

        }


        public async Task Login(Gebruiker gebruiker)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();

            // check hier de inloggegevens
            try
            {
                vault.Retrieve(resourceName, gebruiker.username);

                //get via webAPI
            }
            catch (Exception)
            {
                try
                {
                    try
                    {
                        await LoginBackend(gebruiker);
                        vault.Add(new Windows.Security.Credentials.PasswordCredential(
                            "My App", gebruiker.username, gebruiker.password));
                    }
                    catch (Exception)
                    {
                        throw new Exception("De username of passwoord is niet correct");
                    }
                    
                }
                catch (Exception)
                {
                    throw new Exception("De username of passwoord is niet correct");
                }
               
                //check via restapi passwoord
                //Als oke login anders exception throw
                
            }

            GebruikerController gebruikerController = new GebruikerController();
            bool isKlant = await gebruikerController.GetGebruikerIsKlant(gebruiker.username);
  
            User.Username = gebruiker.username;
            User.isKlant = isKlant;
            User.isOndernemer = !isKlant;
            User.Id = gebruiker.GebruikerId;
        }

        public void LoginNieuweGebruiker(Gebruiker gebruiker, string password)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            vault.Add(new Windows.Security.Credentials.PasswordCredential(
                "My App", gebruiker.username, password));
            User.Username = gebruiker.username;
            User.isKlant = (gebruiker.GetType() == typeof(Klant));
            User.isOndernemer = (gebruiker.GetType() == typeof(Ondernemer));
            User.Id = gebruiker.GebruikerId;
        }


        public void LogOut()
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            var credentials = vault.Retrieve(resourceName, User.Username);
            credentials.RetrievePassword();
            vault.Remove(new Windows.Security.Credentials.PasswordCredential(
                resourceName, User.Username, credentials.Password));
            User.Username = "";
            User.isKlant = null;
            User.Id = -1;
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
