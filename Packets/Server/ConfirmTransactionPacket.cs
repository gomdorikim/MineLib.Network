using MineLib.Network.IO;


namespace MineLib.Network.Packets.Server
{
    public struct ConfirmTransactionPacket : IPacket
    {
        public byte WindowId;
        public short ActionNumber;
        public bool Accepted;

        public const byte PacketID = 0x32;
        public byte Id { get { return PacketID; } }

        public void ReadPacket(ref Wrapped stream)
        {
            WindowId = stream.ReadByte();
            ActionNumber = stream.ReadShort();
            Accepted = stream.ReadBool();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteByte(WindowId);
            stream.WriteShort(ActionNumber);
            stream.WriteBool(Accepted);
            stream.Purge();
        }
    }
}