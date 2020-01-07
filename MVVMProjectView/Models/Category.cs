﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MVVMProjectView.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public BitmapImage icon { get; set; }


        public IEnumerable<Component> Components { get; set; }
    }
}
