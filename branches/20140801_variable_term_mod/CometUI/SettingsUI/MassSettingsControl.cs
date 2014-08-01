﻿using System.Globalization;
using System.Windows.Forms;
using CometUI.Properties;

namespace CometUI.SettingsUI
{
    public partial class MassSettingsControl : UserControl
    {
        private new SearchSettingsDlg Parent { get; set; }
     
        public MassSettingsControl(SearchSettingsDlg parent)
        {
            InitializeComponent();

            Parent = parent;

            InitializeFromDefaultSettings();
        }

        public bool VerifyAndUpdateSettings()
        {
            // Verify and save the precursor mass settings
            var precursorMassTol = (double) precursorMassTolTextBox.DecimalValue;
            if (!Settings.Default.PrecursorMassTolerance.Equals(precursorMassTol))
            {
                Settings.Default.PrecursorMassTolerance = precursorMassTol;
                Parent.SettingsChanged = true;
            }

            if (!Settings.Default.PrecursorMassUnit.Equals(precursorMassUnitCombo.SelectedItem))
            {
                Settings.Default.PrecursorMassUnit = precursorMassUnitCombo.SelectedIndex;
                Parent.SettingsChanged = true;
            }

            if (!Settings.Default.PrecursorToleranceType.Equals(precursorTolTypeCombo.SelectedItem))
            {
                Settings.Default.PrecursorToleranceType = precursorTolTypeCombo.SelectedIndex;
                Parent.SettingsChanged = true;
            }

            if (!Settings.Default.PrecursorMassType.Equals(precursorMassTypeCombo.SelectedItem))
            {
                Settings.Default.PrecursorMassType = precursorMassTypeCombo.SelectedIndex;
                Parent.SettingsChanged = true;
            }

            if (!Settings.Default.PrecursorIsotopeError.Equals(precursorIsotopeErrorCombo.SelectedItem))
            {
                Settings.Default.PrecursorIsotopeError = precursorIsotopeErrorCombo.SelectedIndex;
                Parent.SettingsChanged = true;
            }

            // Set up defaults for fragment settings
            var fragmentBinSize = (double) fragmentBinSizeTextBox.DecimalValue;
            if (!Settings.Default.FragmentBinSize.Equals(fragmentBinSize))
            {
                Settings.Default.FragmentBinSize = fragmentBinSize;
                Parent.SettingsChanged = true;
            }

            var fragmentOffset = (double) fragmentOffsetTextBox.DecimalValue;
            if (!Settings.Default.FragmentBinOffset.Equals(fragmentOffset))
            {
                Settings.Default.FragmentBinOffset = fragmentOffset;
                Parent.SettingsChanged = true;
            }

            if (!Settings.Default.FragmentMassType.Equals(fragmentMassTypeCombo.SelectedItem))
            {
                Settings.Default.FragmentMassType = fragmentMassTypeCombo.SelectedIndex;
                Parent.SettingsChanged = true;
            }

            if (Settings.Default.UseSparseMatrix != sparseMatrixCheckBox.Checked)
            {
                Settings.Default.UseSparseMatrix = sparseMatrixCheckBox.Checked;
                Parent.SettingsChanged = true;
            }

            // Set up defaults for ion settings
            if (Settings.Default.UseAIons != aIonCheckBox.Checked)
            {
                Settings.Default.UseAIons = aIonCheckBox.Checked;
                Parent.SettingsChanged = true;
            }

            if (Settings.Default.UseBIons != bIonCheckBox.Checked)
            {
                Settings.Default.UseBIons = bIonCheckBox.Checked;
                Parent.SettingsChanged = true;
            }

            if (Settings.Default.UseCIons != cIonCheckBox.Checked)
            {
                Settings.Default.UseCIons = cIonCheckBox.Checked;
                Parent.SettingsChanged = true;
            }

            if (Settings.Default.UseXIons != xIonCheckBox.Checked)
            {
                Settings.Default.UseXIons = xIonCheckBox.Checked;
                Parent.SettingsChanged = true;
            }

            if (Settings.Default.UseYIons != yIonCheckBox.Checked)
            {
                Settings.Default.UseYIons = yIonCheckBox.Checked;
                Parent.SettingsChanged = true;
            }

            if (Settings.Default.UseZIons != zIonCheckBox.Checked)
            {
                Settings.Default.UseZIons = zIonCheckBox.Checked;
                Parent.SettingsChanged = true;
            }

            if (Settings.Default.UseNLIons != useNLCheckBox.Checked)
            {
                Settings.Default.UseNLIons = useNLCheckBox.Checked;
                Parent.SettingsChanged = true;
            }

            if (Settings.Default.TheoreticalFragmentIons != flankCheckBox.Checked)
            {
                Settings.Default.TheoreticalFragmentIons = flankCheckBox.Checked;
                Parent.SettingsChanged = true;
            }

            return true;
        }

        private void InitializeFromDefaultSettings()
        {
            // Set up defaults for the precursor mass settings
            precursorMassTolTextBox.Text = Settings.Default.PrecursorMassTolerance.ToString(CultureInfo.InvariantCulture);
            precursorMassUnitCombo.SelectedIndex = Settings.Default.PrecursorMassUnit;
            precursorTolTypeCombo.SelectedIndex = Settings.Default.PrecursorToleranceType;
            precursorMassTypeCombo.SelectedIndex = Settings.Default.PrecursorMassType;
            precursorIsotopeErrorCombo.SelectedIndex = Settings.Default.PrecursorIsotopeError;

            // Set up defaults for fragment settings
            fragmentBinSizeTextBox.Text = Settings.Default.FragmentBinSize.ToString(CultureInfo.InvariantCulture);
            fragmentOffsetTextBox.Text = Settings.Default.FragmentBinOffset.ToString(CultureInfo.InvariantCulture);
            fragmentMassTypeCombo.SelectedIndex = Settings.Default.FragmentMassType;
            sparseMatrixCheckBox.Checked = Settings.Default.UseSparseMatrix;
        
            // Set up defaults for ion settings
            aIonCheckBox.Checked = Settings.Default.UseAIons;
            bIonCheckBox.Checked = Settings.Default.UseBIons;
            cIonCheckBox.Checked = Settings.Default.UseCIons;
            xIonCheckBox.Checked = Settings.Default.UseXIons;
            yIonCheckBox.Checked = Settings.Default.UseYIons;
            zIonCheckBox.Checked = Settings.Default.UseZIons;
            useNLCheckBox.Checked = Settings.Default.UseNLIons;
            flankCheckBox.Checked = Settings.Default.TheoreticalFragmentIons;
        }
    }
}