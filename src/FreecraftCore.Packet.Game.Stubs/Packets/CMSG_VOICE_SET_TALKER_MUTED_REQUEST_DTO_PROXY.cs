using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_VOICE_SET_TALKER_MUTED_REQUEST)]
[WireDataContractAttribute]
public sealed class CMSG_VOICE_SET_TALKER_MUTED_REQUEST_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_VOICE_SET_TALKER_MUTED_REQUEST_DTO_PROXY()
    {
    }
}