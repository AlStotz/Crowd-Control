using Assets.Scripts.Player.Shootable;

namespace Assets.Scripts.Items.Weapons
{
    public class SniperRifle : WeaponProperties
    {
        public SniperRifle()
            : base("Sniper Rifle","Long Range Bolt Action Sniper Rifle",AmmoType.Bullet, 1.0f,false,false,true,RateOfFire.Single,true,500.0f,2.0f,80.0f,40,100,10,1.0f,50.0f,210.0f)
        {

        }

        #region Private Methods
        #endregion Private Methods

        #region Public Methods
        #endregion Public Methods
    }
}