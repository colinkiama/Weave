using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabControl.Interfaces;
using Windows.UI.Xaml.Controls;

namespace Weave.Model
{
    public class myItem : ITabable
    {
        public object itemContent { get; set; }
        public string Name { get; set; }

        public myItem(string myName, object myContent)
        {
            itemContent = myContent;
            Name = myName;
        }

        public object GetTabContent()
        {
            return itemContent;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
