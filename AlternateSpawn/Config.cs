using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace AlternateSpawn
{
    public class Config : IConfig
    {
        [Description("Will the plugin run?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Will the plugin print Debug Text?")]
        public bool Debug { get; set; } = false;

        [Description("Chance for alternate spawn to happen as a percentage.")]
        public int chance { get; set; } = 75;

        [Description("Valid rooms for alternate spawn.")]
        public List<RoomType> SpawningLocations { get; set; } = new List<RoomType>()
        {
            RoomType.EzVent
        };

        [Description("Apply to NTF.")]
        public bool ForNtf { get; set; } = false;

        [Description("Apply to CI.")]
        public bool ForCi { get; set; } = true;
    }
}
