using UnityEngine;
using System.Collections;

public class SkillParameber {
    private static bool initial = true;
    private static float flashDeltaRecord;
    private static float hurtInvilicibleTimeRecord;
    private static float skillInvilicibleAuxiliaryTimeRecord;
    private static float skillAccelerateAuxiliaryTimeRecord;
    private static Vector3 skillAccelerateAuxiliaryDeltaRecord;

    private static int dropOutHurtRecord;
    private static float SkillReadCDRecord;
    private static int replyRecord;
    private SkillParameber()
    {
        ReadTable temp = ReadTable.getTable;
        flashDeltaRecord = float.Parse(temp.OnFind("skillParameber", "1", "dateValue"));
        hurtInvilicibleTimeRecord = float.Parse(temp.OnFind("skillParameber", "2", "dateValue"));
        skillInvilicibleAuxiliaryTimeRecord = float.Parse(temp.OnFind("skillParameber", "3", "dateValue"));
        skillAccelerateAuxiliaryTimeRecord = float.Parse(temp.OnFind("skillParameber", "4", "dateValue"));
        skillAccelerateAuxiliaryDeltaRecord = Vector3Tool.Parse(temp.OnFind("skillParameber", "5", "dateValue"));
        dropOutHurtRecord = int.Parse(temp.OnFind("skillParameber", "6", "dateValue"));
        SkillReadCDRecord = float.Parse(temp.OnFind("skillParameber", "7", "dateValue"));
        replyRecord = int.Parse(temp.OnFind("skillParameber", "8", "dateValue"));
        initial = false;
    }
    public static float flashDelta
    {
        get
        {
            if (initial)
                new SkillParameber();
            return flashDeltaRecord;
        }
    }

    public static float hurtInvilicibleTime
    {
        get
        {
            if (initial)
                new SkillParameber();
            return hurtInvilicibleTimeRecord;
        }
    }

    public static float skillInvilicibleAuxiliaryTime
    {
        get
        {
            if (initial)
                new SkillParameber();
            return skillInvilicibleAuxiliaryTimeRecord;
        }
    }

    public static float skillAccelerateAuxiliaryTime
    {
        get
        {
            if (initial)
                new SkillParameber();
            return skillAccelerateAuxiliaryTimeRecord;
        }
    }

    public static Vector3 skillAccelerateAuxiliaryDelta
    {
        get
        {
            if (initial)
                new SkillParameber();
            return skillAccelerateAuxiliaryDeltaRecord;
        }
    }

    public static int dropOutHurt
    {
        get
        {
            if (initial)
                new SkillParameber();
            return dropOutHurtRecord;
        }
    }

    public static float SkillReadCD
    {
        get
        {
            if (initial)
                new SkillParameber();
            return SkillReadCDRecord;
        }
    }

    public static int reply
    {
        get
        {
            if (initial)
                new SkillParameber();
            return replyRecord;
        }
    }
}
