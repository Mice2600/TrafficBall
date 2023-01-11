using UnityEditor;
namespace ProjectSettings
{
    public class ProjectSettingsWindow : TabelWindowType<ProjectSettings>
    {
        [MenuItem("ProjectSettings/Prefabs")]
        public static void OnTryOpenWindow() => OpenWindow();
        protected override void DrawMenu()
        {
            //base.DrawMenu();
        }
    }
}