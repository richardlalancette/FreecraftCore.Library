using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_EQUIPMENT_SET_SAVE)]
[WireDataContractAttribute]
public sealed class CMSG_EQUIPMENT_SET_SAVE_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_EQUIPMENT_SET_SAVE_DTO_PROXY()
    {
    }
}