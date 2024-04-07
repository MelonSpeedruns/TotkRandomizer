using SarcLibrary;
using ZstdSharp;

namespace TotkRSTB
{
    //Core code from https://github.com/EXKing-Editor/EXKing-Editor/blob/master/src/ExKingEditor.Core/Models/HashTable.cs
    public static class HashTable
    {
        public static Decompressor _commonDecompressorOther = new();
        public static Compressor _commonCompressorOther = new(16);

        public static Decompressor _commonDecompressor = new();
        public static Compressor _commonCompressor = new(16);

        public static Decompressor _mapDecompressor = new();
        public static Compressor _mapCompressor = new(16);

        private static Sarc sarcFile;

        private static Dictionary<uint, string> _hashStringList { get; } = new();
        private static Dictionary<string, uint> _stringHashList { get; } = new();

        public static Dictionary<uint, string> Strings => _hashStringList;
        public static Dictionary<string, uint> Hashes => _stringHashList;

        public static void InitHashTable(string dicPath)
        {
            Span<byte> data = _commonDecompressor.Unwrap(File.ReadAllBytes(dicPath));
            sarcFile = Sarc.FromBinary(data.ToArray());

            _commonDecompressor.LoadDictionary(sarcFile["pack.zsdic"]);
            _commonCompressor.LoadDictionary(sarcFile["pack.zsdic"]);

            _commonDecompressorOther.LoadDictionary(sarcFile["zs.zsdic"]);

            _mapDecompressor.LoadDictionary(sarcFile["bcett.byml.zsdic"]);
            _mapCompressor.LoadDictionary(sarcFile["bcett.byml.zsdic"]);
        }

        public static byte[] DecompressFile(byte[] data)
        {
            return _commonDecompressor.Unwrap(data).ToArray();
        }

        public static byte[] DecompressFile(string file)
        {
            Span<byte> src = File.ReadAllBytes(file);
            return _commonDecompressor.Unwrap(src).ToArray();
        }

        public static byte[] CompressDataOther(byte[] file)
        {
            Span<byte> src = file;
            return _commonCompressorOther.Wrap(src).ToArray();
        }

        public static byte[] DecompressDataOther(byte[] data)
        {
            return _commonDecompressorOther.Unwrap(data).ToArray();
        }

        public static byte[] CompressData(byte[] file)
        {
            Span<byte> src = file;
            return _commonCompressor.Wrap(src).ToArray();
        }

        public static byte[] DecompressMapData(byte[] data)
        {
            return _mapDecompressor.Unwrap(data).ToArray();
        }

        public static byte[] CompressMapData(byte[] file)
        {
            Span<byte> src = file;
            return _mapCompressor.Wrap(src).ToArray();
        }
    }
}