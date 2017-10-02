using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace FactorioModManager
{
    public partial class FactorioModManagerMain : Form
    {
        public string APP_DATA;
        public string DIR_FACTORIO;
        public string DIR_MODMANAGER;
        public string DIR_MODS;
        public string DIR_MODPACKS;
        public string DIR_MOD_UNUSED;
        public string FILE_PACK_NAME;

        public List<String> l_modPacks      = new List<string>();
        public List<String> l_modsInPack    = new List<string>();
        public List<String> l_files         = new List<string>();

        // Initialise directories
        public void initDirs()
        {
            bool found_factorio;
            bool found_mods;
            bool found_modmanager;
            bool found_modpacks;
            bool found_unused;

            // Init folder variables
            APP_DATA        = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DIR_FACTORIO    = APP_DATA          + "\\Factorio";
            DIR_MODMANAGER  = APP_DATA          + "\\FactorioModManager";
            DIR_MODS        = DIR_FACTORIO      + "\\Mods";
            DIR_MODPACKS    = DIR_MODMANAGER    + "\\Modpacks";
            DIR_MOD_UNUSED  = DIR_MODMANAGER    + "\\UnusedMods";
            // Init file variables
            FILE_PACK_NAME  = DIR_MODS          + "\\name.txt";

            // Check for folder existence
            found_factorio      = Directory.Exists(DIR_FACTORIO);
            found_mods          = Directory.Exists(DIR_MODS);
            found_modmanager    = Directory.Exists(DIR_MODMANAGER);
            found_modpacks      = Directory.Exists(DIR_MODPACKS);
            found_unused        = Directory.Exists(DIR_MOD_UNUSED);

            // Except if factorio not found
            if (!found_factorio)
            {
                throw new Exception("mainNotFound");
            }

            // Create non existing folders
            if (!found_mods)
            {
                Directory.CreateDirectory(DIR_MODS);
            }
            if (!found_modmanager)
            {
                Directory.CreateDirectory(DIR_MODMANAGER);
            }
            if (!found_modpacks)
            {
                Directory.CreateDirectory(DIR_MODPACKS);
            }
            if (!found_unused)
            {
                Directory.CreateDirectory(DIR_MOD_UNUSED);
            }
            // Set initial directory for export and import
            sfd_export.InitialDirectory = DIR_MODMANAGER;
            ofd_import.InitialDirectory = DIR_MODMANAGER;
        }

        // Load modpacks
        public void loadModpacks()
        {
            string[] modPacks;
            modPacks = Directory.GetDirectories(DIR_MODPACKS);
            foreach (string modPack in modPacks)
            {
                // Add modpacks to list
                if(!l_modPacks.Contains(modPack))
                {
                    l_modPacks.Add(modPack);
                    lb_modPack.Items.Add(modPack.Remove(0, DIR_MODPACKS.Length + 1));
                }
                // Scan mods in Pack
                scanModPack(modPack);
            }
            scanModPack(DIR_MOD_UNUSED);
        }

        // Scan modpack
        public void scanModPack(string modPack)
        {
            string[] mods;

            // Clear modpack display
            l_modsInPack.Clear();
            // Load mods in pack
            mods = Directory.GetFiles(modPack);
            // Check if there are any mods in ModPack
            foreach (string mod in mods)
            {
                if (mod.EndsWith(".zip"))
                {
                    // Add mods to list
                    if (!l_modsInPack.Contains(mod))
                    {
                        l_modsInPack.Add(mod);
                    }
                    if (!lb_modAll.Items.Contains(mod.Remove(0, modPack.Length + 1)))
                    {
                        lb_modAll.Items.Add(mod.Remove(0, modPack.Length + 1));
                    }
                    if (!l_files.Contains(mod))
                    {
                        l_files.Add(mod);
                    }
                }
            }
        }

        // Remove mod from modpack
        public void removeMod(string mod)
        {
            string tmp;
            string modPath;
            bool modUnique; 
           
            // Get path to mod
            modPath = l_modsInPack.Find(x => x.Contains(mod));
            // Remove mod from modpack list
            l_modsInPack.Remove(modPath);
            l_files.Remove(modPath);
            // Check if the mod is present in another pack
            tmp = l_files.Find(x => x.Contains(mod));
            if(tmp != null)
            {
                modUnique = false;
            }
            else
            {
                modUnique = true;
            }
            // If mod is not present in another pack copy it to UnusedMods
            if(modUnique)
            {
                if (!File.Exists(DIR_MOD_UNUSED + "\\" + mod))
                {
                    File.Move(modPath, DIR_MOD_UNUSED + "\\" + mod);
                    l_files.Add(DIR_MOD_UNUSED + "\\" + mod);
                }
                else
                {
                    File.Delete(modPath);
                }
            }
            // If it is not unique delet it
            else
            {
                File.Delete(modPath);
            }
            // Remove mod from modpack lists
            lb_modContains.Items.Remove(mod);

            // Rescan modpack
            string modPack;
            lb_modContains.Items.Clear();
            // Get selected Modpack
            modPack = l_modPacks[lb_modPack.SelectedIndex];
            // Scan Modpack
            scanModPack(modPack);
            if (l_modsInPack.Count() > 0)
            {
                foreach (string tmpMod in l_modsInPack)
                {
                    lb_modContains.Items.Add(tmpMod.Remove(0, modPack.Length + 1));
                }
            }
            // No Mods in ModPack
            else
            {
                lb_modContains.Items.Add("No Mods in this Pack!");
            }

        }

        // Add mod to modpack
        public void addMod(string mod, string modPack)
        {
            string modPath;
            string modPackPath;

            modPath = l_files.Find(x => x.Contains(mod));
            modPackPath = l_modPacks.Find(x => x.Contains(modPack));

            // Check if mod already in pack
            if(!File.Exists(modPackPath + "\\" + mod))
            {
                // Check if the mod we want comes from unused folder
                if(modPath.Contains(DIR_MOD_UNUSED))
                {
                    l_files.Remove(modPath);
                    File.Move(modPath, modPackPath + "\\" + mod);
                    l_files.Add(modPackPath + "\\" + mod);
                }
                // Mod copied
                else
                {
                    File.Copy(modPath, modPackPath + "\\" + mod);
                    l_files.Add(modPackPath + "\\" + mod);
                }
                // Rescan modpack
                lb_modContains.Items.Clear();
                // Get selected Modpack
                modPack = l_modPacks[lb_modPack.SelectedIndex];
                // Scan Modpack
                scanModPack(modPack);
                if (l_modsInPack.Count() > 0)
                {
                    foreach (string tmpMod in l_modsInPack)
                    {
                        lb_modContains.Items.Add(tmpMod.Remove(0, modPack.Length + 1));
                    }
                }
            }
        }

        // Refresh all
        public void refresh()
        {
            bool found_name;

            l_files.Clear();
            l_modPacks.Clear();
            l_modsInPack.Clear();
            lb_modAll.Items.Clear();
            lb_modContains.Items.Clear();
            lb_modPack.Items.Clear();
            loadModpacks();
            // Sort ListBoxes
            lb_modAll.Sorted = true;
            lb_modPack.Sorted = true;
            lb_modContains.Sorted = true;
            // Check for name.txt
            found_name = File.Exists(FILE_PACK_NAME);
            if(found_name)
            {
                using (StreamReader sr = new StreamReader(FILE_PACK_NAME))
                {
                    // Read Mod Pack name
                    tb_active.Text = sr.ReadLine();
                }
            }
            else
            {
                tb_active.Text = "Unnamed ModPack!";
            }
        }

        // Show a message for a missing feature
        public void notABug()
        {
            MessageBox.Show("This is not a Bug it is a Feature! \n\r A Feature that is yet to be added...", "Not a Bug, a Feature!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public FactorioModManagerMain()
        {
            InitializeComponent();
        }

        private void FactorioModManagerMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Check directories
                initDirs();
                // List modpacks
                refresh();
            }
            catch (Exception ex)
            {
                if (ex.Message == "mainNotFound")
                {
                    MessageBox.Show("Could not find Factorio AppData folder!", "Folder not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lb_modPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string modPack;
                // Clear List
                lb_modContains.Items.Clear();
                // Get selected Modpack
                modPack = l_modPacks[lb_modPack.SelectedIndex];
                // Scan Modpack
                scanModPack(modPack);
                if (l_modsInPack.Count() > 0)
                {
                    foreach (string mod in l_modsInPack)
                    {
                        lb_modContains.Items.Add(mod.Remove(0, modPack.Length + 1));
                    }
                }
                // No Mods in ModPack
                else
                {
                    lb_modContains.Items.Add("No Mods in this Pack!");
                }
            }
            catch
            {
                refresh();
            }
        }

        private void lb_modAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Party
        }

        private void bt_removeMod_Click(object sender, EventArgs e)
        {
            string mod;
            try
            {
                mod = (string)lb_modContains.Items[lb_modContains.SelectedIndex];
                removeMod(mod);
            }
            catch
            {
                MessageBox.Show("Please select a valid Mod", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void bt_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void bt_addMod_Click(object sender, EventArgs e)
        {
            string mod;
            string modPack;
            mod = (string)lb_modAll.Items[lb_modAll.SelectedIndex];
            try
            {
                modPack = (string)lb_modPack.Items[lb_modPack.SelectedIndex];
                addMod(mod, modPack);
            }
            catch
            {
                MessageBox.Show("Please select a Modpack", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void bt_exportPack_Click(object sender, EventArgs e)
        {
            string fileToSave;
            string modPack;
            string modPackPath;

            sfd_export.Filter = "Zip File |*.zip";
            sfd_export.ShowDialog();

            if (sfd_export.FileName != "")
            {
                try
                {
                    modPack = (string)lb_modPack.Items[lb_modPack.SelectedIndex];
                    modPackPath = l_modPacks.Find(x => x.Contains(modPack));
                    fileToSave = sfd_export.FileName;
                    // Create a Zip file with modpack
                    ZipFile.CreateFromDirectory(modPackPath, fileToSave);
                    // Add "name.txt" to file
                    using (FileStream modPackZip = new FileStream(fileToSave, FileMode.Open))
                    {
                        using (ZipArchive archive = new ZipArchive(modPackZip, ZipArchiveMode.Update))
                        {
                            ZipArchiveEntry nameEntry = archive.CreateEntry("name.txt");
                            using (StreamWriter writer = new StreamWriter(nameEntry.Open()))
                            {
                                // Write name to file
                                writer.WriteLine(modPack);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error while exporting! \n\r Did you select a Mod Pack?", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void bt_importPack_Click(object sender, EventArgs e)
        {
            string importPath;
            string packName = "unknownModPack" + (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond).ToString();

            if (ofd_import.ShowDialog() == DialogResult.OK)
            {
                importPath = ofd_import.FileName;
                try
                {
                    // Open the zip and search for a text containing the name
                    using (ZipArchive modPack = ZipFile.OpenRead(importPath))
                    {
                        foreach (ZipArchiveEntry entry  in modPack.Entries)
                        {
                            if(entry.FullName.Equals("name.txt"))
                            {
                                // Open textfile and read it
                                using (StreamReader sr = new StreamReader(entry.Open()))
                                {
                                    packName = sr.ReadLine();
                                }
                            }
                        }
                        
                    }
                    ZipFile.ExtractToDirectory(importPath, DIR_MODPACKS + "\\" + packName);
                    File.Delete(DIR_MODPACKS + "\\" + packName + "\\name.txt");
                }
                catch
                {
                    MessageBox.Show("Could not import Mod Pack! \n\r You may need to delete the created Folder!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                refresh();
            }
        }

        private void bt_activate_Click(object sender, EventArgs e)
        {
            string[] modsFolderContent;
            DialogResult result;
            string modPack;
            string modPackPath;
            try
            {
                modPack = (string)lb_modPack.Items[lb_modPack.SelectedIndex];
                modPackPath = l_modPacks.Find(x => x.Contains(modPack));
                // Ask if sure
                result = MessageBox.Show("This will delete all Mods in Factorio Directory! \n\r Are you Sure?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if(result == DialogResult.Yes)
                {
                    // Remove each file in Mods Dir
                    modsFolderContent = Directory.GetFiles(DIR_MODS);
                    foreach(string file in modsFolderContent)
                    {
                        File.Delete(file);
                    }
                    // Get all files in selected modPack
                    modsFolderContent = Directory.GetFiles(modPackPath);
                    foreach (string file in modsFolderContent)
                    {
                        File.Copy(file, DIR_MODS + "\\" + file.Remove(0, modPackPath.Length + 1));
                    }
                    // Create a "name.txt" file to indicate modpack name
                    using (StreamWriter writer = new StreamWriter(DIR_MODS + "\\name.txt"))
                    {
                        // Write name to file
                        writer.WriteLine(modPack);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not activate selected Mod Pack!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            refresh();
        }

        private void bt_convert_Click(object sender, EventArgs e)
        {
            string[] modsToCopy;

            // Generate a name for the directory timebased
            string packName = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond).ToString();
            // Create a new directory for the mod pack
            Directory.CreateDirectory(DIR_MODPACKS + "\\" + packName);
            // Wait 1 sec because otherwise we "could" create two same folders
            System.Threading.Thread.Sleep(1000);
            // Copy every ".zip" file to new dir
            modsToCopy = Directory.GetFiles(DIR_MODS);
            foreach(string file in modsToCopy)
            {
                if(file.EndsWith(".zip"))
                {
                    File.Copy(file, DIR_MODPACKS + "\\" + packName + "\\" + file.Remove(0,DIR_MODS.Length + 1));
                }
            }
            refresh();
        }

        private void bt_removePack_Click(object sender, EventArgs e)
        {
            string[] modsToRemove;
            string modPack;
            string modPackPath;

            try
            {
                modPack = (string)lb_modPack.Items[lb_modPack.SelectedIndex];
                modPackPath = l_modPacks.Find(x => x.Contains(modPack));
                modsToRemove = Directory.GetFiles(modPackPath);
                if(modsToRemove.Count() > 0)
                {
                    foreach(string mod in modsToRemove)
                    {
                        removeMod(mod.Remove(0, modPackPath.Length + 1));
                    }
                }
                Directory.Delete(modPackPath);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not delete Pack!", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            refresh();
        }

        private void bt_addPack_Click(object sender, EventArgs e)
        {
            bool dir_created = false;
            string newDirName = "NewModPack";
            // Try to create a new Directory
            while (dir_created == false)
            {
                if (!Directory.Exists(DIR_MODPACKS + "\\" + newDirName))
                {
                    Directory.CreateDirectory(DIR_MODPACKS + "\\" + newDirName);
                    dir_created = true;
                }
                else
                {
                    newDirName += "X";
                }
            }
            refresh();
        }

        private void bt_rename_Click(object sender, EventArgs e)
        {
            string modPack;
            string modPackPath;

            if(tb_newName.Text == "")
            {
                MessageBox.Show("Please enter a new name", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            try
            {
                modPack = (string)lb_modPack.Items[lb_modPack.SelectedIndex];
                modPackPath = l_modPacks.Find(x => x.Contains(modPack));
                Directory.Move(modPackPath, DIR_MODPACKS + "\\" + tb_newName.Text);
            }
            catch
            {
                MessageBox.Show("Please select a mod pack", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            refresh();
        }
    }
}
