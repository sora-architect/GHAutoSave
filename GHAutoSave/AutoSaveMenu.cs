using Grasshopper;
using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using System;
using System.Windows.Forms;

namespace GHAutoSave
{
    internal static class AutoSaveMenu
    {
        private static ToolStripMenuItem _menuItemAutoSave;

        internal static void OnCanvasCreated(GH_Canvas canvas)
        {
            Instances.CanvasCreated -= OnCanvasCreated;

            EnsureMenuItem();
            AutoSaveService.EnsureTimer();
            AutoSaveService.SetEnabled(AutoSaveSettings.Enabled);
        }

        private static void EnsureMenuItem()
        {
            Grasshopper.GUI.GH_DocumentEditor editor = Instances.DocumentEditor;
            if (editor == null)
                return;

            MenuStrip menuStrip = editor.MainMenuStrip;
            if (menuStrip == null)
                return;

            ToolStripMenuItem displayMenu = FindDisplayMenu(menuStrip);
            if (displayMenu == null)
                return;

            if (_menuItemAutoSave != null)
                return;

            _menuItemAutoSave = new ToolStripMenuItem("AutoSave");
            _menuItemAutoSave.CheckOnClick = true;
            _menuItemAutoSave.Checked = AutoSaveSettings.Enabled;
            _menuItemAutoSave.ToolTipText =
                "Enable/Disable AutoSave.\n" +
                "Every 30 seconds (fixed).\n" +
                "Only saves .gh files that were saved at least once.";

            _menuItemAutoSave.CheckedChanged += OnAutoSaveCheckedChanged;

            displayMenu.DropDownItems.Add(new ToolStripSeparator());
            displayMenu.DropDownItems.Add(_menuItemAutoSave);
        }

        private static void OnAutoSaveCheckedChanged(object sender, EventArgs e)
        {
            if (_menuItemAutoSave == null)
                return;

            bool enabled = _menuItemAutoSave.Checked;
            AutoSaveSettings.Enabled = enabled;
            AutoSaveService.SetEnabled(enabled);
        }

        private static ToolStripMenuItem FindDisplayMenu(MenuStrip menuStrip)
        {
            for (int i = 0; i < menuStrip.Items.Count; i++)
            {
                ToolStripItem item = menuStrip.Items[i];
                ToolStripMenuItem menuItem = item as ToolStripMenuItem;
                if (menuItem == null)
                    continue;

                string text = (menuItem.Text ?? string.Empty).Replace("&", string.Empty);

                if (string.Equals(text, "Display", StringComparison.OrdinalIgnoreCase))
                    return menuItem;

                if (string.Equals(text, "•\Ž¦", StringComparison.OrdinalIgnoreCase))
                    return menuItem;
            }

            if (menuStrip.Items.Count > 3)
            {
                ToolStripMenuItem fallback = menuStrip.Items[3] as ToolStripMenuItem;
                return fallback;
            }

            return null;
        }
    }
}
