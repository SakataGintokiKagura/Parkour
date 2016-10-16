﻿using UnityEngine;
using System.Collections;

public class MotionParameber{
	public const float initialVelocity = 5f;
    public const float acceleration = 1f;
    public const float accelerationCD = 1f;
    public const float gravity = 0.5f;
    public const float fixedMotion = 0.02f;
    public static Vector3 jumpDir = Vector3.up * 14f;
    public const float secondJump = 0.8f;
}
