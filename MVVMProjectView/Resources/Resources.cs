using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMProjectView.Resources
{
    public class Resources : INotifyPropertyChanged
    {
        private string _LoginMessage = "";
        public string LoginMessage
        {
            get { return _LoginMessage; }
            set { _LoginMessage = value; OnPropertyChanged("LoginMessage"); }
        }

        private string _NoteMessage = "";
        public string NoteMessage
        {
            get { return _NoteMessage; }
            set { _NoteMessage = value; OnPropertyChanged("NoteMessage"); }
        }

        private bool _LoggedIn = false;
        public bool LoggedIn { 
            get { return _LoggedIn; }
            set { _LoggedIn = value; OnPropertyChanged("LoggedIn"); } 
        }


        private string _UpdateMessage = "";
        public string UpdateMessage
        { 
            get { return _UpdateMessage; }
            set { _UpdateMessage = value; OnPropertyChanged("UpdateMessage"); } 
        }


        private string _UpdateError = "";
        public string UpdateError
        { 
            get { return _UpdateError; }
            set { _UpdateError = value; OnPropertyChanged("UpdateError"); } 
        }


        private string _DeleteMessage = "";
        public string DeleteMessage
        { 
            get { return _DeleteMessage; }
            set { _DeleteMessage = value; OnPropertyChanged("DeleteMessage"); } 
        }


        private string _DeleteError = "";
        public string DeleteError
        { 
            get { return _DeleteError; }
            set { _DeleteError = value; OnPropertyChanged("DeleteError"); }
        }


        private string _CategoryName = "";
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; OnPropertyChanged("CategoryName"); }
        }


        private string _ComponentName = "";
        public string ComponentName
        {
            get { return _ComponentName; }
            set { _ComponentName = value; OnPropertyChanged("ComponentName"); }
        }


        private string _NewCatMessage = "";
        public string NewCatMessage
        {
            get { return _NewCatMessage; }
            set { _NewCatMessage = value; OnPropertyChanged("NewCatMessage"); }
        }


        private string _NewCatError = "";
        public string NewCatError
        {
            get { return _NewCatError; }
            set { _NewCatError = value; OnPropertyChanged("NewCatError"); }
        }


        private string _NewCompError = "";
        public string NewCompError
        {
            get { return _NewCompError; }
            set { _NewCompError = value; OnPropertyChanged("NewCompError"); }
        }


        private string _NewCompMessage = "";
        public string NewCompMessage
        {
            get { return _NewCompMessage; }
            set { _NewCompMessage = value; OnPropertyChanged("NewCompMessage"); }
        }


        private string _NewUserError = "";
        public string NewUserError
        {
            get { return _NewUserError; }
            set { _NewUserError = value; OnPropertyChanged("NewUserError"); }
        }


        private string _NewUserMessage = "";
        public string NewUserMessage
        {
            get { return _NewUserMessage; }
            set { _NewUserMessage = value; OnPropertyChanged("NewUserMessage"); }
        }


        public void ResetValues()
        {
            LoginMessage = "";
            NoteMessage = "";
            UpdateError = "";
            DeleteMessage = "";
            DeleteError = "";
            CategoryName = "";
            ComponentName = "";
            NewCatMessage = "";
            NewCatError = "";
            NewCompError = "";
            NewCompMessage = "";
            NewUserError = "";
            NewUserMessage = "";
        }

        //below is the boilerplate code supporting PropertyChanged events:
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
