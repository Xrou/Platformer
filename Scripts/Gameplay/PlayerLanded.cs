using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    //TODO: можно добавить анимацию приземления если не впдалу, но сроки горят по этому ну его
    public class PlayerLanded : Simulation.Event<PlayerLanded>  //срабатывает когда игрок приземляется
    {
        public PlayerController player;

        public override void Execute()
        {

        }
    }
}