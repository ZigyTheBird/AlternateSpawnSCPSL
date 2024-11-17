using Exiled.API.Enums;
using Exiled.API.Features;
using System;

namespace AlternateSpawn
{
    public class AlternateSpawn : Plugin<Config>
    {
        public override string Name => "AlternateSpawn";
        public override string Author => "ZigyTheBird";
        public override Version Version => new Version(1, 0, 2);

        public override PluginPriority Priority => PluginPriority.Default;

        public static AlternateSpawn Instance { get; set; }
        private Handlers.serverHandler ServerHandler;

        public override void OnEnabled()
        {
            Instance = this;
            ServerHandler = new Handlers.serverHandler();

            Exiled.Events.Handlers.Server.RespawningTeam += ServerHandler.onRespawnWave;
        }
        public override void OnDisabled()
        {
            Instance = null;

            Exiled.Events.Handlers.Server.RespawningTeam -= ServerHandler.onRespawnWave;
        }
    }
}
