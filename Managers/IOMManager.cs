using wManager.Wow.ObjectManager;

namespace ProductTutorial.Managers
{
    public interface IOMManager : ICycleable
    {
        bool IsLeaderInOMRange { get; }
        WoWPlayer LeaderUnit { get; }
        bool IsLeaderInSettingsRange { get; }
        bool IsLeaderAttackingTarget { get; }
    }
}
