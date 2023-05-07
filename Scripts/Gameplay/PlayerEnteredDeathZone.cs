using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    public class PlayerEnteredDeathZone : Simulation.Event<PlayerEnteredDeathZone> // срабатывает когда игрок касается дедзоны за картой например
    {
        public DeathZone deathzone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            Simulation.Schedule<PlayerDeath>(0);
        }
    }
}