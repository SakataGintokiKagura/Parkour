﻿using UnityEngine;
using System.Collections;

public class MotionParameber{
	public const float initialVelocity = 7f;
    public const float acceleration = 1f;
    public const float accelerationCD = 1f;
    public const float gravity = 0.5f;
    public const float fixedMotion = 0.02f;
    public static Vector3 jumpDir = Vector3.up * 14f;
    public static Vector3 rebornDelta = new Vector3(4f, 0, 0);
    public const float secondJump = 0.5f;
    public const float yLimit = -7f;
    public const float elasticTread = 10f*fixedMotion; 
}
