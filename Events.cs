using BfevLibrary;
using Newtonsoft.Json;
using TotkRSTB;

namespace TotkRandomizer
{
    public static class Events
    {
        private static int GetEventId(dynamic jsonEvent, string eventTitle, string eventName)
        {
            foreach (dynamic a in jsonEvent["Flowcharts"][eventTitle]["Events"])
            {
                if (a["Name"] == eventName)
                {
                    return jsonEvent["Flowcharts"][eventTitle]["Events"].IndexOf(a);
                }
            }

            return -1;
        }

        public static byte[] EditOpeningEvent(string filePath)
        {
            BfevFile bfev = BfevFile.FromBinary(HashTable.DecompressDataOther(File.ReadAllBytes(filePath)));

            string jsonString = bfev.ToJson();
            dynamic? jsonEvent = JsonConvert.DeserializeObject(jsonString);

            if (jsonEvent != null)
            {
                // Change opening with Zelda walking to the waking up Ganondorf section
                int event75Id = GetEventId(jsonEvent, "OpeningEvent", "Event75");
                jsonEvent["Flowcharts"]["OpeningEvent"]["EntryPoints"]["IntroductionOpening"]["EventIndex"] = event75Id;

                // Remove fade-in to allow loading screen to remain black
                int event77Id = GetEventId(jsonEvent, "OpeningEvent", "Event77");
                jsonEvent["Flowcharts"]["OpeningEvent"]["Events"][event77Id]["Parameters"]["IsStartOnEvent"]["Bool"] = false;
                jsonEvent["Flowcharts"]["OpeningEvent"]["Events"][event77Id]["Parameters"]["BootEventName"]["String"] = "";
            }

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
            dynamic? jsonEvent = JsonConvert.DeserializeObject(jsonString);

            if (jsonEvent != null)
            {
                // Remove giving the Light Orb to Link
                int event4Id = GetEventId(jsonEvent, "DmF_SY_SmallDungeonGoal", "Event4");
                int event52Id = GetEventId(jsonEvent, "DmF_SY_SmallDungeonGoal", "Event52");
                jsonEvent["Flowcharts"]["DmF_SY_SmallDungeonGoal"]["Events"][event4Id]["NextEventIndex"] = event52Id;
                jsonEvent["Flowcharts"]["DmF_SY_SmallDungeonGoal"]["Events"][event4Id]["NextEventName"] = "Event52";
            }

            jsonString = JsonConvert.SerializeObject(jsonEvent, Formatting.Indented);
            bfev = BfevFile.FromJson(jsonString);

            byte[] modifiedData = HashTable.CompressDataOther(bfev.ToBinary());
            File.WriteAllBytes(filePath, modifiedData);
            return modifiedData;
        }
    }
}