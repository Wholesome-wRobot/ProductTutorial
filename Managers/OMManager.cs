using wManager.Events;
using wManager.Wow.ObjectManager;

namespace ProductTutorial.Managers
{
    public class OMManager : IOMManager
    {
        private string _leaderName;

        public bool IsLeaderInOMRange => LeaderUnit != null;
        public bool IsLeaderAttackingTarget =>
            IsLeaderInOMRange
            && LeaderUnit.HasTarget
            && LeaderUnit.TargetObject.IsAttackable
            && LeaderUnit.TargetObject.Target == LeaderUnit.Guid;
        public bool IsLeaderInSettingsRange => 
            IsLeaderInOMRange 
            && LeaderUnit.Position.DistanceTo(ObjectManager.Me.Position) <= ProductTutorialSettings.CurrentSettings.FollowDistance;
        public WoWPlayer LeaderUnit { get; private set; }

        public void Initialize()
        {
            _leaderName = ProductTutorialSettings.CurrentSettings.LeaderName.Trim().ToLower();
            ObjectManagerEvents.OnObjectManagerPulsed += OnObjectManagerPulse;
        }

        public void Dispose()
        {
            ObjectManagerEvents.OnObjectManagerPulsed -= OnObjectManagerPulse;
        }

        private void OnObjectManagerPulse()
        {
            LeaderUnit = ObjectManager.GetObjectWoWPlayer().Find(player => player.Name.ToLower() == _leaderName);
        }
    }
}
