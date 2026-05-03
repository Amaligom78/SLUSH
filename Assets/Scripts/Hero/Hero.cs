using System;
using System.Persistence;
using UnityEngine;


namespace System.Persistence
{ 

    public class Hero : MonoBehaviour, IBind<HeroData>
    {
        [field: SerializeField] public SerializableGuid Id { get; set; } = SerializableGuid.NewGuid();
        [SerializeField] HeroData data;
        private Rigidbody rb;

        public void Bind(HeroData _data)
        {
            this.data = _data;
            this.data.Id = Id;
            this.rb = GetComponent<Rigidbody>();

            rb.position = data.heroPosition;
            rb.rotation = data.heroRotation;

            UpdateStatsUI();
        }

        private void Update()
        {
            data.heroPosition = transform.position;
            data.heroRotation = transform.rotation;
        }

        private void UpdateStatsUI()
        {
            SystemManager.Instance.uiManager.hud.SetHealthText(data.heroHealth);
            SystemManager.Instance.uiManager.hud.SetShieldText(data.heroShield);
        }
    }

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
}