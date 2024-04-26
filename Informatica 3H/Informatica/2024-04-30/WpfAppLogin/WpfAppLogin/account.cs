using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppLogin
{
    
        class account
        {
            private string name;
            private string surname;
            private string username;
            private string password;

            
            public account(string nome, string surname, string username, string password)
            {
                this.name = nome;
                this.surname = surname;
                this.username = username;
                this.password = password;
            }
            public string Name
            {
                get { return name; }
            }

            public string Surname
            {
                get { return surname; }
            }

            public string Username
            {
                get { return username; }
            }

            public string Password
            {
                get { return password; }
            }

        }
    
}
