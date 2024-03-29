﻿/*
    This file is part of NDoctor.

    NDoctor is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    NDoctor is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with NDoctor.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace Probel.NDoctor.View.Toolbox.Controls
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using Probel.NDoctor.Domain.DTO.Objects;

    /// <summary>
    /// Interaction logic for DrugBox.xaml
    /// </summary>
    public partial class DrugBox : UserControl
    {
        #region Fields

        public static DependencyProperty ButtonNameProperty = DependencyProperty.RegisterAttached("ButtonName", typeof(string)
            , typeof(DrugBox)
            , new UIPropertyMetadata(null));
        public static DependencyProperty CategoriesProperty = DependencyProperty.RegisterAttached("Categories", typeof(ObservableCollection<TagDto>)
            , typeof(DrugBox)
            , new UIPropertyMetadata(null));
        public static DependencyProperty DrugyProperty = DependencyProperty.RegisterAttached("Drug", typeof(DrugDto)
            , typeof(DrugBox)
            , new UIPropertyMetadata(null));
        public static DependencyProperty OkCommandProperty = DependencyProperty.RegisterAttached("OkCommand", typeof(ICommand)
            , typeof(DrugBox)
            , new UIPropertyMetadata(null));
        public static DependencyProperty TypeEnabledProperty = DependencyProperty.RegisterAttached("TypeEnabled", typeof(bool)
            , typeof(DrugBox)
            , new UIPropertyMetadata(false));

        #endregion Fields

        #region Constructors

        public DrugBox()
        {
            this.InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public string ButtonName
        {
            get { return DrugBox.GetButtonName(this); }
            set { DrugBox.SetButtonName(this, value); }
        }

        public ObservableCollection<TagDto> Categories
        {
            get { return DrugBox.GetCategories(this); }
            set { DrugBox.SetCategories(this, value); }
        }

        public DrugDto Drug
        {
            get { return DrugBox.GetDrug(this); }
            set { DrugBox.SetDrug(this, value); }
        }

        public ICommand OkCommand
        {
            get { return DrugBox.GetOkCommand(this); }
            set { DrugBox.SetOkCommand(this, value); }
        }

        public bool TypeEnabled
        {
            get { return GetTypeEnabled(this); }
            set { SetTypeEnabled(this, value); }
        }

        #endregion Properties

        #region Methods

        public static string GetButtonName(DependencyObject target)
        {
            return target.GetValue(ButtonNameProperty) as string ?? "No value";
        }

        public static ObservableCollection<TagDto> GetCategories(DependencyObject target)
        {
            return target.GetValue(CategoriesProperty) as ObservableCollection<TagDto>;
        }

        public static DrugDto GetDrug(DependencyObject target)
        {
            return target.GetValue(DrugyProperty) as DrugDto;
        }

        public static ICommand GetOkCommand(DependencyObject target)
        {
            return target.GetValue(OkCommandProperty) as ICommand;
        }

        public static bool GetTypeEnabled(DependencyObject target)
        {
            return (bool)target.GetValue(TypeEnabledProperty);
        }

        public static void SetButtonName(DependencyObject target, string value)
        {
            target.SetValue(ButtonNameProperty, value);
        }

        public static void SetCategories(DependencyObject target, ObservableCollection<TagDto> value)
        {
            target.SetValue(CategoriesProperty, value);
        }

        public static void SetDrug(DependencyObject target, DrugDto value)
        {
            target.SetValue(DrugyProperty, value);
        }

        public static void SetOkCommand(DependencyObject target, ICommand value)
        {
            target.SetValue(OkCommandProperty, value);
        }

        public static void SetTypeEnabled(DependencyObject target, bool value)
        {
            target.SetValue(TypeEnabledProperty, value);
        }

        private void this_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this.focused);
        }

        #endregion Methods
    }
}