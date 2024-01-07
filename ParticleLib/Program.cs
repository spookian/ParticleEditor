using ParticleLib.Files;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(File.Exists("E:\\rtdl effect animations to be analyzed\\CommonAbilityGet\\PtCommon.breff"));
        var file = File.OpenRead("E:\\rtdl effect animations to be analyzed\\CommonAbilityGet\\PtCommon.breff");

        FileCore brefile = new FileCore(file);
        if (brefile.valid)
        {
            for(int i = 0; i < brefile.blocks[0].Subfiles.Length; i++)
            {
                Console.WriteLine(brefile.blocks[0].Subfiles[i].Name);
            }    
        }
    }
}