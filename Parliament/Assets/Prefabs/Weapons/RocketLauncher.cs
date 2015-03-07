using Assets.Scripts.Player.Shootable;
using UnityEngine;

namespace Assets.Scripts.Items.Weapons
{
    public class RocketLauncher : WeaponProperties
    {
        public Rigidbody Projectile;

        public RocketLauncher()
            : base("RPG", "Rocket Launcher", AmmoType.Projectile, 1.0f, false, false, true, RateOfFire.Single, false, 200.0f, 2.0f, 80.0f, 10, 50, 1, 2.0f, 150.0f, 350.0f)
        {

        }

        #region Private Methods
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods
    }
}