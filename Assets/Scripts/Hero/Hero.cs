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

            transform.position = data.position;
            transform.rotation = data.rotation;
        }

        private void Update()
        {
            data.position = transform.position;
            data.rotation = transform.rotation;
        }
    }

    [Serializable]
    public class PlayerData : ISaveable
    {
        [field: SerializeField] public SerializableGuid Id { get; set; }
        public string playerName;
        public Vector3 position;
        public Quaternion rotation;

    }
}