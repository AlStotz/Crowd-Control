using Assets.Scripts.Player.Shootable;

namespace Assets.Scripts.Items.Weapons
{
    public class SMG : WeaponProperties
    {
        public SMG()
            : base("P90", "Short Range Sub Machine Gun", AmmoType.Bullet, 0.5f, true, false, false, RateOfFire.Auto, true, 120.0f, 30.0f, 80.0f, 1000, 2000, 50, 1.0f, 2.5f, 7.5f)
        {

        }

        #region Private Methods
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods
    }
}