using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.SMSG_FORCE_RUN_SPEED_CHANGE)]
[WireDataContractAttribute]
public sealed class SMSG_FORCE_RUN_SPEED_CHANGE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public SMSG_FORCE_RUN_SPEED_CHANGE_DTO_PROXY()
    {
    }
}