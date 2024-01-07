namespace ParticleLib.Files
{
    public class BlockHeader : FileData
    {
        FileType type;
        ProjectHeader project;
        SubfileTable subfiles;

        const int headerSize = 0x8;

        public BlockHeader(FileStream file, uint offset) : base(file, offset) 
        {
            project = new ProjectHeader(file, offset + headerSize);
            subfiles = new SubfileTable(file, offset + headerSize + project.Size);

            if (Identifier == "REFT") type = FileType.BREFT;
            else type = FileType.BREFF;
        }

        public string Identifier
        {
            get 
            {
                return GetString(0, 4);
            }
        }

        public uint Size // Length of the entire block in bytes.
        {
            get
            {
                return GetUInt(0x4, Endianness.BIG);
            }
        }
    }

    public class ProjectHeader : FileData
    {
        public ProjectHeader(FileStream file, uint offset) : base(file, offset)
        {

        }

        public uint Size
        {
            get { return GetUInt(0, Endianness.BIG); }
        }

        public string Name
        {
            get
            {
                ushort length = GetUShort(0x0C, Endianness.BIG);
                return GetString(0x0E, length);
            }
        }
    }
}
