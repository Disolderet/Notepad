using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notepad.Models
{
    internal class FormatModel : ObservableObject
    {
        private TextWrapping _wrap = TextWrapping.NoWrap;
        public TextWrapping Wrap
        {
            get { return _wrap; }
            set
            {
                OnPropertyChanged(ref _wrap, value);
                isWrapped = value == TextWrapping.Wrap ? true : false;
            }
        }
        private bool _isWrapped;
        public bool isWrapped
        {
            get { return _isWrapped; }
            set { OnPropertyChanged(ref _isWrapped, value); }
        }
        private double _size = 18;
        public double Size
        {
            get { return _size; }
            set { OnPropertyChanged(ref _size, value);}
        }

    }
}
