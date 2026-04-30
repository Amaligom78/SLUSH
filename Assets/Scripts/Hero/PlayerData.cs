using System;
using System.Persistence;
using UnityEngine;


[Serializable]
public class PlayerData : ISaveable
{

    [field: SerializeField] public SerializableGuid Id { get; set; }
    public string playerName;
    public int playerLevel;
    public string playerReputation;
    public Vector3 playerPosition;
    public Quaternion playerRotation;
}