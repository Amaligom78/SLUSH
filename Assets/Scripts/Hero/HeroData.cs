using System;
using System.Persistence;
using UnityEngine;


[Serializable]
public class HeroData : ISaveable
{

    [field: SerializeField] public SerializableGuid Id { get; set; }
    public string heroName;
    public int heroLevel;
    public int heroHealth;
    public int heroShield;
    public string heroReputation;
    public Vector3 heroPosition;
    public Quaternion heroRotation;
}