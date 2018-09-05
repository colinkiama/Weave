using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TabControl.Interfaces;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace TabControl
{
    public sealed class TabControl : ContentControl
    {
        public TabControl()
        {
            this.DefaultStyleKey = typeof(TabControl);
        }

        #region Properties

        public ListView Tabs
        {
            get { return (ListView)GetValue(TabsProperty); }
            private set { SetValue(TabsProperty, value); }
        }

        internal static DependencyProperty TabsProperty { get; } = DependencyProperty.Register("myTabs", typeof(ListView), typeof(TabControl), new PropertyMetadata(null));



        public object TabsItemSource
        {
            get { return (object)GetValue(TabsItemSourceProperty); }
            set { SetValue(TabsItemSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TabsItemSource.  This enables animation, styling, binding, etc...
        internal static DependencyProperty TabsItemSourceProperty { get; } =
            DependencyProperty.Register("TabsItemSource", typeof(object), typeof(TabControl), new PropertyMetadata(null));

        public DataTemplate TabItemTemplate
        {
            get { return (DataTemplate)GetValue(TabItemTemplateProperty); }
            set { SetValue(TabItemTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TabItemTemplate.  This enables animation, styling, binding, etc...
        internal static DependencyProperty TabItemTemplateProperty { get; } =
            DependencyProperty.Register("TabItemTemplate", typeof(DataTemplate), typeof(TabControl), new PropertyMetadata(null));


        #endregion

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var listView = this.GetTemplateChild("TabsListView") as ListView;
            ListenToListViewEvents(listView);
            if (listView.Items.Count > 0)
            {
                listView.SelectedIndex = 0;
            }
        }

        private void ListenToListViewEvents(ListView listView)
        {
            listView.SelectionChanged += ListView_SelectionChanged;
            listView.ItemClick += ListView_ItemClick;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                if (e.AddedItems[0] is ITabable clickedTab)
                {
                    Content = clickedTab.GetTabContent();
                }
            }
       }

        #region Event Methods

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is ITabable clickedTab)
            {
                Content = clickedTab.GetTabContent();
            }
        }

        #endregion


    }
}
