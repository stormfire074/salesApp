using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesApp.Shared.Attributes
{
    /// <summary>
    /// Attribute to define top-level menu links.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MenuLinkAttribute : Attribute
    {
        public string Text { get; } // The display text for the menu link
        public string IconCss { get; } // The CSS class for the icon

        public MenuLinkAttribute(string text, string iconCss)
        {
            Text = text;
            IconCss = iconCss;
        }
    }

    /// <summary>
    /// Attribute to define menu items, including sub-items and URLs.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class MenuItemAttribute : Attribute
    {
        public string Text { get; } // The display text for the menu item
        public string IconCss { get; } // The CSS class for the icon
        public string Url { get; } // The optional URL for the menu item

        /// <summary>
        /// Constructor for MenuItemAttribute.
        /// </summary>
        /// <param name="text">The display text for the menu item.</param>
        /// <param name="iconCss">The CSS class for the icon.</param>
        /// <param name="url">The optional URL for navigation.</param>
        public MenuItemAttribute(string text, string iconCss, string url = "#")
        {
            Text = text;
            IconCss = iconCss;
            Url = url;
        }
    }
}
