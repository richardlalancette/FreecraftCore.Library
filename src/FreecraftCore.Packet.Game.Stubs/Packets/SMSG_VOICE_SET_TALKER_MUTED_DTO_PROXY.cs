using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_VOICE_SET_TALKER_MUTED)]
[WireDataContractAttribute]
public sealed class SMSG_VOICE_SET_TALKER_MUTED_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_VOICE_SET_TALKER_MUTED_DTO_PROXY()
    {
    }
}