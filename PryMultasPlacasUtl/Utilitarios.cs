using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography;
using System.Web.Security;
using System.IO;
using System.DirectoryServices;
using System.Web.Configuration;
using System.Configuration;

namespace PryMultasPlacasUtl
{
    public class Utilitarios
    {
        public static string getCadenaConexion(string conex)
        {
            System.Configuration.Configuration rootWebConfig;
            rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            System.Configuration.ConnectionStringSettings connString;
            if ((rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0))
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings[conex];
                if (!(connString.ConnectionString == null))
                {
                    return connString.ConnectionString;
                }
                else
                {
                    return "-2";
                }
            }

            return "-3";
        }

        public static string encriptaSha1(string usuario)
        {
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            byte[] cadenaByte;
            cadenaByte = System.Text.Encoding.ASCII.GetBytes(usuario);
            cadenaByte = sha.ComputeHash(cadenaByte);
            string rpta = "";
            foreach (byte b in cadenaByte)
            {
                rpta += b.ToString("x2");
            }

            return rpta;
        }

        //public static bool DemoLoginAD(string username, string pwd)
        //{
        //    string astrPathAD = "";
        //    string domain = "DOMBIF";
        //    string domainAndUsername = domain + "\\" + username;
        //    System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(astrPathAD, domainAndUsername, pwd);
        //    bool Bool = false;
        //    int codError = 0;
        //    Impersonation.Impersonation i = new Impersonation.Impersonation();
        //    int LogonTypes = 2;
        //    int LogonProviders = 0;
        //    codError = i.ValidarUsuarioAD(username, domain, pwd, LogonTypes, LogonProviders);
        //    int astrCodigoErrorAD = codError;
        //    if ((codError == 0))
        //    {
        //        try
        //        {
        //            System.DirectoryServices.DirectorySearcher search = new System.DirectoryServices.DirectorySearcher(entry);
        //            search.Filter = "(SAMAccountName=" + username + ")";
        //            search.PropertiesToLoad.Add("cn");
        //            System.DirectoryServices.SearchResult result = search.FindOne();
        //            if ((result == null))
        //            {
        //                Bool = false;
        //            }

        //            astrPathAD = result.Path;
        //            Bool = true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.Write(ex.Message);
        //        }
        //    }

        //    return Bool;
        //}

    }
}
