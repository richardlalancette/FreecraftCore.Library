using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_LFD_PARTY_LOCK_INFO_REQUEST)]
[WireDataContractAttribute]
public sealed class CMSG_LFD_PARTY_LOCK_INFO_REQUEST_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_LFD_PARTY_LOCK_INFO_REQUEST_DTO_PROXY()
    {
    }
}