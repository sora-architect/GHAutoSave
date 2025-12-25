using System;
using System.IO;
using System.Windows.Forms;
using Grasshopper;
using Grasshopper.Kernel;

namespace GHAutoSave
{
    internal static class AutoSaveService
    {
        // 要件：毎回30秒固定（変更機能なし）
        private const int IntervalSeconds = 30;

        private static Timer _timer;
        private static bool _enabled;
        private static bool _isSaving;

        internal static void EnsureTimer()
        {
            if (_timer != null)
                return;

            _timer = new Timer();
            _timer.Interval = IntervalSeconds * 1000;
            _timer.Tick += OnTick;
        }

        internal static void SetEnabled(bool enabled)
        {
            _enabled = enabled;

            if (_timer == null)
                EnsureTimer();

            if (_enabled && !_timer.Enabled)
                _timer.Start();

            if (!_enabled && _timer.Enabled)
                _timer.Stop();
        }

        private static void OnTick(object sender, EventArgs e)
        {
            if (!_enabled)
                return;

            if (_isSaving)
                return;

            _isSaving = true;

            try
            {
                GH_DocumentServer server = Instances.DocumentServer;
                if (server == null)
                    return;

                int count = server.DocumentCount;

                for (int i = 0; i < count; i++)
                {
                    GH_Document doc = server[i];
                    if (doc == null)
                        continue;

                    if (!doc.IsFilePathDefined)
                        continue;

                    string path = doc.FilePath;
                    if (string.IsNullOrWhiteSpace(path))
                        continue;

                    if (!File.Exists(path))
                        continue;

                    if (!doc.IsModified)
                        continue;

                    GH_DocumentIO io = new GH_DocumentIO();
                    io.Document = doc;

                    bool ok = io.Save();
                    if (!ok)
                    {
                        continue;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                _isSaving = false;
            }
        }
    }
}
