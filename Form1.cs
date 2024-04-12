using BymlLibrary;
using BymlLibrary.Nodes.Containers;
using Revrs;
using RstbLibrary;
using System.ComponentModel;
using System.Media;
using TotkRSTB;
using static TotkRandomizer.ActorList;

namespace TotkRandomizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            InitializeComponent();

            enemiesBox.SelectedIndex = 1;
            chestsBox.SelectedIndex = 1;
            weaponsBox.SelectedIndex = 1;
            natureBox.SelectedIndex = 1;
            paragliderPatternBox.SelectedIndex = 0;
        }

        private const int GREAT_SKY_ISLANDS_LIGHT_ORBS_COUNT = 4;
        private const int TOTAL_LIGHT_ORBS_COUNT = 152;
        private int currentProgress = 0;
        private static int maxProgress = 0;

        private List<string> SpoilerLog = new List<string>();

        private Dictionary<ulong, string> allGreatSkyIslandsChestContents = new Dictionary<ulong, string>();
        private List<string> allChestContents = new List<string>();

        private static Dictionary<string, uint> rstbModifiedTable = new Dictionary<string, uint>();

        private string randomizerPath;

        private void button1_Click(object sender, EventArgs e)
        {
            currentProgress = 0;
            maxProgress = 0;

            randomizerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "romfs");
            HashTable.InitHashTable(Path.Combine(textBox1.Text, "Pack", "ZsDic.pack.zs"));

            backgroundWorker1.RunWorkerAsync();
            tabControl1.Enabled = false;
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.TopDirectoryOnly))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                maxProgress++;
            }
        }

        private enum EnemyWeaponSet
        {
            LargeSwordOrSpear,
            SwordAndShield,
            BowAndArrows,
        }

        private Byml ReplaceEnemy(Byml actor)
        {
            // Replace Enemy
            string gyamlValue = actor.GetMap()["Gyaml"].GetString();

            if (actor.GetMap().ContainsKey("Dynamic"))
            {
                BymlMap dynamicArray = actor.GetMap()["Dynamic"].GetMap();

                foreach (KeyValuePair<List<string>, List<List<string>>> enemyDictList in EnemyReplaceList)
                {
                    foreach (string enemyList in enemyDictList.Key)
                    {
                        if (gyamlValue.Equals(enemyList))
                        {
                            List<string> enemyTypeList = enemyDictList.Value[RNG.Next(enemyDictList.Value.Count)];
                            string newEnemyName = enemyTypeList[RNG.Next(enemyTypeList.Count)];
                            actor.GetMap()["Gyaml"] = newEnemyName;

                            if (actor.GetMap().ContainsKey("Rails"))
                            {
                                actor.GetMap().Remove("Rails");
                            }

                            // Remove Existing Weapons & Attachments
                            if (dynamicArray.ContainsKey("EquipmentUser_Weapon"))
                            {
                                dynamicArray.Remove("EquipmentUser_Weapon");
                            }

                            if (dynamicArray.ContainsKey("EquipmentUser_Shield"))
                            {
                                dynamicArray.Remove("EquipmentUser_Shield");
                            }

                            if (dynamicArray.ContainsKey("EquipmentUser_Bow"))
                            {
                                dynamicArray.Remove("EquipmentUser_Bow");
                            }

                            if (dynamicArray.ContainsKey("EquipmentUser_Attachment_Weapon"))
                            {
                                dynamicArray.Remove("EquipmentUser_Attachment_Weapon");
                            }

                            if (dynamicArray.ContainsKey("EquipmentUser_Attachment_Shield"))
                            {
                                dynamicArray.Remove("EquipmentUser_Attachment_Shield");
                            }

                            if (dynamicArray.ContainsKey("EquipmentUser_Attachment_Arrow"))
                            {
                                dynamicArray.Remove("EquipmentUser_Attachment_Arrow");
                            }

                            if (dynamicArray.ContainsKey("Equipment_Attachment"))
                            {
                                dynamicArray.Remove("Equipment_Attachment");
                            }

                            if (dynamicArray.ContainsKey("EquipmentUser_Accessory1"))
                            {
                                dynamicArray.Remove("EquipmentUser_Accessory1");
                            }

                            if (dynamicArray.ContainsKey("EquipmentUser_Tool"))
                            {
                                dynamicArray.Remove("EquipmentUser_Tool");
                            }

                            if (dynamicArray.ContainsKey("IsSoundAlarmOnDiscoverBattleTarget"))
                            {
                                dynamicArray.Remove("IsSoundAlarmOnDiscoverBattleTarget");
                            }

                            if (dynamicArray.ContainsKey("IsSoundAlarmOnDiscoverBattleTarget"))
                            {
                                dynamicArray.Remove("IsSoundAlarmOnDiscoverBattleTarget");
                            }

                            if (dynamicArray.ContainsKey("Role"))
                            {
                                dynamicArray.Remove("Role");
                            }

                            if (dynamicArray.ContainsKey("Rider_RidingTarget"))
                            {
                                dynamicArray.Remove("Rider_RidingTarget");
                            }

                            // Add New Weapons & Attachments
                            if (newEnemyName.StartsWith("Enemy_Bokoblin_") ||
                                newEnemyName.StartsWith("Enemy_Zonau_Robot_") ||
                                newEnemyName.StartsWith("Enemy_Horablin_") ||
                                newEnemyName.StartsWith("Enemy_Moriblin_") ||
                                newEnemyName.StartsWith("Enemy_Lizalfos_") ||
                                newEnemyName.StartsWith("Enemy_Lynel_") ||
                                newEnemyName.StartsWith("Enemy_Wizzrobe_"))
                            {
                                Array values = Enum.GetValues(typeof(EnemyWeaponSet));
                                EnemyWeaponSet randomWeaponSet = (EnemyWeaponSet)values.GetValue(RNG.Next(values.Length));

                                switch (randomWeaponSet)
                                {
                                    case EnemyWeaponSet.LargeSwordOrSpear:
                                        TwoHandedWeaponList.Shuffle();
                                        dynamicArray.Add("EquipmentUser_Weapon", TwoHandedWeaponList[0]);

                                        AttachmentList.Shuffle();
                                        dynamicArray.Add("EquipmentUser_Attachment_Weapon", AttachmentList[0]);
                                        break;

                                    case EnemyWeaponSet.SwordAndShield:
                                        OneHandedWeaponList.Shuffle();
                                        dynamicArray.Add("EquipmentUser_Weapon", OneHandedWeaponList[0]);

                                        ShieldList.Shuffle();
                                        dynamicArray.Add("EquipmentUser_Shield", ShieldList[0]);

                                        AttachmentList.Shuffle();
                                        dynamicArray.Add("EquipmentUser_Attachment_Weapon", AttachmentList[0]);

                                        AttachmentList.Shuffle();
                                        dynamicArray.Add("EquipmentUser_Attachment_Shield", AttachmentList[0]);
                                        break;

                                    case EnemyWeaponSet.BowAndArrows:
                                        BowList.Shuffle();
                                        dynamicArray.Add("EquipmentUser_Bow", BowList[0]);

                                        ArrowAttachmentList.Shuffle();
                                        dynamicArray.Add("EquipmentUser_Attachment_Arrow", ArrowAttachmentList[0]);
                                        break;
                                }
                            }

                            return actor;
                        }
                    }
                }
            }

            return actor;
        }

        private Byml ReplaceChest(Byml actor, string mapFile)
        {
            string gyamlValue = actor.GetMap()["Gyaml"].GetString();
            ulong hashValue = actor.GetMap()["Hash"].GetUInt64();

            if (gyamlValue.StartsWith("TBox_"))
            {
                if (actor.GetMap().ContainsKey("Dynamic"))
                {
                    BymlMap dynamicArray = actor.GetMap()["Dynamic"].GetMap();

                    if (dynamicArray.ContainsKey("Drop__DropActor_Attachment"))
                    {
                        actor.GetMap()["Dynamic"].GetMap().Remove("Drop__DropActor_Attachment");
                    }

                    if (dynamicArray.ContainsKey("Drop__DropActor"))
                    {
                        string dropValue = actor.GetMap()["Dynamic"].GetMap()["Drop__DropActor"].GetString();
                        if (dropValue.Equals("KeySmall"))
                        {
                            return actor;
                        }

                        if (IsSkyIslandOrbChest(hashValue))
                        {
                            actor.GetMap()["Dynamic"].GetMap()["Drop__DropActor"] = "Obj_DungeonClearSeal";
                        }
                        else
                        {
                            actor.GetMap()["Dynamic"].GetMap()["Drop__DropActor"] = allChestContents[0];
                            allChestContents.RemoveAt(0);
                        }

                        string newDropActor = actor.GetMap()["Dynamic"].GetMap()["Drop__DropActor"].GetString();

                        SpoilerLog.Add("0x" + hashValue.ToString("X") + " | " + newDropActor);

                        if (newDropActor.StartsWith("Weapon_") && !newDropActor.Contains("_Bow_"))
                        {
                            AttachmentList.Shuffle();

                            if (!dynamicArray.ContainsKey("Drop__DropActor_Attachment"))
                            {
                                actor.GetMap()["Dynamic"].GetMap().Add("Drop__DropActor_Attachment", AttachmentList[0]);
                            }

                            actor.GetMap()["Dynamic"].GetMap()["Drop__DropActor_Attachment"] = AttachmentList[0];
                        }
                    }
                }
            }

            return actor;
        }

        private Byml ReplaceBasics(Byml actor)
        {
            // Replace Basic Objects
            string gyamlValue = actor.GetMap()["Gyaml"].GetString();

            foreach (List<string> basicObjectList in BasicObjectsReplaceList)
            {
                foreach (string basicObject in basicObjectList)
                {
                    if (gyamlValue.Equals(basicObject))
                    {
                        basicObjectList.Shuffle();
                        actor.GetMap()["Gyaml"] = basicObjectList[0];

                        return actor;
                    }
                }
            }

            return actor;
        }

        private Byml ReplaceFloorWeapon(Byml actor)
        {
            // Replace Floor Weapon
            string gyamlValue = actor.GetMap()["Gyaml"].GetString();

            if (gyamlValue.StartsWith("Weapon_"))
            {
                if (gyamlValue.Contains("_Shield_"))
                {
                    ShieldList.Shuffle();
                    actor.GetMap()["Gyaml"] = ShieldList[0];
                }
                else if (gyamlValue.Contains("_Bow_"))
                {
                    BowList.Shuffle();
                    actor.GetMap()["Gyaml"] = BowList[0];
                }
                else if (gyamlValue.Equals("Weapon_Sword_071_Broken"))
                {
                    SharpWeaponList.Shuffle();
                    actor.GetMap()["Gyaml"] = SharpWeaponList[0];
                    return actor;
                }
                else
                {
                    WeaponList.Shuffle();
                    actor.GetMap()["Gyaml"] = WeaponList[0];
                }

                if (actor.GetMap().ContainsKey("Dynamic"))
                {
                    BymlMap dynamicArray = actor.GetMap()["Dynamic"].GetMap();

                    if (!gyamlValue.Contains("_Bow_"))
                    {
                        AttachmentList.Shuffle();

                        if (!dynamicArray.ContainsKey("Equipment_Attachment"))
                        {
                            actor.GetMap()["Dynamic"].GetMap().Add("Equipment_Attachment", AttachmentList[0]);
                        }

                        actor.GetMap()["Dynamic"].GetMap()["Equipment_Attachment"] = AttachmentList[0];
                    }
                }
            }

            return actor;
        }

        public int GetControlValue(ComboBox comboBox)
        {
            int returnValue = -1;
            if (comboBox.InvokeRequired)
            {
                comboBox.Invoke(new MethodInvoker(delegate { returnValue = comboBox.SelectedIndex; }));
            }
            else
            {
                returnValue = comboBox.SelectedIndex;
            }

            return returnValue;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            RNG = new Random((int)DateTime.Now.Ticks);

            string romfsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "romfs");
            if (Directory.Exists(romfsFolder))
            {
                Directory.Delete(romfsFolder, true);
            }

            string largeDungeonPath = Path.Combine(textBox1.Text, "Banc", "LargeDungeon");
            string mainFieldPath = Path.Combine(textBox1.Text, "Banc", "MainField");
            string mainFieldCastlePath = Path.Combine(textBox1.Text, "Banc", "MainField", "Castle");
            string mainFieldCavePath = Path.Combine(textBox1.Text, "Banc", "MainField", "Cave");
            string mainFieldLargeDungeonPath = Path.Combine(textBox1.Text, "Banc", "MainField", "LargeDungeon");
            string mainFieldSkyPath = Path.Combine(textBox1.Text, "Banc", "MainField", "Sky");
            string minusFieldPath = Path.Combine(textBox1.Text, "Banc", "MinusField");
            string minusFieldLargeDungeonPath = Path.Combine(textBox1.Text, "Banc", "MinusField", "LargeDungeon");
            string smallDungeonPath = Path.Combine(textBox1.Text, "Banc", "SmallDungeon");

            string[] mapFiles = new string[] {
                mainFieldPath,
                largeDungeonPath,
                mainFieldCastlePath,
                mainFieldCavePath,
                mainFieldLargeDungeonPath,
                mainFieldSkyPath,
                minusFieldPath,
                minusFieldLargeDungeonPath,
                smallDungeonPath
            };

            string romfsEnd;
            string finalPath;

            foreach (string mapFilePath in mapFiles)
            {
                romfsEnd = mapFilePath.Replace(textBox1.Text, "").Remove(0, 1);
                finalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "romfs", romfsEnd);
                Directory.CreateDirectory(finalPath);
                CopyFilesRecursively(mapFilePath, finalPath);
            }

            SpoilerLog.Clear();
            rstbModifiedTable.Clear();

            string resourceFolderPath = Path.Combine(textBox1.Text, "System", "Resource");
            romfsEnd = resourceFolderPath.Replace(textBox1.Text, "").Remove(0, 1);
            finalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "romfs", romfsEnd);
            Directory.CreateDirectory(finalPath);
            CopyFilesRecursively(resourceFolderPath, finalPath);

            string rstbFile = Path.Combine(randomizerPath, "System", "Resource");
            string mapfilesPath = Path.Combine(randomizerPath, "Banc");

            rstbFile = Directory.GetFiles(rstbFile, "*.rsizetable.zs")[0];

            string[] allFiles = Directory.GetFiles(mapfilesPath, "*.bcett.byml.zs", SearchOption.AllDirectories);

            allGreatSkyIslandsChestContents.Clear();
            allChestContents.Clear();

            // Create New Event Files
            string eventfilesPath = Path.Combine(textBox1.Text, "Event", "EventFlow");
            string[] allEventFiles = Directory.GetFiles(eventfilesPath, "*.bfevfl.zs", SearchOption.AllDirectories);
            List<string> allEventNames = CreateLatestEventNames(allEventFiles);
            string eventFlowFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "romfs", "Event", "EventFlow");
            Directory.CreateDirectory(eventFlowFolder);

            foreach (string eventFile in allEventNames)
            {
                string eventName = Path.GetFileNameWithoutExtension(eventFile).Split(".")[0];

                string finalEventFlowPath = Path.Combine(eventFlowFolder, Path.GetFileName(eventFile));

                bool editedEvent = false;
                byte[] modifiedData = Array.Empty<byte>();

                if (eventName == "OpeningEvent")
                {
                    File.Copy(eventFile, finalEventFlowPath, true);
                    modifiedData = TotkRandomizer.Events.EditOpeningEvent(finalEventFlowPath);
                    editedEvent = true;
                }
                else if (eventName == "DmF_SY_SmallDungeonGoal" && GetControlValue(chestsBox) == 1)
                {
                    File.Copy(eventFile, finalEventFlowPath, true);
                    modifiedData = TotkRandomizer.Events.EditDungeonGoalEvent(finalEventFlowPath);
                    editedEvent = true;
                }

                if (editedEvent)
                {
                    rstbModifiedTable.Add($"Event/EventFlow/{Path.GetFileNameWithoutExtension(eventFile).Replace(".zs", "")}", (uint)modifiedData.Length + 20000);
                }
            }

            // Create New Default Save Data
            string gameDataListFileName = "";

            foreach (string file in Directory.GetFiles(Path.Combine(textBox1.Text, "GameData")))
            {
                if (Path.GetExtension(file) == ".zs")
                {
                    gameDataListFileName = Path.GetFileName(file);
                    break;
                }
            }

            string saveFilePath = Path.Combine(textBox1.Text, "GameData", gameDataListFileName);

            Span<byte> saveFileByteArray = HashTable.DecompressDataOther(File.ReadAllBytes(saveFilePath));
            Byml saveByaml = Byml.FromBinary(saveFileByteArray);
            BymlArray boolList = saveByaml.GetMap()["Data"].GetMap()["Bool"].GetArray();

            for (int i = 0; i < boolList.Count; i++)
            {
                uint saveHash = boolList[i].GetMap()["Hash"].GetUInt32();

                foreach (string hashString in SaveBoolList.SaveBoolsToChange)
                {
                    uint stringHash = MurMurHash3.Hash(hashString);

                    if (stringHash == saveHash)
                    {
                        boolList[i].GetMap()["DefaultValue"] = true;
                        break;
                    }
                }
            }

            BymlArray string64ArrayList = saveByaml.GetMap()["Data"].GetMap()["String64Array"].GetArray();
            for (int i = 0; i < string64ArrayList.Count; i++)
            {
                uint saveHash = string64ArrayList[i].GetMap()["Hash"].GetUInt32();

                if (saveHash == 0x22c6530a)
                {
                    string64ArrayList[i].GetMap()["DefaultValue"].GetArray()[0] = "Obj_DRStone_Get";
                    string64ArrayList[i].GetMap()["DefaultValue"].GetArray()[1] = "Obj_Camera";
                    string64ArrayList[i].GetMap()["DefaultValue"].GetArray()[2] = "Obj_Battery_Get";
                    string64ArrayList[i].GetMap()["DefaultValue"].GetArray()[3] = "Parasail";
                }
                else if (saveHash == 0x12560253)
                {
                    string64ArrayList[i].GetMap()["DefaultValue"].GetArray()[0] = "Obj_UltraHand";
                    string64ArrayList[i].GetMap()["DefaultValue"].GetArray()[1] = "Obj_OneTouchBond";
                    string64ArrayList[i].GetMap()["DefaultValue"].GetArray()[2] = "Obj_Tooreroof";
                    string64ArrayList[i].GetMap()["DefaultValue"].GetArray()[3] = "Obj_ReverseRecorder";
                    string64ArrayList[i].GetMap()["DefaultValue"].GetArray()[4] = "Obj_AutoBuilder";
                }
            }

            BymlArray boolArrayList = saveByaml.GetMap()["Data"].GetMap()["BoolArray"].GetArray();
            for (int i = 0; i < boolArrayList.Count; i++)
            {
                uint saveHash = boolArrayList[i].GetMap()["Hash"].GetUInt32();

                if (saveHash == 0x81cbc834)
                {
                    boolArrayList[i].GetMap()["DefaultValue"].GetArray()[0] = true;
                    boolArrayList[i].GetMap()["DefaultValue"].GetArray()[1] = true;
                }
            }

            BymlArray enumList = saveByaml.GetMap()["Data"].GetMap()["Enum"].GetArray();
            for (int i = 0; i < enumList.Count; i++)
            {
                uint saveHash = enumList[i].GetMap()["Hash"].GetUInt32();

                if (saveHash == 0x3ee80d28)
                {
                    enumList[i].GetMap()["DefaultValue"] = (uint)0x311bb18f;
                }
                else if (saveHash == 0x92d92e37 && GetControlValue(chestsBox) == 1)
                {
                    enumList[i].GetMap()["DefaultValue"] = 0x9610d708;
                }
                else if (saveHash == 0x01d063db && GetControlValue(paragliderPatternBox) > 0)
                {
                    int selectedPattern = GetControlValue(paragliderPatternBox) == 1 ? RNG.Next(25) : GetControlValue(paragliderPatternBox) - 1;
                    string parasailValue = enumList[i].GetMap()["RawValues"].GetArray()[selectedPattern].GetString();
                    enumList[i].GetMap()["DefaultValue"] = MurMurHash3.Hash(parasailValue);
                }
            }

            BymlArray string64List = saveByaml.GetMap()["Data"].GetMap()["String64"].GetArray();
            for (int i = 0; i < string64List.Count; i++)
            {
                uint saveHash = string64List[i].GetMap()["Hash"].GetUInt32();

                if (saveHash == 0x1b39e32f && GetControlValue(chestsBox) == 1)
                {
                    string64List[i].GetMap()["DefaultValue"] = "TBox_Field_Iron";
                }
            }

            BymlArray intArrayList = saveByaml.GetMap()["Data"].GetMap()["IntArray"].GetArray();
            for (int i = 0; i < intArrayList.Count; i++)
            {
                uint saveHash = intArrayList[i].GetMap()["Hash"].GetUInt32();

                if (saveHash == 0x5a12a611)
                {
                    intArrayList[i].GetMap()["DefaultValue"].GetArray()[0] = 5;
                }
            }

            using MemoryStream ms = new();
            byte[] saveArray = saveByaml.ToBinary(Endianness.Little);

            string gameDataNewPath = Path.Combine(randomizerPath, "GameData", gameDataListFileName);
            Directory.CreateDirectory(Path.Combine(randomizerPath, "GameData"));
            File.WriteAllBytes(gameDataNewPath, HashTable.CompressDataOther(saveArray));

            rstbModifiedTable.Add(Path.Combine("GameData", gameDataListFileName).Replace("\\", "/"), (uint)(saveArray.Length + 20000));

            // Get Item Table from Map Files
            foreach (string mapFile in allFiles)
            {
                Span<byte> myByteArray = HashTable.DecompressMapData(File.ReadAllBytes(mapFile));

                Byml byaml = Byml.FromBinary(myByteArray);

                // For every object in the map, randomize it!
                BymlMap byamlFileArray = byaml.GetMap();

                if (byamlFileArray.ContainsKey("Actors"))
                {
                    BymlArray actorList = byamlFileArray["Actors"].GetArray();

                    for (int i = 0; i < actorList.Count; i++)
                    {
                        string chestContent = GetChestContent(actorList[i]);
                        ulong chestHash = GetChestHash(actorList[i]);

                        if (chestContent != string.Empty)
                        {
                            if (IsSkyIslandChest(mapFile))
                            {
                                allGreatSkyIslandsChestContents.Add(chestHash, chestContent);
                            }
                            else
                            {
                                allChestContents.Add(chestContent);
                            }
                        }
                    }
                }
            }

            allGreatSkyIslandsChestContents = allGreatSkyIslandsChestContents.Shuffle();

            // Add Light Orbs in Chests across the Great Sky Islands
            for (int i = 0; i < GREAT_SKY_ISLANDS_LIGHT_ORBS_COUNT; i++)
            {
                KeyValuePair<ulong, string> newLightOrb = allGreatSkyIslandsChestContents.First(i => !i.Value.StartsWith("Armor_") && !i.Value.Equals("Obj_DungeonClearSeal"));
                allGreatSkyIslandsChestContents[newLightOrb.Key] = "Obj_DungeonClearSeal";
            }

            // Add Light Orbs in Chests across Hyrule
            for (int i = 0; i < TOTAL_LIGHT_ORBS_COUNT - GREAT_SKY_ISLANDS_LIGHT_ORBS_COUNT; i++)
            {
                string newLightOrb = allChestContents.First(i => i.StartsWith("Item_"));
                int index = allChestContents.IndexOf(newLightOrb);

                if (index != -1)
                {
                    allChestContents[index] = "Obj_DungeonClearSeal";
                }
            }

            // Remove sky islands variable separations
            foreach (KeyValuePair<ulong, string> chest in allGreatSkyIslandsChestContents.Where(x => x.Value != "Obj_DungeonClearSeal"))
            {
                allChestContents.Add(chest.Value);
                allGreatSkyIslandsChestContents.Remove(chest.Key);
            }

            allChestContents.Shuffle();

            // Randomize Map Files
            foreach (string mapFile in allFiles)
            {
                Span<byte> myByteArray = HashTable.DecompressMapData(File.ReadAllBytes(mapFile));
                Byml byaml = Byml.FromBinary(myByteArray);

                // For every object in the map, randomize it!
                BymlMap byamlFileArray = byaml.GetMap();

                if (byamlFileArray.ContainsKey("Actors"))
                {
                    BymlArray actorList = byamlFileArray["Actors"].GetArray();

                    for (int i = 0; i < actorList.Count; i++)
                    {
                        if (GetControlValue(weaponsBox) == 1)
                        {
                            actorList[i] = ReplaceFloorWeapon(actorList[i]);
                        }

                        if (GetControlValue(enemiesBox) == 1)
                        {
                            actorList[i] = ReplaceEnemy(actorList[i]);
                        }

                        if (GetControlValue(chestsBox) == 1)
                        {
                            actorList[i] = ReplaceChest(actorList[i], mapFile);
                        }

                        if (GetControlValue(natureBox) == 1)
                        {
                            actorList[i] = ReplaceBasics(actorList[i]);
                        }
                    }
                }

                saveArray = byaml.ToBinary(Endianness.Little);

                string rstbPath = Path.GetDirectoryName(mapFile).Replace(randomizerPath, "").Replace("romfs\\", "").Replace("\\", "/")[1..] + "/" + Path.GetFileNameWithoutExtension(mapFile);
                rstbModifiedTable.Add(rstbPath, (uint)(saveArray.Length + 20000));

                File.WriteAllBytes(mapFile, HashTable.CompressMapData(saveArray));

                currentProgress++;
                backgroundWorker1.ReportProgress(currentProgress);
            }

            //RSTB Table
            Rstb rstbFileData = Rstb.FromBinary(HashTable.DecompressFile(File.ReadAllBytes(rstbFile)));

            for (int i = 0; i < rstbModifiedTable.Keys.Count; i++)
            {
                rstbFileData.OverflowTable[rstbModifiedTable.Keys.ElementAt(i)] = rstbModifiedTable.Values.ElementAt(i);
            }

            byte[] compressedRSTB = HashTable.CompressDataOther(rstbFileData.ToBinary().ToArray());
            File.WriteAllBytes(rstbFile, compressedRSTB);

            // Spoiler Log
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "romfs", "spoiler_log.txt");
            File.WriteAllLines(logPath, SpoilerLog);
        }

        private bool IsSkyIslandChest(string mapFile)
        {
            string mapFileName = Path.GetFileNameWithoutExtension(mapFile);
            return mapFileName.StartsWith("StartIsland") || mapFileName.StartsWith("Dungeon060") || mapFileName.StartsWith("Dungeon061") || mapFileName.StartsWith("Dungeon062") || mapFileName.StartsWith("Dungeon063");
        }

        private bool IsSkyIslandOrbChest(ulong hashValue)
        {
            return allGreatSkyIslandsChestContents.ContainsKey(hashValue);
        }

        private List<string> CreateLatestEventNames(string[] allEventFiles)
        {
            List<string> eventNames = new List<string>();

            foreach (string eventFile in allEventFiles)
            {
                string eventName = Path.GetFileNameWithoutExtension(eventFile).Split(".")[0];

                if (eventNames.Any(o => Path.GetFileNameWithoutExtension(o).StartsWith(eventName)))
                {
                    Dictionary<string, int> sameEvents = new Dictionary<string, int>();

                    foreach (string sameEvent in allEventFiles)
                    {
                        if (Path.GetFileNameWithoutExtension(sameEvent).Split(".")[0].StartsWith(eventName))
                        {
                            if (Path.GetFileNameWithoutExtension(sameEvent).Split(".").Length > 2)
                            {
                                int eventVersion = int.Parse(Path.GetFileNameWithoutExtension(sameEvent).Split(".")[1]);
                                sameEvents.Add(sameEvent, eventVersion);
                            }
                            else
                            {
                                sameEvents.Add(sameEvent, 0);
                            }
                        }
                    }

                    Dictionary<string, int> orderedDict = sameEvents.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                    eventNames.RemoveAll(x => Path.GetFileNameWithoutExtension(x).StartsWith(eventName));
                    eventNames.Add(orderedDict.Keys.Last());
                }
                else
                {
                    eventNames.Add(eventFile);
                }
            }

            return eventNames;
        }

        private string GetChestContent(Byml actor)
        {
            string gyamlValue = actor.GetMap()["Gyaml"].GetString();

            if (gyamlValue.StartsWith("TBox_"))
            {
                if (actor.GetMap().ContainsKey("Dynamic"))
                {
                    BymlMap dynamicArray = actor.GetMap()["Dynamic"].GetMap();

                    if (dynamicArray.ContainsKey("Drop__DropActor"))
                    {
                        string dropValue = actor.GetMap()["Dynamic"].GetMap()["Drop__DropActor"].GetString();

                        if (dropValue.Equals("KeySmall"))
                        {
                            return string.Empty;
                        }

                        return dropValue;
                    }
                }
            }

            return string.Empty;
        }

        private ulong GetChestHash(Byml actor)
        {
            return actor.GetMap()["Hash"].GetUInt64();
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = maxProgress;
            progressBar1.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;

            SystemSounds.Exclamation.Play();

            Console.WriteLine("Done!");

            tabControl1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.AutoUpgradeEnabled = true;
            dialog.UseDescriptionForTitle = true;
            dialog.Description = "Select TotK RomFS folder...";

            // Show Folder dialog, get a path from it
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
                Properties.Settings.Default.totkPath = textBox1.Text;
                Properties.Settings.Default.Save();

                button1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.totkPath != null && Properties.Settings.Default.totkPath != String.Empty)
            {
                textBox1.Text = Properties.Settings.Default.totkPath;
                button1.Enabled = true;
            }
        }
    }
}