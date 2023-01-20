using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using System.Windows.Shapes;

namespace Notepad.Models
{
    internal class DocumentModel : ObservableObject
    {
        private int _wordsCount;
        public int WordsCount
        {
            get { return _wordsCount; }
            set { OnPropertyChanged(ref _wordsCount, value); }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                OnPropertyChanged(ref _text, value);
                WordsCount = _text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
            }
        }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { OnPropertyChanged(ref _fileName, value); }
        }

        private string _filePath;
        public string FilePath 
        {
            get { return _filePath; }
            set { OnPropertyChanged(ref _filePath, value); }
        }

        public bool isEmpty()
        {
            return string.IsNullOrEmpty(_filePath) || string.IsNullOrEmpty(_fileName);
        }
    }
}
