﻿using UnityEngine;
using System.Collections;
public class Vector3Tool
{
    public static Vector3 Parse(string temp)
    {
        string[] s = temp.Split('/');
        return new Vector3(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]));
    }
}
public class MotionParameber{
	private static bool initial = true;
    private static float initialVelocityRecord;
    private static float accelerationRecord;
    private static float accelerationCDRecord;
    private static float gravityRecord;
    private static float fixedMotionRecord;
    private static Vector3 jumpDirRecord;
    private static Vector3 rebornDeltaRecord;
    private static float secondJumpRecord;
    private static float yLimitRecord;
    private static float elasticTreadRecord;
    private static float speedMaxRecord;
    private static Vector3 OriginPosRecord;
    private static Vector3 NearTargetPosRecord;
    private static Vector3 FarTargetPosRecord;
    private static Vector3[] nearTargetPosArray=new Vector3[10];
    private static Vector3[] farTargetPosArray=new Vector3[10];
    private Vector3 vec;
    public static float initialVelocity
    {
        get
        {
			if (initial)
				new MotionParameber ();
            return initialVelocityRecord;
        }
    }
    private MotionParameber()
    {
        ReadTable temp = ReadTable.getTable;
        initialVelocityRecord = float.Parse(temp.OnFind("motionParameber", "1", "dateValue"));
        accelerationRecord = float.Parse(temp.OnFind("motionParameber", "2", "dateValue"));
        accelerationCDRecord = float.Parse(temp.OnFind("motionParameber", "3", "dateValue"));
        gravityRecord = float.Parse(temp.OnFind("motionParameber", "4", "dateValue"));
        fixedMotionRecord = float.Parse(temp.OnFind("motionParameber", "5", "dateValue"));
        jumpDirRecord = Vector3Tool.Parse(temp.OnFind("motionParameber", "6", "dateValue"));
        rebornDeltaRecord = Vector3Tool.Parse(temp.OnFind("motionParameber", "7", "dateValue"));
        secondJumpRecord = float.Parse(temp.OnFind("motionParameber", "8", "dateValue"));
        yLimitRecord = float.Parse(temp.OnFind("motionParameber", "9", "dateValue"));
        elasticTreadRecord = float.Parse(temp.OnFind("motionParameber", "10", "dateValue"));
        speedMaxRecord = float.Parse(temp.OnFind("motionParameber", "11", "dateValue"));

        OriginPosRecord = Vector3Tool.Parse(temp.OnFind("terrainParamber","20", "dateValue"));
        Debug.Log(OriginPosRecord);
        FarTargetPosRecord = Vector3Tool.Parse(temp.OnFind("terrainParamber", "21", "dateValue"));
        NearTargetPosRecord = Vector3Tool.Parse(temp.OnFind("terrainParamber", "22", "dateValue"));


        vec = OriginPosRecord;
        for (int i = 0; i < 5; i++)
        {
            vec+=new Vector3(0.5f,1,4);
            farTargetPosArray[i] = vec;
            nearTargetPosArray[i] = vec+new Vector3(0,0,-vec.z*2);
        }
        for (int i = 5; i < 10; i++)
        {
            vec += new Vector3(0.5f, -1, 4);
            farTargetPosArray[i] = vec;
            nearTargetPosArray[i] = vec + new Vector3(0, 0, -vec.z * 2);
        }
        Debug.Log(nearTargetPosArray[9]);
        Debug.Log(farTargetPosArray[9]);
        initial = false;
    }
    //public const float acceleration = 1f;
    public static float acceleration
    {
        get
        {
			if (initial)
            {
                new MotionParameber();
            }
            return accelerationRecord;
        }
    }
    //public const float accelerationCD = 1f;
    public static float accelerationCD
    {
        get
        {
			if (initial)
            {
                new MotionParameber();
            }
            return accelerationCDRecord;
        }
    }
    //public const float gravity = 0.5f;
    public static float gravity
    {
        get
        {
			if (initial)
            {
                new MotionParameber();
            }
            return gravityRecord;
        }
    }
    //public const float fixedMotion = 0.02f;
    public static float fixedMotion
    {
        get
        {
			if (initial)
            {
                new MotionParameber();
            }
            return fixedMotionRecord;
        }
    }
    //public static Vector3 jumpDir = Vector3.up * 14f;
    public static Vector3 jumpDir
    {
        get
        { 
			if (initial)
				new MotionParameber ();
            return jumpDirRecord;
        }
    }
    //public static Vector3 rebornDelta = new Vector3(4f, 0, 0);
    public static Vector3 rebornDelta
    {
        get
        {
			if (initial)
            {
                new MotionParameber();
            }
            return rebornDeltaRecord;
        }
    }
    //public const float secondJump = 0.5f;
    public static float secondJump
    {
        get
        {
			if (initial)
            {
                new MotionParameber();
            }
            return secondJumpRecord;
        }
    }
    //public const float yLimit = -7f;
    public static float yLimit
    {
        get
        {
			if (initial)
            {
                new MotionParameber();
            }
            return yLimitRecord;
        }
    }
    //public const float elasticTread = 10f*fixedMotion;
    public static float elasticTread
    {
        get
        {
			if (initial)
            {
                new MotionParameber();
            }
            return elasticTreadRecord;
        }
    }

    public static float speedMax
    {
        get
        {
            if (initial)
            {
                new MotionParameber();
            }
            return speedMaxRecord;
        }
    }



    public static Vector3[] nearTargetPos
    {
        get
        {
            if (initial)
            {
                new MotionParameber();
            }
            return nearTargetPosArray;
        }
    }
    public static Vector3[] FarTargetPos
    {
        get
        {
            if (initial)
            {
                new MotionParameber();
            }
            return farTargetPosArray;
        }
    }
}
