using Rocket.API;
using Rocket.Core;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using System.Threading;
using UnityEngine;

namespace PlTpAllPlayers
{
    public class PlTpAllPlayers : RocketPlugin <PTAPConfig>
    {
        public static PlTpAllPlayers Instance;
        private readonly static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private static float _lastTime;

        protected override void Load()
        {
            Instance = this;
        }
        
        protected override void Unload()
        {
            Instance = null;
        }

        private void FixedUpdate()
        {
            if ((Time.realtimeSinceStartup - _lastTime) > PlTpAllPlayers.Instance.Configuration.Instance.timeCount)
            {
                _lastTime = Time.realtimeSinceStartup;
                R.Commands.Execute(new ConsolePlayer(), "/tpall");
                UnturnedChat.Say("Все собраны в одном месте для аморальных утех", Color.red);
            }
        }
    }
}