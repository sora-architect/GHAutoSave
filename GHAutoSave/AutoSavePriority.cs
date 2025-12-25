using Grasshopper;

namespace GHAutoSave
{
    public sealed class AutoSavePriority : Grasshopper.Kernel.GH_AssemblyPriority
    {
        public override Grasshopper.Kernel.GH_LoadingInstruction PriorityLoad()
        {
            Instances.CanvasCreated += AutoSaveMenu.OnCanvasCreated;
            return Grasshopper.Kernel.GH_LoadingInstruction.Proceed;
        }
    }
}
