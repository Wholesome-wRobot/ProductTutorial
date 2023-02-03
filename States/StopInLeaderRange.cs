using ProductTutorial.Managers;
using robotManager.FiniteStateMachine;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace ProductTutorial.States
{
    internal class StopInLeaderRange : State
    {
        private readonly IOMManager _omManager;
        public override string DisplayName => "Stop in Leader range";

        public StopInLeaderRange(IOMManager omManager)
        {
            _omManager = omManager;
        }

        public override bool NeedToRun
        {
            get
            {
                if (!ObjectManager.Me.IsValid)
                {
                    return false;
                }

                if (_omManager.IsLeaderInOMRange
                    && _omManager.IsLeaderInSettingsRange
                    && MovementManager.InMovement)
                {
                    return true;
                }

                return false;
            }
        }

        public override void Run()
        {
            MovementManager.StopMove();
        }
    }
}
