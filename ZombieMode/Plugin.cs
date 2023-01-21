using System.Linq;
using PlayerRoles;
using PlayerStatsSystem;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

public class Plugin
{
    [PluginEntryPoint("ZombieMode", "1.0.0.0", "h", "VirtualBrightPlayz")]
    public void Main()
    {
        EventManager.RegisterEvents(this);
    }

    public void Respawn(Player player, Player attacker)
    {
        if (attacker == null)
            return;
        var pos = player.Position;
        var rot = player.Rotation;
        var items = player.Items.Select(x => x.ItemTypeId).ToArray();
        player.SetRole(attacker.Role, RoleChangeReason.Respawn);
        player.ClearInventory();
        player.Position = pos;
        player.Rotation = rot;
        if (attacker.Role.IsHuman())
        {
            foreach (var item in items)
            {
                player.AddItem(item);
            }
        }
    }

    [PluginEvent(ServerEventType.PlayerDying)]
    public bool OnPlayerDying(Player player, Player attacker, DamageHandlerBase damageHandler)
    {
        if (attacker == null)
            return true;
        Respawn(player, attacker);
        return false;
    }

    [PluginEvent(ServerEventType.Scp106TeleportPlayer)]
    public void OnScp106TeleportPlayer(Player player, Player target)
    {
        Respawn(target, player);
    }

    [PluginEvent(ServerEventType.PlayerDamage)]
    public void OnPlayerDamage(Player player, Player attacker, DamageHandlerBase damageHandler)
    {
        switch (player.Role)
        {
            case RoleTypeId.Scp173:
                if (player.Health > 350f)
                    player.Health = 350f;
                break;
            case RoleTypeId.Scp106:
                if (player.Health > 200f)
                    player.Health = 200f;
                break;
            case RoleTypeId.Scp049:
                if (player.Health > 200f)
                    player.Health = 200f;
                break;
            case RoleTypeId.Scp096:
                if (player.Health > 300f)
                    player.Health = 300f;
                break;
            case RoleTypeId.Scp0492:
                if (player.Health > 100f)
                    player.Health = 100f;
                break;
            case RoleTypeId.Scp939:
                if (player.Health > 200f)
                    player.Health = 200f;
                break;
        }
    }

    [PluginEvent(ServerEventType.PlayerSpawn)]
    public void OnPlayerSpawn(Player player, RoleTypeId role)
    {
        player.Health = 100f;
        switch (role)
        {
            case RoleTypeId.Scp173:
            case RoleTypeId.Scp106:
            case RoleTypeId.Scp049:
                break;
            case RoleTypeId.Scp079:
                player.SetRole(RoleTypeId.Scp049, RoleChangeReason.Respawn);
                break;
            case RoleTypeId.Scp096:
            case RoleTypeId.Scp0492:
            case RoleTypeId.Scp939:
                break;
        }
    }
}
