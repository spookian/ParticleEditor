namespace ParticleLib.Files
{
    public class SubfileTable : FileData
    {
        private Subfile[] _files;
        public SubfileTable(FileStream file, uint offset) : base(file, offset)
        {
            ushort file_num = Length;
            _files = new Subfile[file_num];
            uint sub_offset = 0x8;

            for(int i = 0; i < file_num; i++)
            {
                _files[i] = new Subfile(_base, sub_offset + offset);
                int append = _files[i].Name.Length + 0x0A; // 0x2 + 0x4 +0x4
                sub_offset += (uint)append;
            }
        }

        public ushort Length
        {
            get { return GetUShort(0x4, Endianness.BIG); }
        }

        public Subfile this[int index]
        {
            get
            {
                return _files[index];
            }
        }
    }
}
