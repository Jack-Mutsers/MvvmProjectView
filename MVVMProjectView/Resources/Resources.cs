using System;
using System.Collections.Generic;
using System.ComponentModel;
using MVVMProjectView.Models;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

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


        private Models.Component _component { get; set; } = new Models.Component();
        public Models.Component component
        {
            get { return _component; }
            set { _component = value; OnPropertyChanged("component"); }
        }


        private string _newComponentHeader = "";
        public string newComponentHeader
        {
            get { return _newComponentHeader; }
            set { _newComponentHeader = value; OnPropertyChanged("newComponentHeader"); }
        }

        private string _updateCreateName = "";
        public string updateCreateName
        {
            get { return _updateCreateName; }
            set { _updateCreateName = value; OnPropertyChanged("updateCreateName"); }
        }

        private Visibility _deleteButtonVisibility = Visibility.Hidden;
        public Visibility deleteButtonVisibility
        {
            get { return _deleteButtonVisibility; }
            set { _deleteButtonVisibility = value; OnPropertyChanged("deleteButtonVisibility"); }
        }


        private Category _category = new Category();
        public Category category
        {
            get { return _category; }
            set { _category = value; OnPropertyChanged("category"); }
        }

        private string _newCategoryHeader = "";
        public string newCategoryHeader
        {
            get { return _newCategoryHeader; }
            set { _newCategoryHeader = value; OnPropertyChanged("newCategoryHeader"); }
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

        
        private byte[] _ByteImage;
        public byte[] ByteImage
        {
            get { return _ByteImage; }
            set
            {
                _ByteImage = value;
            }
        }


        public BitmapImage ConvertedImage
        {
            get { return category.icon; }
            set
            {
                category.icon = value;
                OnPropertyChanged("ConvertedImage");
                ByteImage = ImageToByte(ConvertedImage);
            }
        }


        public byte[] ImageToByte(BitmapImage image = null)
        {
            if (image == null) 
            { 
                return new byte[0]; 
            } 
            else
            {
                byte[] data;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                }

                //ByteImage = data;
                return data;
            }
        }

        public BitmapImage byteToImage(byte[] data)
        {
            MemoryStream strm = new MemoryStream();
            strm.Write(data, 0, data.Length);
            strm.Position = 0;

            System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();

            return bi;
        }

        public void ResetValues()
        {
            LoginMessage = "";
            NoteMessage = "";
            UpdateError = "";
            DeleteMessage = "";
            DeleteError = "";
            component = new Models.Component();
            NewCatMessage = "";
            NewCatError = "";
            NewCompError = "";
            NewCompMessage = "";
            NewUserError = "";
            NewUserMessage = "";
            ConvertedImage = null;
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
