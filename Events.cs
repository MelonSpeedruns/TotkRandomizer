using BfevLibrary;
using TotkRSTB;

namespace TotkRandomizer
{
    public static class Events
    {
        public static byte[] EditOpeningEvent(string filePath)
        {
            BfevFile bfev = BfevFile.FromBinary(HashTable.DecompressDataOther(File.ReadAllBytes(filePath)));
            bfev.Flowchart.EntryPoints["IntroductionOpening"].EventIndex = 83;
            byte[] modifiedData = HashTable.CompressDataOther(bfev.ToBinary());
            File.WriteAllBytes(filePath, modifiedData);
            return modifiedData;
        }
    }
}