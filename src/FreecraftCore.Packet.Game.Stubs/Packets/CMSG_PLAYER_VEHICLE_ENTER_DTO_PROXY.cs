using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_PLAYER_VEHICLE_ENTER)]
[WireDataContractAttribute]
public sealed class CMSG_PLAYER_VEHICLE_ENTER_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_PLAYER_VEHICLE_ENTER_DTO_PROXY()
    {
    }
}