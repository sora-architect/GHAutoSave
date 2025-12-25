using System;
using Grasshopper.Kernel;

namespace GHAutoSave
{
    /// <summary>
    /// テンプレート都合で生成される“ダミー”。
    /// ・ツールバーに出ない
    /// ・キャンバスに置かれない
    /// ・共有ファイルに依存を作らない
    /// ために hidden + Icon null を徹底する。
    /// </summary>
    public sealed class AutoSaveDummyComponent : GH_Component
    {
        public AutoSaveDummyComponent()
            : base("AutoSaveDummy", "AutoSaveDummy",
                   "Not used. AutoSave is controlled from the Display menu.",
                   "AutoSave", "Internal")
        {
        }

        public override Guid ComponentGuid =>
            new Guid("9EAA3D1C-0B08-43D0-9A40-0E2F95AB4FD8");

        // ツールバーに出さない
        public override GH_Exposure Exposure => GH_Exposure.hidden;

        protected override void RegisterInputParams(GH_InputParamManager p) { }
        protected override void RegisterOutputParams(GH_OutputParamManager p) { }

        protected override void SolveInstance(IGH_DataAccess da)
        {
            // 何もしない
        }

        protected override System.Drawing.Bitmap Icon => null;
    }
}
