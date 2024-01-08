using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleLib.FileTypes
{
    public class Particle : Files.FileData
    {
        Particle(FileStream file, uint offset) : base(file, offset)
        {

        }
    }
}
