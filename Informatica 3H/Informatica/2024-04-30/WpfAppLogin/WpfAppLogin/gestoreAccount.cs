using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WpfAppLogin
{
    internal class gestoreAccount
    {
        private string path = "../../../../accounts.txt";
        private Dictionary<string, account> accounts = new Dictionary<string, account>(); 

        public gestoreAccount()
        {
            
            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var lines = sr.ReadLine().Split('#');
                    accounts.Add(lines[2], new account(lines[0], lines[1], lines[2], lines[3]));
                }
            }

               
        }

        public bool Login(string username, string password)
        {
            
            if (accounts.ContainsKey(username))
            {
                if (accounts[username].Password == Encrypt(password))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Register(string name, string surname, string username, string password)
        {
            
            if (!accounts.ContainsKey(username))
            {
                
                accounts.Add(username, new account(name, surname, username, Encrypt(password)));
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    
                    sw.WriteLine($"{name}#{surname}#{username}#{Encrypt(password)}");
                }
                return true;
            }

            return false;
        }


        private string Encrypt(string password)
        {
            using (SHA256 SHA256 = SHA256.Create())
            {
                byte[] hashValue = SHA256.HashData(Encoding.UTF8.GetBytes(password));
                return Convert.ToHexString(hashValue);
            }
        }
    }
}

