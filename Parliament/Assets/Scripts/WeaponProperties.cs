//using System.Diagnostics.Eventing.Reader;
using UnityEngine;

namespace Assets.Scripts.Player.Shootable
{
    public class WeaponProperties : MonoBehaviour
    {
        #region Fields

        //public Transform spawn;
        [SerializeField]
        public Transform bulletEjectionPoint;
        [SerializeField]
        public Transform shellEjectionPoint;
        [SerializeField]
        public Rigidbody shell;



        [SerializeField]
        protected string _name; // Name of the Weapon
        [SerializeField]
        protected string _description; // Description of the Weapon

        [SerializeField]
        protected float _fireSpeed; // Shots per Second

        public bool _canFullAuto = false;
        public bool _canBurst = false;
        public bool _canSingleShot = false;
        public RateOfFire _fireRate; // Rate of Fire (Single, Burst, Automatic)

        protected int _roundsPerShot; // Amount of rounds fired per trigger pull
        protected bool _isSingleShot;

        [SerializeField] 
        protected bool _tracer;
        [SerializeField]
        protected float _range; // Effective Range of the Weapon (Meters)
        [SerializeField]
        protected float _spread; // Spread of the Weapon (Angle)
        [SerializeField]
        protected float _accuracy; // Accuracy of the weapon (Percent)

        [SerializeField]
        protected int _ammoTotalCount; // Current amount of ammo
        [SerializeField]
        protected int _ammoTotalMax; // Maximum amount of ammo
        [SerializeField]
        protected int _ammoClipCount; // Current amount of ammo in clip
        [SerializeField]
        protected int _ammoClipMax; // Maximum amount of ammo per clip

        [SerializeField]
        protected float _reloadSpeed; // Seconds it takes to Reload

        [SerializeField]
        protected float _minDamage; // Minimum amount of damage dealt
        [SerializeField]
        protected float _maxDamage; // Maximum amount of damamge dealt

        #endregion Fields

        #region Properties
        public bool IsSingleShot
        {
            get { return this._isSingleShot; }
        }
        #endregion Properties

        public WeaponProperties(string name, string description, float fireSpeed, bool canFullAuto, bool canBurst, bool canSingleShot, RateOfFire fireRate, bool tracer, 
            float range, float spread, float accuracy, int ammoTotalcount, 
            int ammoTotalMax, int ammoClipMax, float reloadSpeed, float minDamage, float maxDamage)
        {
            this._canFullAuto = canFullAuto;
            this._canBurst = canBurst;
            this._canSingleShot = canSingleShot;

            this._name = name;
            this._description = description;
            this._fireSpeed = fireSpeed;
            this._fireRate = fireRate;
            this._tracer = tracer;
            this._range = range;
            this._spread = spread;
            this._accuracy = accuracy;
            this._ammoTotalCount = ammoTotalcount;
            this._ammoTotalMax = ammoTotalMax;
            this._ammoClipMax = ammoClipMax;
            this._reloadSpeed = reloadSpeed;
            this._minDamage = minDamage;
            this._maxDamage = maxDamage;

            this._ammoClipCount = ammoClipMax;

            switch (_fireRate)
            {
                case RateOfFire.Single: // Single Shot
                    _roundsPerShot = 1;
                    _isSingleShot = true;
                    break;
                case RateOfFire.Burst: // Burst Shot
                    _roundsPerShot = 3;
                    _isSingleShot = true;
                    break;
                case RateOfFire.Auto: // Automatic
                    _roundsPerShot = 1;
                    _isSingleShot = false;
                    break;
            }
        }

        #region Public Methods

        /* Player Controls */
        /*
         *  - Switch Rate of Fire
         *  -? Switch ammo type
         */
        // Switch Rate of Fire
        private void SetFireRate()
        {
            switch (_fireRate)
            {
                case RateOfFire.Single: // Single Shot
                    _roundsPerShot = 1;
                    _isSingleShot = true;
                    break;
                case RateOfFire.Burst: // Burst Shot
                    _roundsPerShot = 3;
                    _isSingleShot = true;
                    break;
                case RateOfFire.Auto: // Automatic
                    _roundsPerShot = 1;
                    _isSingleShot = false;
                    break;
            }
        }

        public void NextRateOfFire()
        {
            RateOfFire fr = _fireRate;

            if (fr == RateOfFire.Single)
            {
                if (_canBurst)
                {
                    fr = RateOfFire.Burst;
                }
                else if (_canFullAuto)
                {
                    fr = RateOfFire.Auto;
                }
            }
            else if (fr == RateOfFire.Burst)
            {
                if (_canFullAuto)
                {
                    fr = RateOfFire.Auto;
                }
                else if (_canSingleShot)
                {
                    fr = RateOfFire.Single;
                }
            }
            else if (fr == RateOfFire.Auto)
            {
                if (_canSingleShot)
                {
                    fr = RateOfFire.Single;
                }
                else if (_canBurst)
                {
                    fr = RateOfFire.Burst;
                }
            }

            _fireRate = fr;
            SetFireRate();
        }

        /* Weapon Events */
        /*
         *  Bool CheckReload()
         *      - Returns if weapon is reloadable or not.
         *      
         *  Bool CheckFire()
         *      - 
         *      
         *  Reload()
         *      - 
         *      
         *  Fire()
         *      - 
         *      
         *  asdfafad
         *  
         */

        public bool CheckReload() // Check to see if the weapon is reloadable
        {
            if (_ammoClipCount < _ammoClipMax && _ammoTotalCount > 0) // Check to see if a reload is possible
                return true;
            else
                return false;
        }
        public bool CheckFire()
        {
            if (_ammoClipCount > 0) // Weapon is loaded and ready
                return true;
            else// Weapon is out of Ammo or Needs reloading
            {
                return false;
            }
        }

        public void Reload() // Reloads the weapon, Called from WeaponHandler, once the reload timer is up (Makes sure the reload isn't interupted)
        {
            int reloadAmountNeeded = _ammoClipMax - _ammoClipCount; // Get how much ammo is needed for full clip

            if (reloadAmountNeeded > _ammoTotalCount) // Check to see if there is enough ammo to reload fully
                reloadAmountNeeded = _ammoTotalCount;

            _ammoClipCount += reloadAmountNeeded; // Replenish the clip with ammo
            _ammoTotalCount -= reloadAmountNeeded; // Remove ammo from the total count
        }
        public void Fire()
        {
            if (_ammoClipCount > 0) // Has ammo
            {
                _ammoClipCount -= _roundsPerShot;
                // Fire Bullet
                // Create new ray, from gun to where the palyer is looking

                

                // Start Fire Animation
                // Start Fire Sound
            }
            else // Out of ammo
            {
                //Reload();
                // Start 'No Ammo' Sound
            }
            // Fire Bullet
        }

        public float GetReloadSpeed() { return this._reloadSpeed; }
        public float GetFireSpeed() { return this._fireSpeed; }

        public int GetTotalAmmo() { return this._ammoTotalCount; }
        public int GetMaxClip() { return this._ammoClipMax; }
        public int GetClip() { return this._ammoClipCount; }
        public float GetRange()
        {
            return this._range;
        }

        public bool GetTracer()
        {
            return _tracer;
        }

        public float GetDamage()
        {
            return Random.Range(_minDamage, _maxDamage);
        }

        #endregion Public Methods


    }
}