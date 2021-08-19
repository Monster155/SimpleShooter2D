namespace Game.CharacterScripts.Weapons
{
    public class MainFireWeapon : FireWeapon
    {
        private void Reset()
        {
            _bulletsCountInQueue = 0;
            _ammoInClipCount = 30;
            _leftAmmoCount = 90;
            _fireRateInSeconds = 0.1f;
            _reloadTime = 2.5f;
            _queueReloadTime = 0f;
        }
    }
}