using System;
using System.Persistence;
using UnityEngine;


namespace System.Persistence
{ 

    public class Hero : MonoBehaviour, IBind<HeroData>, IDamagable
    {
        [field: SerializeField] public SerializableGuid Id { get; set; } = SerializableGuid.NewGuid();
        [SerializeField] HeroData heroData;
        private Rigidbody rb;
        [SerializeField] Weapon weaponLogic;
        [SerializeField] WeaponData startingWeaponData;

        public void Bind(HeroData _data)
        {
            this.heroData = _data;
            this.heroData.Id = Id;
            this.rb = GetComponent<Rigidbody>();

            rb.position = heroData.heroPosition;
            rb.rotation = heroData.heroRotation;

            UpdateStatsUI();
        }

        private void Start()
        {
            weaponLogic.AddWeapon(startingWeaponData);
        }

        private void Update()
        {
            heroData.heroPosition = transform.position;
            heroData.heroRotation = transform.rotation;
        }

        private void UpdateStatsUI()
        {
            SystemManager.Instance.uiManager.hud.SetHealthText(heroData.heroHealth);
            SystemManager.Instance.uiManager.hud.SetShieldText(heroData.heroShield);
        }

        public void IDamage(int _damage)
        {
            heroData.heroHealth -= _damage;
            UpdateStatsUI();
            IsDead();
        }

        public bool IsDead()
        {
            if (heroData.heroHealth <= 0)
            {
                heroData.heroHealth = 0;
                return true;
            }

            return false;
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