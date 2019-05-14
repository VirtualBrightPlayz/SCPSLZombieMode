using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System.Collections.Generic;

namespace VirtualBrightPlayz.SCPSL.ZombieMode
{
    public class ZombieModeEventHandler : IEventHandlerUpdate, IEventHandlerPlayerDie, IEventHandler079TeslaGate, IEventHandlerPocketDimensionDie
    {
        private ZombieMode zombieMode;
        public Dictionary<string, RespawnData> respawns;

        public class RespawnData
        {
            public Role role;
            public Vector pos;
            public Player killer;
        }

        public ZombieModeEventHandler(ZombieMode zombieMode)
        {
            this.zombieMode = zombieMode;
            respawns = new Dictionary<string, RespawnData>();
        }

        List<Player> PlayersNearTeslaGate(Smod2.API.TeslaGate tgate)
        {
            var players = new List<Player>();
            foreach (Player plr in zombieMode.Server.GetPlayers())
            {
                if (Vector.Distance(plr.GetPosition(), tgate.Position) <= tgate.TriggerDistance)
                    players.Add(plr);
            }
            return players;
        }

        void IEventHandler079TeslaGate.On079TeslaGate(Player079TeslaGateEvent ev)
        {
            List<Player> plrs = PlayersNearTeslaGate(ev.TeslaGate);
            foreach (Player plr in plrs)
            {
                plr.ChangeRole(Role.SCP_079);
            }
        }

        void IEventHandlerPlayerDie.OnPlayerDie(PlayerDeathEvent ev)
        {
            var pos = ev.Player.GetPosition();
            if (ev.Killer.TeamRole.Team == ev.Player.TeamRole.Team)
                return;
            //zombieMode.Info(ev.Killer.SteamId);
            if (ev.Killer.SteamId != string.Empty && ev.Killer.SteamId != ev.Player.SteamId)
            {
                respawns.Add(ev.Player.SteamId, new RespawnData {
                    role = ev.Killer.TeamRole.Role,
                    pos = pos,
                    killer = ev.Killer
                });
            }
        }

        void IEventHandlerPocketDimensionDie.OnPocketDimensionDie(PlayerPocketDimensionDieEvent ev)
        {
            ev.Die = false;
            ev.Player.ChangeRole(Role.SCP_106);
        }

        void IEventHandlerUpdate.OnUpdate(UpdateEvent ev)
        {
            foreach (Player player in zombieMode.Server.GetPlayers())
            {
                if (player.TeamRole.Role == Role.SPECTATOR && respawns.ContainsKey(player.SteamId))
                {
                    player.ChangeRole(respawns[player.SteamId].role);
                    player.Teleport(respawns[player.SteamId].pos);
                }
                else if (player.TeamRole.Role != Role.SPECTATOR && respawns.ContainsKey(player.SteamId))
                {
                    respawns.Remove(player.SteamId);
                }
            }
        }
    }
}