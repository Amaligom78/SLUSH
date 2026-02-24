using System;
using System.Persistence;
using UnityEngine;


[Serializable]
public class PlayerData : ISaveable
{

    [field: SerializeField] public SerializableGuid Id { get; set; }
    public string playerName;
    public Vector3 position;
    public Quaternion rotation;
}