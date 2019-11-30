﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
abstract public class Fighter : MonoBehaviour
{
    public abstract string HorizontalAxisName();
    public abstract string VerticalAxisName();
    public abstract string JumpButtonName();
    public abstract string FireButtonName();
    public abstract string HealthBarName();
}
