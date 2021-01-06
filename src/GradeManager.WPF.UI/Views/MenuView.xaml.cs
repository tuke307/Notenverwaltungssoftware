﻿using GradeManager.WPF.UI.Region;
using MvvmCross.Platforms.Wpf.Views;

namespace GradeManager.WPF.UI.Views
{
    /// <summary>
    /// MenuView.
    /// </summary>
    /// <seealso cref="MvvmCross.Platforms.Wpf.Views.MvxWpfView{SimTuning.WPF.UI.ViewModels.MenuViewModel}" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    [MvxWpfPresenter("MainWindowRegion", mvxViewPosition.NewOrExsist)]
    public partial class MenuView : MvxWpfView<GradeManager.WPF.UI.ViewModels.MenuViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuView" /> class.
        /// </summary>
        public MenuView()
        {
            this.InitializeComponent();
        }
    }
}