using System;
using System.Persistence;
using UnityEngine;


namespace System.Persistence
{ 

    public class Hero : MonoBehaviour, IBind<PlayerData>
    {
        [field: SerializeField] public SerializableGuid Id { get; set; } = SerializableGuid.NewGuid();
        [SerializeField] PlayerData data;

        public void Bind(PlayerData _data)
        {
            this.data = _data;
            this.data.Id = Id;

            transform.position = data.playerPosition;
            transform.rotation = data.playerRotation;
        }

        private void Update()
        {
            data.playerPosition = transform.position;
            data.playerRotation = transform.rotation;
        }
    }

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
}