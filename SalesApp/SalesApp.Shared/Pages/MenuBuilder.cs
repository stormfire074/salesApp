using SalesApp.Shared.Attributes;
using Syncfusion.Blazor.Navigations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class MenuBuilder
{
    /// <summary>
    /// Builds the menu structure by discovering all classes with the MenuLink attribute.
    /// </summary>
    /// <param name="isDrawerOpen">Specifies whether the drawer is open, affecting the display of text.</param>
    /// <returns>A list of menu links with their nested menu items.</returns>
    public static List<MenuLinkModel> BuildMenu(bool isDrawerOpen)
    {
        var menuLinks = new List<MenuLinkModel>();

        // Get all classes decorated with the MenuLink attribute
        var menuClasses = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<MenuLinkAttribute>() != null);

        foreach (var menuClass in menuClasses)
        {
            var menuLinkAttr = menuClass.GetCustomAttribute<MenuLinkAttribute>();
            var menuLink = new MenuLinkModel
            {
                Text = isDrawerOpen ? menuLinkAttr.Text : "",
                IconCss = menuLinkAttr.IconCss,
                SubItems = new List<MenuItemModel>()
            };

            // Populate sub-items for the menu link
            AddMenuItems(menuClass, menuLink.SubItems);

            menuLinks.Add(menuLink);
        }

        return menuLinks;
    }

    /// <summary>
    /// Recursively adds menu items and their sub-items from a menu class.
    /// </summary>
    /// <param name="menuClass">The class containing menu items.</param>
    /// <param name="menuItems">The list to populate with menu items.</param>
    private static void AddMenuItems(Type menuClass, List<MenuItemModel> menuItems)
    {
        var properties = menuClass.GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(p => p.GetCustomAttribute<MenuItemAttribute>() != null);

        foreach (var property in properties)
        {
            var menuItemAttr = property.GetCustomAttribute<MenuItemAttribute>();
            var menuItem = new MenuItemModel
            {
                Text = menuItemAttr.Text,
                IconCss = menuItemAttr.IconCss,
                Url = menuItemAttr.Url, // Include URL property
                SubItems = new List<MenuItemModel>() // Initialize for nested items
            };

            // Check if this menu item points to a nested menu class
            if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
            {
                AddMenuItems(property.PropertyType, menuItem.SubItems);
            }

            menuItems.Add(menuItem);
        }
    }
    public class MenuLinkModel
    {
        public string Text { get; set; }
        public string IconCss { get; set; }
        public List<MenuItemModel> SubItems { get; set; } = new();
    }

    public class MenuItemModel
    {
        public string Text { get; set; }
        public string IconCss { get; set; }
        public string Url { get; set; }
        public List<MenuItemModel> SubItems { get; set; } = new();
    }


}
