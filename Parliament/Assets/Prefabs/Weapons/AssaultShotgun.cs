using Assets.Scripts.Player.Shootable;

namespace Assets.Scripts.Items.Weapons
{
    public class AssaultShotgun : WeaponProperties
    {
        public AssaultShotgun()
            : base("Assault Shotgun", "Semi-automatic Shotgun", AmmoType.Slug, 1.0f, true, false, true, RateOfFire.Auto, true, 5.0f, 45.0f, 80.0f, 200, 400, 20, 1.5f, 10.0f, 20.0f)
        {

        }

        #region Private Methods
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods
    }
}