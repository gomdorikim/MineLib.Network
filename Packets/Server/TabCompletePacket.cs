using MineLib.Network.IO;


namespace MineLib.Network.Packets.Server
{
    public struct TabCompletePacket : IPacket
    {
        public int Count;
        public string Text;

        public const byte PacketID = 0x3A;
        public byte Id { get { return PacketID; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Count = stream.ReadVarInt();
            Text = stream.ReadString();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteVarInt(Count);
            stream.WriteString(Text);
            stream.Purge();
        }
    }
}