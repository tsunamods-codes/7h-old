﻿using SeventhHeavenUI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace SeventhHeaven.UserControls
{
    /// <summary>
    /// Interaction logic for MyModsUserControl.xaml
    /// </summary>
    public partial class MyModsUserControl : UserControl
    {
        public MyModsViewModel ViewModel { get; set; }

        public MyModsUserControl()
        {
            InitializeComponent();
        }

        public void SetDataContext(MyModsViewModel viewModel)
        {
            ViewModel = viewModel;
            this.DataContext = ViewModel;
        }

        /// <summary>
        /// Returns true if a mod is selected in the list.
        /// Returns false and shows messagebox warning user that no mod is selected otherwise;
        /// </summary>
        private bool IsModSelected()
        {
            if (lstMods.SelectedItem == null)
            {
                MessageBox.Show("Select a mod first.", "No Mod Selected", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns true if the selected mod is active.
        /// Returns false and shows messagebox warning user that selected mod is not active otherwise;
        /// </summary>
        private bool IsActiveModSelected(string notActiveMessage, string notActiveTitle)
        {
            if (lstMods.SelectedItem == null)
            {
                return false;
            }

            if (!(lstMods.SelectedItem as InstalledModViewModel).IsActive)
            {
                MessageBox.Show(notActiveMessage, notActiveTitle, MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        private void lstMods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.RaiseSelectedModChanged(sender, (lstMods.SelectedItem as InstalledModViewModel));
        }

        private void btnRefresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.ReloadModList(ViewModel.GetSelectedMod()?.InstallInfo.ModID);
        }

        private void btnDeactivateAll_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.DeactivateAllActiveMods();
        }

        private void btnUninstall_Click(object sender, RoutedEventArgs e)
        {
            if (!IsModSelected())
            {
                return;
            }

            InstalledModViewModel selected = (lstMods.SelectedItem as InstalledModViewModel);

            if (MessageBox.Show($"Are you sure you want to delete {selected.Name}?", "Uninstall Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                ViewModel.UninstallMod(selected);
            }

        }

        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            if (!IsModSelected())
            {
                return;
            }

            if (!IsActiveModSelected("Mod is not active. Only activated mods can be re-ordered.", "Cannot Move Inactive Mod"))
            {
                return;
            }

            ViewModel.ReorderProfileItem((lstMods.SelectedItem as InstalledModViewModel), -1);
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            if (!IsModSelected())
            {
                return;
            }

            if (!IsActiveModSelected("Mod is not active. Only activated mods can be re-ordered.", "Cannot Move Inactive Mod"))
            {
                return;
            }

            ViewModel.ReorderProfileItem((lstMods.SelectedItem as InstalledModViewModel), 1);
        }

        private void btnMoveTop_Click(object sender, RoutedEventArgs e)
        {
            if (!IsModSelected())
            {
                return;
            }

            if (!IsActiveModSelected("Mod is not active. Only activated mods can be re-ordered.", "Cannot Move Inactive Mod"))
            {
                return;
            }

            ViewModel.SendModToTop((lstMods.SelectedItem as InstalledModViewModel));
        }

        private void btnSendBottom_Click(object sender, RoutedEventArgs e)
        {
            if (!IsModSelected())
            {
                return;
            }

            if (!IsActiveModSelected("Mod is not active. Only activated mods can be re-ordered.", "Cannot Move Inactive Mod"))
            {
                return;
            }

            ViewModel.SendModToBottom((lstMods.SelectedItem as InstalledModViewModel));
        }

        private void btnActivateAll_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ActivateAllMods();
        }

        private void btnConfigure_Click(object sender, RoutedEventArgs e)
        {
            if (!IsModSelected())
            {
                return;
            }

            if (!IsActiveModSelected("Mod is not active. Only activated mods can be configured.", "Cannot Configure Inactive Mod"))
            {
                return;
            }

            ViewModel.ShowConfigureModWindow((lstMods.SelectedItem as InstalledModViewModel));
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ShowImportModWindow();
        }
    }
}
