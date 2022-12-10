using System;

namespace Assets.Scripts.Game
{
    public class PlayerProfile
    {
        public Guid PlayerId { get; }

        public PlayerProfile()
        {
            PlayerId = SystemInfo.GetMachineGuid();
        }
    }
}
