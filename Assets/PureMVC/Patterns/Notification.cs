namespace PureMVC.Patterns
{
    using PureMVC.Interfaces;
    using System;

    public class Notification : INotification
    {
        private object m_body;
        private string m_name;
        private string m_type;

        public Notification(string name) : this(name, null, null)
        {
        }

        public Notification(string name, object body) : this(name, body, null)
        {
        }

        public Notification(string name, object body, string type)
        {
            this.m_name = name;
            this.m_body = body;
            this.m_type = type;
        }

        public override string ToString()
        {
            return ((("Notification Name: " + this.Name) + "\nBody:" + ((this.Body == null) ? "null" : this.Body.ToString())) + "\nType:" + ((this.Type == null) ? "null" : this.Type));
        }

        public object Body
        {
            get
            {
                return this.m_body;
            }
            set
            {
                this.m_body = value;
            }
        }

        public string Name
        {
            get
            {
                return this.m_name;
            }
        }

        public string Type
        {
            get
            {
                return this.m_type;
            }
            set
            {
                this.m_type = value;
            }
        }
    }
}

