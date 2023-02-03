using ProductTutorial.Managers;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using System.Collections.Generic;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace ProductTutorial.States
{
    internal class FollowLeader : State
    {
        private readonly IOMManager _omManager;
        public override string DisplayName => "Follow Leader";

        public FollowLeader(IOMManager omManager)
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
                    && !_omManager.IsLeaderInSettingsRange)
                {
                    return true;
                }

                return false;
            }
        }

        public override void Run()
        {
            if (!MovementManager.InMovement)
            {
                List<Vector3> pathToLeader = PathFinder.FindPath(_omManager.LeaderUnit.Position);
                MovementManager.Go(pathToLeader);
            }
        }
    }
}
