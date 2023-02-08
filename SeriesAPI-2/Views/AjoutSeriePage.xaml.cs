// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SeriesAPI.Models.EntityFramework;
using SeriesAPI_2.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SeriesAPI_2.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutSeriePage : Page
    {
        public AjoutSeriePage()
        {
            this.InitializeComponent();
            AjoutSerieViewModel ajtSerieViewModel = new AjoutSerieViewModel();
            DataContext = ((App)Application.Current).AjoutSerieVM;
        }

        public void btnAjoutSerie_Click()
        {
            
        }
    }
}
