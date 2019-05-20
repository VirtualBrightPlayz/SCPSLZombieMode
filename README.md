# SCPSLZombieMode

Suggested by Discord User: Kayckbr

Just drag and drop! No config files yet.

# Known downsides to the plugin (not all can be fixed)

This plugin iterates over EVERY SINGLE PLAYER EVERY SINGLE FRAME OF THE GAME ON THE SERVER!!!!

This isn't good for huge servers (IDK how many, but possibly 20+ might get laggy, but I honestly don't know), so I will (hopefully) fix this with an update and put it under OnCheckRoundEnd instead of OnUpdate

SCP-079 gets annoying to play when there is 5+ 079s in one round as when there is multiple people on one camera, it gets very buggy.

SCP-096 get annoying to play against when there is more than one of him, so in a future update I will add configs for when killed by SCP-096 what SCP/role/team the killed player turns into. Until then, just disable 096.

SCP-106 can be un-contained by activating the femur breaker and someone dies in the pocket dimension after the femur breaker activates.

SCP-106 has only one portal, but there is a clientside check to teleporting to the portal, so every 106 has to place a portal at some point in order to teleport to the shared portal. (odd, I know)

# Recommended settings:

Lower HP of SCPs to balance the game out.

```
scp049_hp: 100
scp096_hp: 200
scp106_hp: 200
scp173_hp: 350
scp939_53_hp: 200
scp939_89_hp: 200
```

## Know that SCP-079 can get buggy if multiple people are on the same camera

## Know that SCP-096 gets *very* buggy when there is multiple.
