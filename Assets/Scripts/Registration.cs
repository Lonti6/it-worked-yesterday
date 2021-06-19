using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class Registration 
    {
        public string login = "";
        public string pass = "";
        public string firstName = "";

        public Registration(string login, string pass, string firstName)
        {
            this.login = login;
            this.pass = pass;
            this.firstName = firstName;
        }

        public Registration()
        {
        }
    }
}