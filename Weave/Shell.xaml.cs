﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Weave.Model;
using Weave.View;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Weave
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Page
    {
        public ObservableCollection<myItem> myItems = new ObservableCollection<myItem>();
        public Shell()
        {
            this.InitializeComponent();
            myItems.Add(new myItem("First", new WritingView()));
            myItems.Add(new myItem("Second", new WritingView()));
            myItems.Add(new myItem("Third", new WritingView()));
            myItems.Add(new myItem("Fourth", new WritingView()));
        }
    }
}
