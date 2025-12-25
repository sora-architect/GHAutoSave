using Grasshopper;

namespace GHAutoSave
{
    internal static class AutoSaveSettings
        {
        private const string KeyEnabled ="GHAutoSave.Enabled";

        internal static bool Enabled
        {
            get
            {
                bool enabled = Instances.Settings.GetValue(KeyEnabled, false);
                return enabled;
            }
            set
            {
                Instances.Settings.SetValue(KeyEnabled, value);
                Instances.Settings.WritePersistentSettings();
            }
        }
        }
}

