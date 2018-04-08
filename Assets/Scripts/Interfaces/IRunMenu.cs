using Scripts.Importer.Parts;

namespace AssemblyCSharp.Assets.Scripts.UI.Navigation
{
    public interface IPartMenu<TPart> where TPart : BasePart
    {
        TPart Part { get; }
        void AddClickListenersToButtons();
        void AddValueChangedListenersToControls();
    }
}