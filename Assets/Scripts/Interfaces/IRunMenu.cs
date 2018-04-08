namespace AssemblyCSharp.Assets.Scripts.UI.Navigation
{
    public interface IPartMenu
    {
        void AddClickListenersToButtons();
        void AddValueChangedListenersToControls();
        void ExportJson();
        void ImportJson();
    }
}