using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using UnityEngine;

namespace PlTpAllPlayers
{
    internal class PTAPCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Both;
        public string Name => "TpAll";
        public string Help => "tpall per count time";
        public string Syntax => "/tpall";
        public List<string> Aliases => new List<string>() { "ta","at" };
        public List<string> Permissions => new List<string>() { "perm_tpall" };

        
        private PTAPConfig configuration
        {
            get
            {
                return PlTpAllPlayers.Instance.Configuration.Instance;
            }
        }   //поле, укороченный путь

        public void Execute(IRocketPlayer caller, string[] command)
        {
            foreach (SteamPlayer steamPlayer in Provider.clients)
            {
                UnturnedPlayer targetPlayer = UnturnedPlayer.FromSteamPlayer(steamPlayer);

                Vector3 tpPos = new Vector3(configuration.xPos, configuration.yPos, configuration.zPos);

                targetPlayer.Teleport(tpPos, targetPlayer.Rotation);
            }
        }
    }
}
