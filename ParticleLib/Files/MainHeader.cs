namespace ParticleLib.Files
{
    public unsafe class MainHeader : FileData
    {
        public MainHeader(FileStream file) : base(file, 0)
        {

        }

        public string Identifier
        {
            get { return GetString(0, 4); }
        }

        public ushort ByteOrderMark
        {
            get { return GetUShort(0x4, Endianness.BIG); }
        }

        public ushort Version
        {
            get { return GetUShort(0x6, Endianness.BIG); }
        }

        public uint Length
        {
            get { return GetUInt(0x8, Endianness.BIG); }
        }

        public ushort Size
        {
            get { return GetUShort(0xC, Endianness.BIG); }
        }

        public ushort Blocks
        {
            get { return GetUShort(0xE, Endianness.BIG); }
        }

    }
}
