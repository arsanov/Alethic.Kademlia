﻿using MessagePack;

namespace Cogito.Kademlia.MessagePack.Structures
{

    [MessagePackObject]
    public class PingRequest : Request
    {

        [Key(0)]
        public IpEndpoint[] Endpoints { get; set; }

    }

}