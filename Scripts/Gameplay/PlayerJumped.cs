using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    public class PlayerJumped : Simulation.Event<PlayerJumped> // срабатывает когда игрок прыгает
    {
        public PlayerController player;

        public override void Execute()
        {
            if (player.audioSource && player.jumpAudio)
                player.audioSource.PlayOneShot(player.jumpAudio);
        }
    }
}