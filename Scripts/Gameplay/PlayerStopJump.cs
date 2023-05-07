using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    public class PlayerStopJump : Simulation.Event<PlayerStopJump> // срабатывает когда игрок отпускает кнопку прыжка, ускорение не подается
    {
        public PlayerController player;

        public override void Execute()
        {

        }
    }
}