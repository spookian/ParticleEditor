namespace ParticleLib.Files
{
    public class Subfile : FileData
    {
        protected uint _strlen;
        protected SubfileTable _table;
        protected byte[] _data;
        public Subfile(FileStream file, uint offset, SubfileTable table) : base(file, offset)
        {
            _strlen = GetUShort(0, Endianness.BIG);
            _table = table;
        }

        public string Name
        {
            get
            {
                return GetString(0x2, _strlen);
            }
        }

        public uint Size
        {
            get
            {
                return GetUInt(0x06 + _strlen, Endianness.BIG);
            }
        }

        public uint Offset
        {
            get
            {
                return GetUInt(0x02 + _strlen, Endianness.BIG);
            }
        }
    }
}
