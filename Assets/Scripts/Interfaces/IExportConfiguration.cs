using UnityEngine;

namespace Scripts.Importer
{
    public interface IExportConfiguration
    {
        string GetDashPartExportPath();
        string GetJumpPartExportPath();
        string GetRunPartExportPath();
        void Initialize(GameObject obj);
    }
}