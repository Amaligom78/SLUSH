using System;
using UnityEngine;

[Serializable]
public class Attack_Data
{
    [field: SerializeField] public string animationName {  get; private set; }
    [field: SerializeField] public float transitionDuration { get; private set; }
    [field: SerializeField] public int comboStateIndex { get; private set; } = -1;
    [field: SerializeField] public float comboAttackTime { get; private set; }
}
