using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_CHANNEL_UNSILENCE_ALL)]
[WireDataContractAttribute]
public sealed class CMSG_CHANNEL_UNSILENCE_ALL_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
{
    [ReadToEndAttribute]
    [WireMemberAttribute(1)]
    private byte[] _Data;
    public byte[] Data
    {
        get
        {
            return _Data;
        }

        set
        {
            _Data = value;
        }
    }

    public CMSG_CHANNEL_UNSILENCE_ALL_DTO_PROXY()
    {
    }
}