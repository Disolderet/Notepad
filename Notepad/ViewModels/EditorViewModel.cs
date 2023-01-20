using Notepad.Models;
using System.Windows.Input;

namespace Notepad.ViewModels
{

    internal class EditorViewModel 
    {

        public DocumentModel Document { get; set; }
        public FormatModel Format { get; set; }
        public ICommand WrapCommand { get; set; }
        public ICommand SizeCommand { get; set; } 

        public EditorViewModel(DocumentModel Document)
        {
            this.Document = Document;
            Format = new();
            SizeCommand = new RelayCommand(ChangeSize);
            WrapCommand = new RelayCommand(ToggleWrap);
        }

        private void ToggleWrap()
        {
            if (Format.Wrap == System.Windows.TextWrapping.Wrap)
                Format.Wrap = System.Windows.TextWrapping.NoWrap;
            else
                Format.Wrap = System.Windows.TextWrapping.Wrap;
        }

        private void ChangeSize()
        {
            // дописать
        }
        
    }
}
