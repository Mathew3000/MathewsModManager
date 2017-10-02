namespace FactorioModManager
{
    partial class FactorioModManagerMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FactorioModManagerMain));
            this.lb_modPack = new System.Windows.Forms.ListBox();
            this.gb_modPack = new System.Windows.Forms.GroupBox();
            this.gb_modAll = new System.Windows.Forms.GroupBox();
            this.lb_modAll = new System.Windows.Forms.ListBox();
            this.gb_modContains = new System.Windows.Forms.GroupBox();
            this.lb_modContains = new System.Windows.Forms.ListBox();
            this.bt_addMod = new System.Windows.Forms.Button();
            this.bt_removeMod = new System.Windows.Forms.Button();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.bt_exportPack = new System.Windows.Forms.Button();
            this.sfd_export = new System.Windows.Forms.SaveFileDialog();
            this.ofd_import = new System.Windows.Forms.OpenFileDialog();
            this.bt_importPack = new System.Windows.Forms.Button();
            this.tb_active = new System.Windows.Forms.TextBox();
            this.l_active = new System.Windows.Forms.Label();
            this.bt_activate = new System.Windows.Forms.Button();
            this.bt_convert = new System.Windows.Forms.Button();
            this.bt_removePack = new System.Windows.Forms.Button();
            this.bt_addPack = new System.Windows.Forms.Button();
            this.bt_rename = new System.Windows.Forms.Button();
            this.tb_newName = new System.Windows.Forms.TextBox();
            this.gb_modPack.SuspendLayout();
            this.gb_modAll.SuspendLayout();
            this.gb_modContains.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_modPack
            // 
            this.lb_modPack.FormattingEnabled = true;
            this.lb_modPack.Location = new System.Drawing.Point(6, 16);
            this.lb_modPack.Name = "lb_modPack";
            this.lb_modPack.Size = new System.Drawing.Size(174, 147);
            this.lb_modPack.TabIndex = 0;
            this.lb_modPack.SelectedIndexChanged += new System.EventHandler(this.lb_modPack_SelectedIndexChanged);
            // 
            // gb_modPack
            // 
            this.gb_modPack.Controls.Add(this.lb_modPack);
            this.gb_modPack.Location = new System.Drawing.Point(13, 13);
            this.gb_modPack.Name = "gb_modPack";
            this.gb_modPack.Size = new System.Drawing.Size(186, 174);
            this.gb_modPack.TabIndex = 1;
            this.gb_modPack.TabStop = false;
            this.gb_modPack.Text = "Mod Packs";
            // 
            // gb_modAll
            // 
            this.gb_modAll.Controls.Add(this.lb_modAll);
            this.gb_modAll.Location = new System.Drawing.Point(461, 13);
            this.gb_modAll.Name = "gb_modAll";
            this.gb_modAll.Size = new System.Drawing.Size(250, 174);
            this.gb_modAll.TabIndex = 2;
            this.gb_modAll.TabStop = false;
            this.gb_modAll.Text = "All Mods";
            // 
            // lb_modAll
            // 
            this.lb_modAll.FormattingEnabled = true;
            this.lb_modAll.Location = new System.Drawing.Point(6, 16);
            this.lb_modAll.Name = "lb_modAll";
            this.lb_modAll.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_modAll.Size = new System.Drawing.Size(238, 147);
            this.lb_modAll.TabIndex = 0;
            this.lb_modAll.SelectedIndexChanged += new System.EventHandler(this.lb_modAll_SelectedIndexChanged);
            // 
            // gb_modContains
            // 
            this.gb_modContains.Controls.Add(this.lb_modContains);
            this.gb_modContains.Location = new System.Drawing.Point(205, 13);
            this.gb_modContains.Name = "gb_modContains";
            this.gb_modContains.Size = new System.Drawing.Size(250, 174);
            this.gb_modContains.TabIndex = 3;
            this.gb_modContains.TabStop = false;
            this.gb_modContains.Text = "Mods in Mod Pack";
            // 
            // lb_modContains
            // 
            this.lb_modContains.FormattingEnabled = true;
            this.lb_modContains.Location = new System.Drawing.Point(6, 16);
            this.lb_modContains.Name = "lb_modContains";
            this.lb_modContains.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_modContains.Size = new System.Drawing.Size(238, 147);
            this.lb_modContains.TabIndex = 0;
            // 
            // bt_addMod
            // 
            this.bt_addMod.Location = new System.Drawing.Point(211, 223);
            this.bt_addMod.Name = "bt_addMod";
            this.bt_addMod.Size = new System.Drawing.Size(238, 23);
            this.bt_addMod.TabIndex = 5;
            this.bt_addMod.Text = "Add Mod to Pack";
            this.bt_addMod.UseVisualStyleBackColor = true;
            this.bt_addMod.Click += new System.EventHandler(this.bt_addMod_Click);
            // 
            // bt_removeMod
            // 
            this.bt_removeMod.Location = new System.Drawing.Point(211, 194);
            this.bt_removeMod.Name = "bt_removeMod";
            this.bt_removeMod.Size = new System.Drawing.Size(238, 23);
            this.bt_removeMod.TabIndex = 6;
            this.bt_removeMod.Text = "Remove Mod from Pack";
            this.bt_removeMod.UseVisualStyleBackColor = true;
            this.bt_removeMod.Click += new System.EventHandler(this.bt_removeMod_Click);
            // 
            // bt_refresh
            // 
            this.bt_refresh.Location = new System.Drawing.Point(211, 252);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(238, 23);
            this.bt_refresh.TabIndex = 8;
            this.bt_refresh.Text = "Refresh Mods / Mod Packs";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // bt_exportPack
            // 
            this.bt_exportPack.Location = new System.Drawing.Point(19, 252);
            this.bt_exportPack.Name = "bt_exportPack";
            this.bt_exportPack.Size = new System.Drawing.Size(174, 23);
            this.bt_exportPack.TabIndex = 9;
            this.bt_exportPack.Text = "Export Mod Pack";
            this.bt_exportPack.UseVisualStyleBackColor = true;
            this.bt_exportPack.Click += new System.EventHandler(this.bt_exportPack_Click);
            // 
            // bt_importPack
            // 
            this.bt_importPack.Location = new System.Drawing.Point(19, 282);
            this.bt_importPack.Name = "bt_importPack";
            this.bt_importPack.Size = new System.Drawing.Size(174, 23);
            this.bt_importPack.TabIndex = 10;
            this.bt_importPack.Text = "Import Mod Pack";
            this.bt_importPack.UseVisualStyleBackColor = true;
            this.bt_importPack.Click += new System.EventHandler(this.bt_importPack_Click);
            // 
            // tb_active
            // 
            this.tb_active.BackColor = System.Drawing.SystemColors.Window;
            this.tb_active.Location = new System.Drawing.Point(557, 195);
            this.tb_active.Name = "tb_active";
            this.tb_active.ReadOnly = true;
            this.tb_active.Size = new System.Drawing.Size(148, 20);
            this.tb_active.TabIndex = 11;
            // 
            // l_active
            // 
            this.l_active.AutoSize = true;
            this.l_active.Location = new System.Drawing.Point(464, 198);
            this.l_active.Name = "l_active";
            this.l_active.Size = new System.Drawing.Size(40, 13);
            this.l_active.TabIndex = 12;
            this.l_active.Text = "Active:";
            // 
            // bt_activate
            // 
            this.bt_activate.Location = new System.Drawing.Point(467, 223);
            this.bt_activate.Name = "bt_activate";
            this.bt_activate.Size = new System.Drawing.Size(238, 23);
            this.bt_activate.TabIndex = 13;
            this.bt_activate.Text = "Activate Mod Pack";
            this.bt_activate.UseVisualStyleBackColor = true;
            this.bt_activate.Click += new System.EventHandler(this.bt_activate_Click);
            // 
            // bt_convert
            // 
            this.bt_convert.Location = new System.Drawing.Point(19, 311);
            this.bt_convert.Name = "bt_convert";
            this.bt_convert.Size = new System.Drawing.Size(174, 23);
            this.bt_convert.TabIndex = 14;
            this.bt_convert.Text = "Convert current Mods to Pack";
            this.bt_convert.UseVisualStyleBackColor = true;
            this.bt_convert.Click += new System.EventHandler(this.bt_convert_Click);
            // 
            // bt_removePack
            // 
            this.bt_removePack.Location = new System.Drawing.Point(19, 194);
            this.bt_removePack.Name = "bt_removePack";
            this.bt_removePack.Size = new System.Drawing.Size(174, 23);
            this.bt_removePack.TabIndex = 15;
            this.bt_removePack.Text = "Remove Mod Pack";
            this.bt_removePack.UseVisualStyleBackColor = true;
            this.bt_removePack.Click += new System.EventHandler(this.bt_removePack_Click);
            // 
            // bt_addPack
            // 
            this.bt_addPack.Location = new System.Drawing.Point(19, 223);
            this.bt_addPack.Name = "bt_addPack";
            this.bt_addPack.Size = new System.Drawing.Size(174, 23);
            this.bt_addPack.TabIndex = 16;
            this.bt_addPack.Text = "Add Mod Pack";
            this.bt_addPack.UseVisualStyleBackColor = true;
            this.bt_addPack.Click += new System.EventHandler(this.bt_addPack_Click);
            // 
            // bt_rename
            // 
            this.bt_rename.Location = new System.Drawing.Point(467, 252);
            this.bt_rename.Name = "bt_rename";
            this.bt_rename.Size = new System.Drawing.Size(84, 23);
            this.bt_rename.TabIndex = 17;
            this.bt_rename.Text = "Rename Pack";
            this.bt_rename.UseVisualStyleBackColor = true;
            this.bt_rename.Click += new System.EventHandler(this.bt_rename_Click);
            // 
            // tb_newName
            // 
            this.tb_newName.Location = new System.Drawing.Point(557, 254);
            this.tb_newName.Name = "tb_newName";
            this.tb_newName.Size = new System.Drawing.Size(148, 20);
            this.tb_newName.TabIndex = 18;
            // 
            // FactorioModManagerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 348);
            this.Controls.Add(this.tb_newName);
            this.Controls.Add(this.bt_rename);
            this.Controls.Add(this.bt_addPack);
            this.Controls.Add(this.bt_removePack);
            this.Controls.Add(this.bt_convert);
            this.Controls.Add(this.bt_activate);
            this.Controls.Add(this.l_active);
            this.Controls.Add(this.tb_active);
            this.Controls.Add(this.bt_importPack);
            this.Controls.Add(this.bt_exportPack);
            this.Controls.Add(this.bt_refresh);
            this.Controls.Add(this.bt_removeMod);
            this.Controls.Add(this.bt_addMod);
            this.Controls.Add(this.gb_modContains);
            this.Controls.Add(this.gb_modAll);
            this.Controls.Add(this.gb_modPack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FactorioModManagerMain";
            this.Text = "Mathew\'s Mod Manager";
            this.Load += new System.EventHandler(this.FactorioModManagerMain_Load);
            this.gb_modPack.ResumeLayout(false);
            this.gb_modAll.ResumeLayout(false);
            this.gb_modContains.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_modPack;
        private System.Windows.Forms.GroupBox gb_modPack;
        private System.Windows.Forms.GroupBox gb_modAll;
        private System.Windows.Forms.ListBox lb_modAll;
        private System.Windows.Forms.GroupBox gb_modContains;
        private System.Windows.Forms.ListBox lb_modContains;
        private System.Windows.Forms.Button bt_addMod;
        private System.Windows.Forms.Button bt_removeMod;
        private System.Windows.Forms.Button bt_refresh;
        private System.Windows.Forms.Button bt_exportPack;
        private System.Windows.Forms.SaveFileDialog sfd_export;
        private System.Windows.Forms.OpenFileDialog ofd_import;
        private System.Windows.Forms.Button bt_importPack;
        private System.Windows.Forms.TextBox tb_active;
        private System.Windows.Forms.Label l_active;
        private System.Windows.Forms.Button bt_activate;
        private System.Windows.Forms.Button bt_convert;
        private System.Windows.Forms.Button bt_removePack;
        private System.Windows.Forms.Button bt_addPack;
        private System.Windows.Forms.Button bt_rename;
        private System.Windows.Forms.TextBox tb_newName;
    }
}

