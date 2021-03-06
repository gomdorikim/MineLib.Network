using MineLib.Network.IO;


namespace MineLib.Network.Packets.Client
{
    public struct UseEntityPacket : IPacket
    {
        public int Target;
        public byte Mouse;

        public const byte PacketID = 0x02;
        public byte Id { get { return PacketID; } }

        public void ReadPacket(ref Wrapped stream)
        {
            Target = stream.ReadInt();
            Mouse = stream.ReadByte();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(Target);
            stream.WriteByte(Mouse);
            stream.Purge();
        }
    }
}