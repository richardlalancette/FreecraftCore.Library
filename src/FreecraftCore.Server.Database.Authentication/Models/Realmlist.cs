﻿using System;
using System.Collections.Generic;

namespace FreecraftCore.Server.Database.Authentication.Models
{
    public partial class Realmlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LocalAddress { get; set; }
        public string LocalSubnetMask { get; set; }
        public short Port { get; set; }
        public byte Icon { get; set; }
        public byte Flag { get; set; }
        public byte Timezone { get; set; }
        public byte AllowedSecurityLevel { get; set; }
        public int Gamebuild { get; set; }
    }
}
