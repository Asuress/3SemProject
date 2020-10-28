using WPF_Game.Source.Logic;
using WPF_Game.Source.Main;

namespace WPF_Game.Source.Components
{
    class Physics : GameManager, IComponent
    {
        public enum Mode
        {
            Force,
            Impulse
        }
        public Physics(GameObject parent)
        {
            this.parent = parent;
        }

        double friction;
        GameObject parent;
        Vector2 forceSummary;

        public void AddForce(Vector2 force, Mode mode)
        {
            switch (mode)
            {
                case Mode.Force:
                    break;
                case Mode.Impulse:
                    forceSummary += force;
                    break;
                default:
                    break;
            }
        }

        protected override void EarlyUpdate()
        {
            
        }
    }
}
