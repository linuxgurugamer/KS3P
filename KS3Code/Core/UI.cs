using System;
using System.IO;
using UnityEngine;
using KSP.UI.Screens;
using System.Collections.Generic;
using KS3P.Shaders;
using ToolbarControl_NS;
using ClickThroughFix;

[KSPAddon(KSPAddon.Startup.SpaceCentre, true)]
public class KS3P_Editor : MonoBehaviour
{
    internal const string MODID = "ks3p_NS";
    internal const string MODNAME = "KS3P";

    private KS3P.Core.KS3P core;
    private List<GameScenes> scenes;
    private bool initialized = false;

    private PostProcessingProfile profile;

    private AntialiasingModel.FxaaSettings fxaaSettings;
    private AntialiasingModel.TaaSettings taaSettings;

    private AmbientOcclusionModel.Settings occlusionSettings;

    private BloomModel.BloomSettings bloomSettings;
    private BloomModel.LensDirtSettings dirtSettings;

    private ChromaticAberrationModel.Settings abberationSettings;

    private ColorGradingModel.BasicSettings cgBasicSettings;
    private ColorGradingModel.ChannelMixerSettings cgMixerSettings;
    private ColorGradingModel.CurvesSettings cgCurvesSettings;
    private ColorGradingModel.LinearWheelsSettings cgLinearSettings;
    private ColorGradingModel.LogWheelsSettings cgLogSettings;
    private ColorGradingModel.TonemappingSettings cgTonemapperSettings;

    private DepthOfFieldModel.Settings dofSettings;

    private EyeAdaptationModel.Settings eaSettings;

    private GrainModel.Settings grainSettings;

    private MotionBlurModel.Settings mbSettings;

    private UserLutModel.Settings ulSettings;

    private VignetteModel.Settings vSettings;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        if(!initialized)
        {
            core = KS3P.Core.KS3P.Main;
            scenes = core.guiButtonScenes;
            //GameEvents.onGUIApplicationLauncherReady.Add(AddButton);
            //GameEvents.onGUIApplicationLauncherUnreadifying.Add(RemoveButton);
            initialized = true;
            CreateButtonIcon();
        }
    }

#if false
    private void RemoveButton(GameScenes data)
    {
        
    }

    private void AddButton()
    {

    }
#endif

    ToolbarControl toolbarControl;
    private void CreateButtonIcon()
    {
        toolbarControl = gameObject.AddComponent<ToolbarControl>();
        toolbarControl.AddToAllToolbars(ToggleOn, ToggleOff,
            ApplicationLauncher.AppScenes.SPACECENTER | ApplicationLauncher.AppScenes.VAB | ApplicationLauncher.AppScenes.SPH |
            ApplicationLauncher.AppScenes.FLIGHT | ApplicationLauncher.AppScenes.MAPVIEW | ApplicationLauncher.AppScenes.TRACKSTATION,
            MODID,
            "ks3pButton",
            "KS3P/PluginData/button-38",
            "KS3P/PluginData/button-24",
            MODNAME
        );
    }
    void OnDestroy()
    {
        toolbarControl.OnDestroy();
        Destroy(toolbarControl);
    }

    void ToggleOn()
    {

    }
    void ToggleOff()
    {

    }
    void Build()
    {
        profile.ambientOcclusion.settings = occlusionSettings;
        
    }
}