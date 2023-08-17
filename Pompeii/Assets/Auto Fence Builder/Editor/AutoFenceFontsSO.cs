using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "autofence_fonts", menuName = "AutoFence/FontPrefs", order = 1)]

public class AutoFenceFontsSO : ScriptableObject
{
    public int infoStyleSmallSize = 10, greyStyleSize = 11;
    public Color infoStyleSmallColor = new Color(0, .5f, .75f); //Dark Cyan
    public Color greyStyleColor = Color.grey;
    public static AutoFenceFontsSO ReadFontsPrefs(AutoFenceCreator af)
    {

        bool mainPresetFolderExists = AssetDatabase.IsValidFolder(af.currAutoFenceBuilderDirLocation);
        if (mainPresetFolderExists == false)
        {
            Debug.LogWarning("Main AFWB Folder Missing, Can't load Fonts prefs.");
            return null;
        }

        string fontsFilePath = af.currAutoFenceBuilderDirLocation + "/Editor/AutoFenceFonts.asset";
        
        AutoFenceFontsSO fontsFile = AssetDatabase.LoadAssetAtPath(fontsFilePath, typeof(AutoFenceFontsSO)) as AutoFenceFontsSO;
        if (fontsFile == false)
        {
            Debug.LogWarning("Main AFWB config Fonts File missing");
            return null;
        }
        
        return fontsFile;
    }
}
