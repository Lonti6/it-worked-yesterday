using System;

namespace DefaultNamespace
{
    [Serializable]
    public class Note
    {
        public string login = "";
        public string message = "";
        public string time = "";
        public string doctor = "";

        public Note(string login, string message, string time, string doctor)
        {
            this.login = login;
            this.message = message;
            this.time = time;
            this.doctor = doctor;
        }

        public Note()
        {
        }
    }
}