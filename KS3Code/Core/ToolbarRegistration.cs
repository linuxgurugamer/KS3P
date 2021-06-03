using UnityEngine;
using ToolbarControl_NS;

namespace KerbalSlingshotter
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class RegisterToolbar : MonoBehaviour
    {
        void Start()
        {
            ToolbarControl.RegisterMod(KS3P_Editor.MODID, KS3P_Editor.MODNAME);
        }
    }
}