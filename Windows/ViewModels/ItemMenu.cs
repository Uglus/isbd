using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Windows.ViewModels
{
    public class ItemMenu
    {
        public ItemMenu(string header, List<SubItem> subItems, PackIconKind icon)
        {
            this.Header = header;
            this.SubItems = subItems;
            this.Icon = icon;
        }
        public ItemMenu(string header, UserControl screen, PackIconKind icon)
        {
            this.Header = header;
            this.Screen = screen;
            this.Icon = icon;
        }

        public string Header { get; private set; }
        public PackIconKind Icon { get; private set; }
        public List<SubItem> SubItems { get; private set; }
        public UserControl Screen { get; private set; }

    }
}
