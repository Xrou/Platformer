using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    public class PlayerEnteredVictoryZone : Simulation.Event<PlayerEnteredVictoryZone> // срабатывает когда игрок заходит в победную зону (в домик)
    {
        public VictoryZone victoryZone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            model.player.animator.SetTrigger("victory");
            model.player.controlEnabled = false;
        }
    }
}