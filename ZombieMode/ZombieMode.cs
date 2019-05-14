using Smod2;
using Smod2.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualBrightPlayz.SCPSL.ZombieMode
{
    [PluginDetails(author = "VirtualBrightPlayz",
        description = "When someone is killed, they turn into the class of the person that killed them.",
        id = "virtualbrightplayz.scpsl.ZombieMode",
        name = "Zombie Mode (Requested by: Kayckbr#7361)",
        version = "1.0",
        SmodMajor = 3,
        SmodMinor = 0,
        SmodRevision = 0)]
    public class ZombieMode : Plugin
    {
        public override void OnDisable()
        {
        }

        public override void OnEnable()
        {
        }

        public override void Register()
        {
            this.AddEventHandlers(new ZombieModeEventHandler(this));
        }
    }
}
