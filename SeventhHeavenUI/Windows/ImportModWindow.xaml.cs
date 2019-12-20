﻿using Iros._7th.Workshop;
using SeventhHeaven.Classes;
using SeventhHeaven.ViewModels;
using SeventhHeavenUI;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SeventhHeaven.Windows
{
    /// <summary>
    /// Interaction logic for ImportModWindow.xaml
    /// </summary>
    public partial class ImportModWindow : Window
    {
        ImportModViewModel ViewModel { get; set; }

        public ImportModWindow()
        {
            InitializeComponent();

            ViewModel = new ImportModViewModel();
            this.DataContext = ViewModel;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            Task<bool> t = ViewModel.ImportModFromWindowAsync();

            t.ContinueWith((taskResult) =>
            {
                if (taskResult.IsFaulted)
                {
                    Sys.Message(new WMessage($"Failed to import - {taskResult.Exception.GetBaseException()?.Message}", true));
                    return;
                }

                // close window on succesful import
                if (taskResult.Result)
                {
                    CloseWindow();
                }

            });
        }

        private void CloseWindow()
        {
            App.Current.Dispatcher.Invoke(() => 
            { 
                this.Close();
            });
        }

        private void btnBrowseIro_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile = FileDialogHelper.BrowseForFile("iro archive (*.iro)|*.iro", "Select .iro Archive File");

            if (!string.IsNullOrEmpty(selectedFile))
            {
                ViewModel.PathToIroArchiveInput = selectedFile;
                ViewModel.ModNameInput = Path.GetFileNameWithoutExtension(selectedFile);
            }
        }

        private void btnBrowseModFolder_Click(object sender, RoutedEventArgs e)
        {
            string selectedFolder = FileDialogHelper.BrowseForFolder();

            if (!string.IsNullOrEmpty(selectedFolder))
            {
                ViewModel.PathToModFolderInput = selectedFolder;
                ViewModel.ModNameInput = Path.GetFileName(selectedFolder);
            }
        }

        private void btnBrowseBatchFolder_Click(object sender, RoutedEventArgs e)
        {
            string selectedFolder = FileDialogHelper.BrowseForFolder();

            if (!string.IsNullOrEmpty(selectedFolder))
            {
                ViewModel.PathToBatchFolderInput = selectedFolder;
            }
        }

    }
}
