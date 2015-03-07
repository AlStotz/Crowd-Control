using System.Collections;
using System.Xml;
using Assets.Scripts.Player.Shootable;
using UnityEngine;

namespace Assets.Scripts.Player.Handlers
{
    public class WeaponHandler : MonoBehaviour
    {
        #region Fields

        private LineRenderer tracer;

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

            if (GetComponent<LineRenderer>())
            {
                tracer = GetComponent<LineRenderer>();
            }
        }
	
        // Update is called once per frame
        void Update ()
        {
            playerPos = this.gameObject.transform.position;
            mousePos = Cursor.GetLocalMouseLocationRelativeTo(this.gameObject.transform.localPosition);

            CheckReloadTimer();
            CheckFireTimer();
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
            _primaryWeapon.Fire();

            float shotDistance = _primaryWeapon.GetRange();
            // This works... For some reason.
            //Debug.DrawLine(playerPos, mousePos);

            Ray ray = new Ray(_primaryWeapon.bulletEjectionPoint.position, _primaryWeapon.bulletEjectionPoint.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, shotDistance))
            {
                shotDistance = hit.distance;
                // Check for hit
                if (hit.collider.GetComponent<Entity>())
                {
                    // Apply damage to what was hit.
                    hit.collider.GetComponent<Entity>().TakeDamage(_primaryWeapon.GetDamage());
                }
            }

            if (_primaryWeapon.GetTracer())
            {
                StartCoroutine("RenderTracer", ray.direction*shotDistance);
            }

            // Eject new Shell after shot
            Rigidbody newShell =
                Instantiate(_primaryWeapon.shell, _primaryWeapon.shellEjectionPoint.position, Quaternion.identity) as
                    Rigidbody;
            newShell.AddForce(_primaryWeapon.shellEjectionPoint.forward * Random.Range(150f,200f) + _primaryWeapon.bulletEjectionPoint.forward * Random.Range(-10f,10f));

            Debug.DrawRay(ray.origin, ray.direction * shotDistance, Color.red, 1);
            
            Debug.Log("BANG");

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
        

            GUI.Box(new Rect(Screen.width-155, 5, 150, 300), str);
            GUI.Box(new Rect(Screen.width - 205, Screen.height - 105, 200, 100), debugStr);
        }

        /* ENUMS */

        IEnumerator RenderTracer(Vector3 hitPoint)
        {
            tracer.enabled = true;
            tracer.SetPosition(0, this.transform.position);
            tracer.SetPosition(1, this.transform.position + hitPoint);

            yield return null;
            tracer.enabled = false;
        }
    }
}
