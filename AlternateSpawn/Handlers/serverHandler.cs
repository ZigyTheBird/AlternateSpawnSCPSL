using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using Respawning;

namespace AlternateSpawn.Handlers
{
    public class serverHandler
    {
        public void onRespawnWave(RespawningTeamEventArgs args)
        {
            if (!Warhead.IsDetonated && (args.NextKnownTeam == SpawnableTeamType.ChaosInsurgency && AlternateSpawn.Instance.Config.ForCi) || (args.NextKnownTeam == SpawnableTeamType.NineTailedFox && AlternateSpawn.Instance.Config.ForNtf))
            {
                int randomValue2 = UnityEngine.Random.Range(0, 100);
                Room room;
                room = Room.Get(AlternateSpawn.Instance.Config.SpawningLocations.GetRandomValue());
                if (!room)
                {
                    foreach (RoomType roomType in AlternateSpawn.Instance.Config.SpawningLocations)
                    {
                        room = Room.Get(roomType);
                        if (room)
                        {
                            break;
                        }
                    }
                }

                foreach (Player player in args.Players)
                {
                    if (player != null)
                    {
                        int randomValue = UnityEngine.Random.Range(0, 5);
                        switch(randomValue)
                        {
                            case 0:
                                player.RoleManager.ServerSetRole(PlayerRoles.RoleTypeId.ChaosConscript, PlayerRoles.RoleChangeReason.Respawn);
                                break;
                            case 1:
                                player.RoleManager.ServerSetRole(PlayerRoles.RoleTypeId.ChaosMarauder, PlayerRoles.RoleChangeReason.Respawn);
                                break;
                            case 2:
                                player.RoleManager.ServerSetRole(PlayerRoles.RoleTypeId.ChaosRepressor, PlayerRoles.RoleChangeReason.Respawn);
                                break;
                            case 3:
                                player.RoleManager.ServerSetRole(PlayerRoles.RoleTypeId.ChaosRifleman, PlayerRoles.RoleChangeReason.Respawn);
                                break;
                            default:
                                player.RoleManager.ServerSetRole(PlayerRoles.RoleTypeId.ChaosRifleman, PlayerRoles.RoleChangeReason.Respawn);
                                break;
                        }

                        if (randomValue2 < AlternateSpawn.Instance.Config.chance)
                        {
                            if (room)
                            {
                                player.Teleport(room.Position + new UnityEngine.Vector3(0, 0.5f, 0));
                            }
                        }
                    }
                }
                args.IsAllowed = false;
                args.NextKnownTeam = SpawnableTeamType.None;
            }
        }
    }
}
