using BfevLibrary;
using Newtonsoft.Json;
using TotkRSTB;

namespace TotkRandomizer
{
    public static class Events
    {
        private static void PrintEventId(dynamic jsonEvent, string eventName)
        {
            foreach (dynamic a in jsonEvent["Flowcharts"]["OpeningEvent"]["Events"])
            {
                if (a["Name"] == eventName)
                {
                    Console.WriteLine(jsonEvent["Flowcharts"]["OpeningEvent"]["Events"].IndexOf(a));
                }
            }
        }

        public static byte[] EditOpeningEvent(string filePath)
        {
            BfevFile bfev = BfevFile.FromBinary(HashTable.DecompressDataOther(File.ReadAllBytes(filePath)));

            string jsonString = bfev.ToJson();
            dynamic jsonEvent = JsonConvert.DeserializeObject(jsonString);

            // Change opening with Zelda walking to the waking up Ganondorf section
            jsonEvent["Flowcharts"]["OpeningEvent"]["EntryPoints"]["IntroductionOpening"]["EventIndex"] = 83;

            PrintEventId(jsonEvent, "Event77");

            // Remove fade-in to allow loading screen to remain black
            jsonEvent["Flowcharts"]["OpeningEvent"]["Events"][27]["Parameters"]["IsStartOnEvent"]["Bool"] = false;
            jsonEvent["Flowcharts"]["OpeningEvent"]["Events"][27]["Parameters"]["BootEventName"]["String"] = "";

            jsonString = JsonConvert.SerializeObject(jsonEvent, Formatting.Indented);
            bfev = BfevFile.FromJson(jsonString);

            byte[] modifiedData = HashTable.CompressDataOther(bfev.ToBinary());
            File.WriteAllBytes(filePath, modifiedData);
            return modifiedData;
        }

        public static byte[] EditDungeonGoalEvent(string filePath)
        {
            BfevFile bfev = BfevFile.FromBinary(HashTable.DecompressDataOther(File.ReadAllBytes(filePath)));

            string jsonString = bfev.ToJson();
            dynamic jsonEvent = JsonConvert.DeserializeObject(jsonString);

            // Remove giving the Light Orb to Link
            jsonEvent["Flowcharts"]["DmF_SY_SmallDungeonGoal"]["Events"][46]["NextEventIndex"] = 10;
            jsonEvent["Flowcharts"]["DmF_SY_SmallDungeonGoal"]["Events"][46]["NextEventName"] = "Event52";

            jsonString = JsonConvert.SerializeObject(jsonEvent, Formatting.Indented);
            bfev = BfevFile.FromJson(jsonString);

            byte[] modifiedData = HashTable.CompressDataOther(bfev.ToBinary());
            File.WriteAllBytes(filePath, modifiedData);
            return modifiedData;
        }
    }
}