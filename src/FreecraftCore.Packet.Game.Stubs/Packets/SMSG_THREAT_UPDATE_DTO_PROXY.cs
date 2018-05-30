using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_THREAT_UPDATE)]
[WireDataContractAttribute]
public sealed class SMSG_THREAT_UPDATE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
{
    [ReadToEndAttribute]
    [WireMemberAttribute(1)]
    private byte[] _Data;
    public byte[] Data
    {
        get
        {
            return Data;
        }

        set
        {
            Data = value;
        }
    }

    public SMSG_THREAT_UPDATE_DTO_PROXY()
    {
    }
}