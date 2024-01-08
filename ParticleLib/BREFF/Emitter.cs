using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleLib.FileTypes
{
    public enum DrawFlags
    {
        ENABLE_Z_COMPARE = 1,
        ENABLE_Z_UPDATE = 2,
        COMPARE_ALPHA_PRE_TEX = 4,
        DISABLE_ALPHA_CLIP = 8,
        ENABLE_TEXTURE_1 = 16,
        ENABLE_TEXTURE_2 = 32,
        ENABLE_INDIRECT_TEX = 64,
        PROJECT_TEXTURE_1 = 128,
        PROJECT_TEXTURE_2 = 256,
        PROJECT_INDIRECT_TEX = 512,
        NO_DRAW = 1024,
        REVERSE_DRAW_ORDER = 2048,
        ENABLE_FOG = 4096,
        XYLINKSIZE = 8192,
        XYLINKSCALE = 16384,
    }
    public unsafe struct Emitter
    {
        public fixed byte unk00[4];
        public fixed byte emitterFlags[3]; // three bytes
        public byte emitterShape;
        public ushort emitterLife;
        public ushort particleLife;
        public byte particleLifeRandom;
        public bool inheritChildTranslation;
        public byte emitIntervalRandom;
        public byte emitRandom;
        public float emitRate;
        public ushort emitStart;
        public ushort emitEnd; // frames? seconds?
        public ushort emitInterval;
        public bool inheritParticleTranslation;
        public bool inheritCEmitterTranslation; // inherit child emitter translation?
        public float[] emitterDimensions;
        public ushort emitDiversion; // i am just as confused as you
        public byte velocityRandom;
        public byte momentumRandom;
        public float powerRadiation;
        public float powerYAxis;
        public float powerRandom;
        public float powerNormal;
        public float diffusionNormal;
        public float powerSpec;
        public float diffusionSpec;
        public fixed float emissionAngle[3];
        public fixed float scale[3];
        public fixed float rotation[3];
        public fixed float translation[3];
        public byte nearLODDistance;
        public byte farLODDistance;
        public byte minimalLODEmit;
        public byte alphaLOD;
        public uint randSeed; // the random seed
        public fixed byte unk01[8];
        public ushort drawFlags;
        public byte alphaComp0;
        public byte alphaComp1;
        public byte alphaCompOp;
        public byte numTEVStages;
        public byte unk02;
        public byte indirectTEVStages; // bitwise thing

        public fixed byte textureTEV[4];
        public fixed byte colorTEVSources[4*4]; //4x4 array
        public fixed byte colorTEVStages[4 * 5];
        public fixed byte alphaTEVSources[4 * 4];
        public fixed byte alphaTEVStages[4 * 5];
        public fixed byte constantClr[4];
        public fixed byte constantAlpha[4];
        public byte blendType;
        public byte blendSrcFactor;
        public byte blendDstFactor;
        public byte blendOperation;
        public fixed byte particleClr[8];
        public fixed byte particleAlpha[8];
        public byte zCompFunc;
        public byte alphaFlick;
        public ushort alphaFlickLength;
        public byte alphaFlickAmplitude;
        public byte lightMode; //0x109 of subfile
        public byte lightType;
        public fixed byte lightAmbientClr[4];
        public fixed byte lightDiffuseClr[4];
        public float lightRadius;
        public fixed float lightPosition[3];
        public fixed float indirectTexMatrix[2 * 3];
        public sbyte indirectTexMatScale;
        public sbyte pivotX;
        public sbyte pivotY;
        public byte unk03;
        public byte particleType;
        public byte particleTypeOption;
        public byte movementDirection;
        public byte rotationAxis;
        public byte particleTypeOption2;
        public byte particleTypeOption3;
        public byte particleTypeOption4;
        public byte unk04;
        public float zOffset;

        public static Emitter CreateEmitter(BREFF subfile)
        {
            return new Emitter();
        }
    }
}
