using System;
using System.Buffers.Binary;

namespace ParticleLib.Files
{
    public enum FileType
    {
        BREFF = 0,
        BREFT
    }

    public enum Endianness
    {
        LITTLE = 0,
        BIG = 1
    }

    public class FileCore
    {
        FileStream _f;

        public MainHeader header;
        public BlockHeader[] blocks;

        public bool valid;

        public FileCore(FileStream f) // Please pass a FileStream object with reading permissions.
        {
            _f = f;
            header = new MainHeader(f);

            if (header.Identifier != "REFF" && header.Identifier != "REFT")
            {
                valid = false;
                return;
            }

            valid = true;
            blocks = new BlockHeader[header.Blocks];
            uint append = header.Size;

            for (int i = 0; i < header.Blocks; i++)
            {
                blocks[i] = new BlockHeader(f, append);
                append += blocks[i].Size;
            }

            return;
        }
    }

    public class FileData
    {
        protected FileStream _base;
        protected uint _offset;

        protected byte[] GetBytes(int size, uint offset)
        {
            byte[] bytes = new byte[size];
            uint n_offset = offset + _offset;

            _base.Seek(n_offset, SeekOrigin.Begin);
            _base.Read(bytes, 0, size);
            _base.Seek(0, SeekOrigin.Begin);

            return bytes;
        }

        protected ushort GetUShort(uint offset, Endianness e)
        {
            ushort result = BitConverter.ToUInt16(GetBytes(2, offset), 0);
            if (e == Endianness.BIG) return BinaryPrimitives.ReverseEndianness(result);
            return result;
        }

        protected uint GetUInt(uint offset, Endianness e)
        {
            uint result = BitConverter.ToUInt32(GetBytes(4, offset), 0);
            if (e == Endianness.BIG) return BinaryPrimitives.ReverseEndianness(result);
            return result;
        }

        protected string GetString(uint offset, uint length)
        {
            string result = System.Text.Encoding.UTF8.GetString(GetBytes((int)length, offset), 0, (int)length);
            return result;
        }

        public FileData(FileStream file, uint offset)
        {
            _base = file;
            _offset = offset;
        }

        public FileStream File { get { return _base; } }
    }
}
