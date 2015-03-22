using Assets.Scripts.Player.Shootable;
using UnityEngine;

namespace Assets.Scripts.Items.Weapons
{
    public class LMG : WeaponProperties
    {

        public LMG()
            : base("M240", "Light Machine Gun", AmmoType.Bullet, 20.0f, true, false, false, RateOfFire.Auto, true, 200.0f, 40.0f, 80.0f, 2000, 4000, 200, 2.0f, 5.0f, 12.5f)
        {

        }

        #region Private Methods
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods
    }
}