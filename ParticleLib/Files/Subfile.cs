namespace ParticleLib.Files
{
    public class Subfile : FileData
    {
        protected uint _strlen;
        protected string _fileName;
        protected uint _fileSize;
        protected uint _offset;
        public Subfile(FileStream file, uint offset) : base(file, offset)
        {
            _strlen = GetUShort(0, Endianness.BIG);
            _fileName = GetString(0x2, _strlen);
            _fileSize = GetUInt(0x06 + _strlen, Endianness.BIG);
            _offset = GetUInt(0x02 + _strlen, Endianness.BIG);
        }

        public string Name
        {
            get
            {
                return _fileName;
            }
        }

        public uint Size
        {
            get
            {
                return _fileSize;
            }
        }

        public uint Offset
        {
            get
            {
                return _offset;
            }
        }
    }
}
