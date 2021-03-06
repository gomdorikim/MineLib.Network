using MineLib.Network.IO;
using MineLib.Network.Data;


namespace MineLib.Network.Packets.Server
{
    public struct SetSlotPacket : IPacket
    {
        public byte WindowId;
        public short Slot;
        public ItemStack SlotData;

        public const byte PacketID = 0x2F;
        public byte Id { get { return PacketID; } }
    
        public void ReadPacket(ref Wrapped stream)
        {
            WindowId = stream.ReadByte();
            Slot = stream.ReadShort();
            SlotData = ItemStack.FromStream(ref stream);
        }
    
        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteByte(WindowId);
            stream.WriteShort(Slot);
            SlotData.WriteTo(ref stream);
            stream.Purge();
        }
    }
}