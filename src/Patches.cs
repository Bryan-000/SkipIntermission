namespace SkipIntermission;

using HarmonyLib;

/// <summary> Skips intermissions. </summary>
[HarmonyPatch]
public static class Patches
{
    /// <summary> Skips any intermissions. </summary>
    [HarmonyPrefix] [HarmonyPatch(typeof(FinalRank), "LevelChange")]
    public static bool Skip()
    {
        if (SceneHelper.CurrentScene is "Level 3-2" or "Level 6-2")
        {
            SceneHelper.LoadScene(SceneHelper.CurrentScene == "Level 3-2" 
                ? "Level 4-1"
                : "Level 7-1");

            return false;
        }

        return true;
    }
}
