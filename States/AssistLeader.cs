using ProductTutorial.Managers;
using robotManager.FiniteStateMachine;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace ProductTutorial.States
{
    internal class AssistLeader : State
    {
        private readonly IOMManager _omManager;
        public override string DisplayName => "Assist Leader";

        public AssistLeader(IOMManager omManager)
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

                if (_omManager.IsLeaderAttackingTarget)
                {
                    return true;
                }

                return false;
            }
        }

        public override void Run()
        {
            Fight.StartFight(_omManager.LeaderUnit.TargetObject.Guid);
        }
    }
}
