using ProductTutorial.Managers;
using ProductTutorial.States;
using robotManager.FiniteStateMachine;
using robotManager.Helpful;
using System;
using System.Linq;
using wManager.Wow.Bot.States;

namespace ProductTutorial
{
    internal class TutorialBot
    {
        private readonly Engine _fsm = new Engine();
        private IOMManager _omManager;

        public bool FsmSetup()
        {
            try
            {
                _omManager = new OMManager();
                _omManager.Initialize();

                _fsm.States.Clear();

                State[] states = new State[]
                {
                    new Relogger(),
                    new Pause(),
                    new Resurrect(),
                    new MyMacro(),
                    new Regeneration(),
                    new AssistLeader(_omManager),
                    new StopInLeaderRange(_omManager),
                    new FollowLeader(_omManager),
                    new Idle(),
                };

                states = states.Reverse().ToArray();

                for (int i = 0; i < states.Length; i++)
                {
                    states[i].Priority = i;
                    _fsm.AddState(states[i]);
                }

                _fsm.States.Sort();
                _fsm.StartEngine(10, "_TutorialBot");

                StopBotIf.LaunchNewThread();
                return true;

            }
            catch (Exception ex)
            {
                Logging.WriteError("FsmSetup():" + ex);
                Dispose();
                return false;
            }
        }

        public void Dispose()
        {
            _omManager.Dispose();
            _fsm.StopEngine();
        }
    }
}
