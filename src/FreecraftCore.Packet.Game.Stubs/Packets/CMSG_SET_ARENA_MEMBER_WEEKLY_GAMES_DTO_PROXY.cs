using FreecraftCore;
using FreecraftCore.Serializer;

[GamePayloadOperationCodeAttribute(NetworkOperationCode.CMSG_SET_ARENA_MEMBER_WEEKLY_GAMES)]
[WireDataContractAttribute]
public sealed class CMSG_SET_ARENA_MEMBER_WEEKLY_GAMES_DTO_PROXY : GamePacketPayload, IUnimplementedGamePacketPayload
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

    public CMSG_SET_ARENA_MEMBER_WEEKLY_GAMES_DTO_PROXY()
    {
    }
}