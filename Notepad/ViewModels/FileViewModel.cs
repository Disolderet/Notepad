using Microsoft.Win32;
using Notepad.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Notepad.ViewModels
{
    internal class FileViewModel
    {
        public DocumentModel Document { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public FileViewModel(DocumentModel Document)
        {
            this.Document = Document;
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveAsFile);
            OpenCommand = new RelayCommand(OpenFile);
            ExitCommand = new RelayCommand(Exit);
        }

        private void NewFile()
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
        }

        private void SaveFile()
        {   
            if (!Document.isEmpty())
            {
                File.WriteAllText(Document.FilePath, Document.Text);
            }
            else
            {
                SaveAsFile();
            }
        }

        private void SaveAsFile()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                File.WriteAllText(saveFileDialog.FileName, Document.Text);
            }
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }
    }
}
