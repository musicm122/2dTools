using UnityEngine;

namespace Scripts.Importer
{
    [CreateAssetMenu(menuName = "Tools/2dTools/Create ExportConfiguration")]
    public class ExportConfiguration : ScriptableObject, IExportConfiguration
    {
        public string GetJumpPartExportPath()
        {
            return Constants.DefaultConfig.GetPartDir(JumpPartFileName);
        }

        public string GetRunPartExportPath()
        {
            return Constants.DefaultConfig.GetPartDir(RunPartFileName);
        }

        public string GetDashPartExportPath()
        {
            return Constants.DefaultConfig.GetPartDir(DashPartFileName);
        }

        [SerializeField]
        public string FileName = "Part";

        [SerializeField]
        public string RunPartFileName = "RunPart";

        [SerializeField]
        public string JumpPartFileName = "JumpPart";

        [SerializeField]
        public string DashPartFileName = "DashPart";

        public void Initialize(GameObject obj)
        {
            ScriptableObject asset = ScriptableObject.CreateInstance<ExportConfiguration>();
        }
    }

}