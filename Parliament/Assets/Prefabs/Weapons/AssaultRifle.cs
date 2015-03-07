using Assets.Scripts.Player.Shootable;

namespace Assets.Scripts.Items.Weapons
{
    public class AssaultRifle : WeaponProperties
    {
        public AssaultRifle()
            : base("Assault Rifle", "Standard Assault Rifle", AmmoType.Bullet, 1.0f, true, true, true, RateOfFire.Single, true, 100.0f, 10.0f, 80.0f, 120, 300, 30, 1.5f, 5.0f, 10.0f)
        {

        }

        #region Private Methods
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods
    }
}