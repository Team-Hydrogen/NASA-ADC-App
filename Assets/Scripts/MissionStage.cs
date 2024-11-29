using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MissionStage
{
    public int startDataIndex;
    public StageTypes stageType;

    public MissionStage(int startDataIndex, StageTypes stageType)
    {
        this.startDataIndex = startDataIndex;
        this.stageType = stageType;
    }

    private static readonly Dictionary<StageTypes, Color> StageColors = new()
    {
        { StageTypes.Launch, new Color(0.9373f, 0.2588f, 0.2588f) },
        { StageTypes.OrbitingEarth, new Color(1.0000f, 0.7569f, 0.0000f) },
        { StageTypes.TravellingToMoon, new Color(0.5451f, 0.9294f, 0.1804f) },
        { StageTypes.FlyingByMoon, new Color(0.2588f, 0.6824f, 0.9451f) },
        { StageTypes.ReturningToEarth, new Color(0.5373f, 0.2588f, 0.9451f) },
        { StageTypes.ReEntryAndSplashdown, new Color(0.9451f, 0.2588f, 0.5176f) }
    };

    private static readonly Dictionary<StageTypes, string> StageNames = new()
    {
        { StageTypes.Launch, "Launch" },
        { StageTypes.OrbitingEarth, "Orbiting Earth" },
        { StageTypes.TravellingToMoon, "Travelling to Moon" },
        { StageTypes.FlyingByMoon, "Flying by Moon" },
        { StageTypes.ReturningToEarth, "Returning to Earth" },
        { StageTypes.ReEntryAndSplashdown, "Re-entry + Splashdown" }
    };

    public enum StageTypes
    {
        None,
        Launch,
        OrbitingEarth,
        TravellingToMoon,
        FlyingByMoon,
        ReturningToEarth,
        ReEntryAndSplashdown
    }

    public string name
    {
        get
        {
            return GetStageName(stageType);
        }
    }

    public Color color
    {
        get
        {
            return GetStageColor(stageType);
        }
    }

    //public Color GetStageColor()
    //{
    //    return GetStageColor(stageType);
    //}

    public static Color GetStageColor(StageTypes stageType)
    {
        if (StageColors.TryGetValue(stageType, out var color))
        {
            return color;
        }

        // Default color
        return Color.white;
    }

    //public string GetStageName()
    //{
    //    return GetStageName(stageType);
    //}

    public static string GetStageName(StageTypes stageType)
    {
        if (StageNames.TryGetValue(stageType, out var name))
        {
            return name;
        }

        // Default color
        return "ERROR: NO STAGE NAME!";
    }

    public override bool Equals(object obj)
    {
        if (obj is MissionStage other)
        {
            return startDataIndex == other.startDataIndex && stageType == other.stageType;
        }

        return false;
    }
}
