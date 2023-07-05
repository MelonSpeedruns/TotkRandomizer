using Cead;
using Cead.Interop;
using CsRestbl;
using Native.IO.Services;
using Ookii.Dialogs.WinForms;
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
            DllManager.LoadCead();

            NativeLibraryManager.RegisterAssembly(typeof(Application).Assembly, out bool isCommonLoaded).Register(new RestblLibrary(), out bool isRestblLoaded);

            InitializeComponent();
        }

        private int currentProgress = 0;
        private static int maxProgress = 0;

        private static Dictionary<string, uint> rstbModifiedTable = new Dictionary<string, uint>();

        private string randomizerPath;

        private void button1_Click(object sender, EventArgs e)
        {
            currentProgress = 0;
            maxProgress = 0;

            randomizerPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "romfs");
            HashTable.InitHashTable(Path.Combine(textBox1.Text, "Pack", "ZsDic.pack.zs"));

            backgroundWorker1.RunWorkerAsync();
            button1.Enabled = false;
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
            string gyamlValue = actor.GetHash()["Gyaml"].GetString();

            if (actor.GetHash().ContainsKey("Dynamic"))
            {
                Byml.Hash dynamicArray = actor.GetHash()["Dynamic"].GetHash();

                foreach (KeyValuePair<List<string>, List<List<string>>> enemyDictList in EnemyReplaceList)
                {
                    foreach (string enemyList in enemyDictList.Key)
                    {
                        if (gyamlValue.Equals(enemyList))
                        {
                            List<string> enemyTypeList = enemyDictList.Value[RNG.Next(enemyDictList.Value.Count)];
                            string newEnemyName = enemyTypeList[RNG.Next(enemyTypeList.Count)];
                            actor.GetHash()["Gyaml"] = newEnemyName;

                            if (actor.GetHash().ContainsKey("Rails"))
                            {
                                actor.GetHash().Remove("Rails");
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

        private Byml ReplaceChest(Byml actor)
        {
            string gyamlValue = actor.GetHash()["Gyaml"].GetString();

            if (gyamlValue.StartsWith("TBox_"))
            {
                if (actor.GetHash().ContainsKey("Dynamic"))
                {
                    Byml.Hash dynamicArray = actor.GetHash()["Dynamic"].GetHash();

                    if (dynamicArray.ContainsKey("Drop__DropActor_Attachment"))
                    {
                        actor.GetHash()["Dynamic"].GetHash().Remove("Drop__DropActor_Attachment");
                    }

                    if (dynamicArray.ContainsKey("Drop__DropActor"))
                    {
                        ChestContents.Shuffle();
                        actor.GetHash()["Dynamic"].GetHash()["Drop__DropActor"] = ChestContents[0];

                        if (ChestContents[0].StartsWith("Armor_"))
                        {
                            ChestContents.RemoveAt(0);
                        }

                        if (gyamlValue.StartsWith("Weapon_") && !gyamlValue.Contains("_Bow_"))
                        {
                            AttachmentList.Shuffle();

                            if (!dynamicArray.ContainsKey("Drop__DropActor_Attachment"))
                            {
                                actor.GetHash()["Dynamic"].GetHash().Add("Drop__DropActor_Attachment", AttachmentList[0]);
                            }

                            actor.GetHash()["Dynamic"].GetHash()["Drop__DropActor_Attachment"] = AttachmentList[0];
                        }
                    }
                }
            }

            return actor;
        }

        private Byml ReplaceDogs(Byml actor)
        {
            // Replace Dogs
            string gyamlValue = actor.GetHash()["Gyaml"].GetString();

            if (gyamlValue.StartsWith("Animal_Dog_"))
            {
                actor.GetHash()["Gyaml"] = "Enemy_Lynel_Dark";

                Byml.Hash dynamicArray = actor.GetHash()["Dynamic"].GetHash();

                if (actor.GetHash().ContainsKey("Rails"))
                {
                    actor.GetHash().Remove("Rails");
                }

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

                return actor;
            }

            return actor;
        }

        private Byml ReplaceBasics(Byml actor)
        {
            // Replace Basic Objects
            string gyamlValue = actor.GetHash()["Gyaml"].GetString();

            foreach (List<string> basicObjectList in BasicObjectsReplaceList)
            {
                foreach (string basicObject in basicObjectList)
                {
                    if (gyamlValue.Equals(basicObject))
                    {
                        basicObjectList.Shuffle();
                        actor.GetHash()["Gyaml"] = basicObjectList[0];

                        return actor;
                    }
                }
            }

            return actor;
        }

        private Byml ReplaceFloorWeapon(Byml actor)
        {
            // Replace Floor Weapon
            string gyamlValue = actor.GetHash()["Gyaml"].GetString();

            if (gyamlValue.StartsWith("Weapon_"))
            {
                if (gyamlValue.Contains("_Shield_"))
                {
                    ShieldList.Shuffle();
                    actor.GetHash()["Gyaml"] = ShieldList[0];
                }
                else if (gyamlValue.Contains("_Bow_"))
                {
                    BowList.Shuffle();
                    actor.GetHash()["Gyaml"] = BowList[0];
                }
                else if (gyamlValue.Equals("Weapon_Sword_071_Broken"))
                {
                    SharpWeaponList.Shuffle();
                    actor.GetHash()["Gyaml"] = SharpWeaponList[0];
                    return actor;
                }
                else
                {
                    WeaponList.Shuffle();
                    actor.GetHash()["Gyaml"] = WeaponList[0];
                }

                if (actor.GetHash().ContainsKey("Dynamic"))
                {
                    Byml.Hash dynamicArray = actor.GetHash()["Dynamic"].GetHash();

                    if (!gyamlValue.Contains("_Bow_"))
                    {
                        AttachmentList.Shuffle();

                        if (!dynamicArray.ContainsKey("Equipment_Attachment"))
                        {
                            actor.GetHash()["Dynamic"].GetHash().Add("Equipment_Attachment", AttachmentList[0]);
                        }

                        actor.GetHash()["Dynamic"].GetHash()["Equipment_Attachment"] = AttachmentList[0];
                    }
                }
            }

            return actor;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
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

            string resourceFolderPath = Path.Combine(textBox1.Text, "System", "Resource");
            romfsEnd = resourceFolderPath.Replace(textBox1.Text, "").Remove(0, 1);
            finalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "romfs", romfsEnd);
            Directory.CreateDirectory(finalPath);
            CopyFilesRecursively(resourceFolderPath, finalPath);

            string rstbFile = Path.Combine(randomizerPath, "System", "Resource");
            string mapfilesPath = Path.Combine(randomizerPath, "Banc");

            rstbFile = Directory.GetFiles(rstbFile, "*.rsizetable.zs")[0];

            string[] allFiles = Directory.GetFiles(mapfilesPath, "*.bcett.byml.zs", SearchOption.AllDirectories);
            foreach (string mapFile in allFiles)
            {
                Span<byte> myByteArray = HashTable.DecompressMapData(File.ReadAllBytes(mapFile));
                Byml byaml = Byml.FromBinary(myByteArray);

                // For every object in the map, randomize it!
                Byml.Hash byamlFileArray = byaml.GetHash();

                if (byamlFileArray.ContainsKey("Actors"))
                {
                    Byml.Array actorList = byamlFileArray["Actors"].GetArray();

                    for (int i = 0; i < actorList.Length; i++)
                    {
                        actorList[i] = ReplaceFloorWeapon(actorList[i]);
                        actorList[i] = ReplaceEnemy(actorList[i]);
                        actorList[i] = ReplaceChest(actorList[i]);

                        actorList[i] = ReplaceBasics(actorList[i]);

                        //actorList[i] = ReplaceDogs(actorList[i]);
                    }
                }

                byte[] fs1Array = byaml.ToBinary(false, 7).ToArray();

                string rstbPath = Path.GetDirectoryName(mapFile).Replace(randomizerPath, "").Replace("romfs\\", "").Replace("\\", "/")[1..] + "/" + Path.GetFileNameWithoutExtension(mapFile);
                rstbModifiedTable.Add(rstbPath, (uint)(fs1Array.Length + 20000));

                File.WriteAllBytes(mapFile, HashTable.CompressMapData(fs1Array));

                currentProgress++;
                backgroundWorker1.ReportProgress(currentProgress);
            }

            //RSTB Table
            Restbl rstbFileData = Restbl.FromBinary(HashTable.DecompressFile(File.ReadAllBytes(rstbFile)));

            for (int i = 0; i < rstbModifiedTable.Keys.Count; i++)
            {
                rstbFileData.NameTable[rstbModifiedTable.Keys.ElementAt(i)] = rstbModifiedTable.Values.ElementAt(i);
            }

            byte[] compressedRSTB = HashTable.CompressDataOther(rstbFileData.ToBinary().ToArray());
            File.WriteAllBytes(rstbFile, compressedRSTB);
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

            rstbModifiedTable.Clear();

            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Select Tears of the Kingdom ROMFS folder...";
            dialog.UseDescriptionForTitle = true;

            // Show Folder dialog, get a path from it
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            textBox1.Text = dialog.SelectedPath;
            Properties.Settings.Default.totkPath = textBox1.Text;
            Properties.Settings.Default.Save();

            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.totkPath != null)
            {
                textBox1.Text = Properties.Settings.Default.totkPath;
                button1.Enabled = true;
            }
        }
    }
}