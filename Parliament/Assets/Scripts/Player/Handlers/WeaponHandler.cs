using System.Collections;
using System.Runtime.InteropServices;
using System.Xml;
using Assets.Scripts.Player.Shootable;
using UnityEngine;

namespace Assets.Scripts.Player.Handlers
{
    public class WeaponHandler : MonoBehaviour
    {
        #region Fields

        //DEBUG
        public bool ShowSpread = true;

        //private LineRenderer tracer; // Moved to weapon properties

        private const float TIMER_MODIFIER = 60;

        public WeaponProperties _primaryWeapon;

        protected bool _isTrigger = false;
        protected bool _isFiring = false;
        protected float _firingCounter = 0.0f;

        protected bool _isReloading = false;
        protected float _reloadCounter = 0.0f;

        public Vector3 playerPos, mousePos;
        #endregion Fields

        #region Monobehaviour
        // Use this for initialization
        void Start ()
        {
            Messenger.AddListener("WeaponReload", CheckReload);
            Messenger.AddListener("WeaponStartFire", CheckFire);
            Messenger.AddListener ("WeaponStopFire", StopFire);
            Messenger.AddListener("ChangeRateOfFire", ChangeRateOfFire);

            /*
            if (GetComponent<LineRenderer>())
            {
                tracer = GetComponent<LineRenderer>();
            }
             * */
        }
	
        // Update is called once per frame
        void Update ()
        {
            playerPos = this.gameObject.transform.position;
            mousePos = Cursor.GetLocalMouseLocationRelativeTo(this.gameObject.transform.localPosition);

            CheckReloadTimer();
            CheckFireTimer();

            if (ShowSpread)
            {
                Debug_ShowSpread();
            }
        }
        #endregion Monobehaviour
        #region Private Methods
        private void CheckReload()
        {
            Debug.Log("Checking Reload");
            if(!_isReloading)
            {
                _isReloading = _primaryWeapon.CheckReload();
            }
        }
	
        private void CheckFire()
        {
            _isTrigger = true;

            if (_isReloading && _primaryWeapon.CheckFire()) // Cancel current reload, Firing has priority
            {
                _isReloading = false;
                _reloadCounter = 0.0f;
            }
		
            if(!_isFiring)
            {
                _isFiring = true;
            }
        }
	
        private void StopFire()
        {
            _isTrigger = false;
        }
	
        private void CheckReloadTimer() // Checks the timer for the Weapon's Reloading
        {
            if(_isReloading) // Check to see if the Weapon is currently reloading
            {
                if(_reloadCounter < _primaryWeapon.GetReloadSpeed() * TIMER_MODIFIER) // Check to see if the Weapon is still reloading
                {
                    if (!_isFiring || !_primaryWeapon.CheckFire()) // Don't reload until weapon is not firing
                        _reloadCounter++;
                }
                else // Weapon is done reloading
                {
                    _isReloading = false;
                    _reloadCounter = 0.0f;
                    _primaryWeapon.Reload(); // Call for Re.load
                }
            }
        }
        private void CheckFireTimer() // Checks the timer for the Weapon's Firing
        {
            if(_isTrigger || _isFiring) // Check to see if the Weapon is currently firing
            {
                if (_firingCounter == 0) // Fire instantly (if there is ammo)
                    Fire();

                if (_firingCounter < (TIMER_MODIFIER / (_primaryWeapon.GetFireSpeed() * TIMER_MODIFIER)) * TIMER_MODIFIER) // Check to see if the Weapon is still firing (for one shot)
                {
                    _firingCounter++;
                    if (_firingCounter >= (TIMER_MODIFIER / (_primaryWeapon.GetFireSpeed() * TIMER_MODIFIER)) * TIMER_MODIFIER)
                    {
                        _firingCounter = 0.0f;
                        if (_primaryWeapon.IsSingleShot)
                            _isTrigger = false;
                        if (!_isTrigger)
                            _isFiring = false;
                    }
                }
            }
        }

        private void Fire()
        {
            // Check for burst, fire 3 in a row. Else, fire once.
            if (_primaryWeapon._fireRate == RateOfFire.Burst)
                for(int i = 0; i < 3; i++)
                    _primaryWeapon.Fire();
            else
                _primaryWeapon.Fire();
        }

        private void ChangeRateOfFire()
        {
            _primaryWeapon.NextRateOfFire();
        }
        #endregion Private Methods



        #region Public Methods

        #endregion Public Methods


        void OnGUI()
        {
            string str = "";
            string debugStr = "";

            Vector3 eAngles = this.gameObject.transform.eulerAngles;

            debugStr += "Rotation(x,y,z): " + Mathf.RoundToInt(eAngles.x) + ", " + Mathf.RoundToInt(eAngles.y) + ", " + Mathf.RoundToInt(eAngles.z) + "\n";
            debugStr += "PlayerPos(x,y,z): " + playerPos.ToString() + "\n";
            debugStr += "MousePos(x,y,z): " + mousePos.ToString() + "\n\n";

            debugStr += "Direction: " + this.transform.forward.ToString() + "\n\n";

            str += "Ammo: " + _primaryWeapon.GetClip() + "/" + _primaryWeapon.GetMaxClip() + "/" + _primaryWeapon.GetTotalAmmo() + "\n";
            str += "Fire Rate: " + _primaryWeapon._fireRate.ToString() + "\n\n";
            str += "FireCounter: " + this._firingCounter.ToString() + "\n\n";

            if (_isTrigger)
                str += "Trigger\n";
            else
                str += "\n";
            if (_isReloading)
                str += "Reloading: " + _reloadCounter + " | " + _primaryWeapon.GetReloadSpeed() * TIMER_MODIFIER + "\n";
            else
                str += "\n";
            if (_isFiring)
                str += "Firing: " + _firingCounter + "|" + (TIMER_MODIFIER / (_primaryWeapon.GetFireSpeed() * TIMER_MODIFIER)) * TIMER_MODIFIER + "\n";
            else
                str += "\n";

            if (ShowSpread)
                str += "Spread: " + _primaryWeapon.GetSpread() + " Degrees\n";
            else
                str += "\n";
        

            GUI.Box(new Rect(Screen.width-155, 5, 150, 300), str);
            GUI.Box(new Rect(Screen.width - 205, Screen.height - 105, 200, 100), debugStr);
        }

        /* ENUMS 

        IEnumerator RenderTracer(Vector3 hitPoint)
        {
            tracer.enabled = true;
            tracer.SetPosition(0, this.transform.position);
            tracer.SetPosition(1, this.transform.position + hitPoint);

            yield return null;
            tracer.enabled = false;
        }*/



        /* DEBUG */

        void Debug_ShowSpread()
        {
            Transform BEP = _primaryWeapon.bulletEjectionPoint;
            float range = _primaryWeapon.GetRange();
            float ang = _primaryWeapon.GetSpread()/2f;

            Vector3 ODir = BEP.forward;

            Vector3 RDir = Quaternion.Euler(0, ang, 0) * ODir;
            Vector3 LDir = Quaternion.Euler(0, -ang, 0) * ODir;
            

            //Perfect Shot
            Ray rayC = new Ray(BEP.position, ODir);

            //Far Right
            Ray rayR = new Ray(BEP.position, RDir);

            //Far Left
            Ray rayL = new Ray(BEP.position, LDir);

            


            //Debug.DrawRay(rayC.origin, rayC.direction * range, Color.green);
            Debug.DrawRay(rayR.origin, rayR.direction * range, Color.blue);
            Debug.DrawRay(rayL.origin, rayL.direction * range, Color.blue);
        }
    }
}
