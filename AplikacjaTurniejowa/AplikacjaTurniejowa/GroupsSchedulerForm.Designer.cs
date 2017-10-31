namespace AplikacjaTurniejowa
{
    partial class GroupsSchedulerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupsSchedulerForm));
            this.SelectGroupComboBox = new System.Windows.Forms.ComboBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.AddGroupButton = new System.Windows.Forms.Button();
            this.RemoveGroupButton = new System.Windows.Forms.Button();
            this.RemoveAllGroupsButton = new System.Windows.Forms.Button();
            this.AutomaticSchedulingButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupCountcomboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importujDaneZXLSXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klubyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zarządzajKlubamiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zawodnicyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listyStartoweToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszJakHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.usuńWSZYSTKIEPodgrupyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.MinParticipantsInGroupLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectGroupComboBox
            // 
            this.SelectGroupComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectGroupComboBox.FormattingEnabled = true;
            this.SelectGroupComboBox.Location = new System.Drawing.Point(47, 3);
            this.SelectGroupComboBox.Name = "SelectGroupComboBox";
            this.SelectGroupComboBox.Size = new System.Drawing.Size(409, 21);
            this.SelectGroupComboBox.TabIndex = 0;
            this.SelectGroupComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectGroupComboBox_SelectedIndexChanged);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.treeView1.Location = new System.Drawing.Point(3, 84);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(459, 591);
            this.treeView1.TabIndex = 6;
            this.treeView1.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeView1_NodeMouseHover);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            this.treeView1.MouseHover += new System.EventHandler(this.treeView1_MouseHover);
            this.treeView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseMove);
            // 
            // treeView2
            // 
            this.treeView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.treeView2.Location = new System.Drawing.Point(468, 84);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(460, 591);
            this.treeView2.TabIndex = 7;
            this.treeView2.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeView2_NodeMouseHover);
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            this.treeView2.DoubleClick += new System.EventHandler(this.treeView2_DoubleClick);
            // 
            // AddGroupButton
            // 
            this.AddGroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.AddGroupButton.Location = new System.Drawing.Point(3, 3);
            this.AddGroupButton.Name = "AddGroupButton";
            this.AddGroupButton.Size = new System.Drawing.Size(75, 23);
            this.AddGroupButton.TabIndex = 1;
            this.AddGroupButton.Text = "Dodaj grupę";
            this.AddGroupButton.UseVisualStyleBackColor = false;
            this.AddGroupButton.Click += new System.EventHandler(this.AddGroupButton_Click);
            // 
            // RemoveGroupButton
            // 
            this.RemoveGroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.RemoveGroupButton.Location = new System.Drawing.Point(111, 3);
            this.RemoveGroupButton.Name = "RemoveGroupButton";
            this.RemoveGroupButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveGroupButton.TabIndex = 2;
            this.RemoveGroupButton.Text = "Usuń grupę";
            this.RemoveGroupButton.UseVisualStyleBackColor = false;
            this.RemoveGroupButton.Click += new System.EventHandler(this.RemoveGroupButton_Click);
            // 
            // RemoveAllGroupsButton
            // 
            this.RemoveAllGroupsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.RemoveAllGroupsButton.Location = new System.Drawing.Point(219, 3);
            this.RemoveAllGroupsButton.Name = "RemoveAllGroupsButton";
            this.RemoveAllGroupsButton.Size = new System.Drawing.Size(136, 23);
            this.RemoveAllGroupsButton.TabIndex = 3;
            this.RemoveAllGroupsButton.Text = "Usuń wszystkie podgrupy w grupie";
            this.RemoveAllGroupsButton.UseVisualStyleBackColor = false;
            this.RemoveAllGroupsButton.Click += new System.EventHandler(this.RemoveAllGroupsButton_Click);
            // 
            // AutomaticSchedulingButton
            // 
            this.AutomaticSchedulingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AutomaticSchedulingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AutomaticSchedulingButton.Location = new System.Drawing.Point(325, 3);
            this.AutomaticSchedulingButton.Name = "AutomaticSchedulingButton";
            this.AutomaticSchedulingButton.Size = new System.Drawing.Size(132, 21);
            this.AutomaticSchedulingButton.TabIndex = 5;
            this.AutomaticSchedulingButton.Text = "Rozmieść automatycznie";
            this.AutomaticSchedulingButton.UseVisualStyleBackColor = false;
            this.AutomaticSchedulingButton.Click += new System.EventHandler(this.AutomaticSchedulingButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "Min. ilość osób w podgrupie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ilość podgrup";
            // 
            // GroupCountcomboBox
            // 
            this.GroupCountcomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupCountcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupCountcomboBox.FormattingEnabled = true;
            this.GroupCountcomboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024"});
            this.GroupCountcomboBox.Location = new System.Drawing.Point(134, 3);
            this.GroupCountcomboBox.Name = "GroupCountcomboBox";
            this.GroupCountcomboBox.Size = new System.Drawing.Size(169, 21);
            this.GroupCountcomboBox.TabIndex = 4;
            this.GroupCountcomboBox.SelectedIndexChanged += new System.EventHandler(this.GroupCountcomboBox_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem,
            this.klubyToolStripMenuItem,
            this.listyStartoweToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(931, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importujDaneZXLSXToolStripMenuItem,
            this.zamknijToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // importujDaneZXLSXToolStripMenuItem
            // 
            this.importujDaneZXLSXToolStripMenuItem.Name = "importujDaneZXLSXToolStripMenuItem";
            this.importujDaneZXLSXToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.importujDaneZXLSXToolStripMenuItem.Text = "Importuj dane z XLSX";
            this.importujDaneZXLSXToolStripMenuItem.Click += new System.EventHandler(this.importujDaneZXLSXToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // klubyToolStripMenuItem
            // 
            this.klubyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zarządzajKlubamiToolStripMenuItem,
            this.zawodnicyToolStripMenuItem1});
            this.klubyToolStripMenuItem.Name = "klubyToolStripMenuItem";
            this.klubyToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.klubyToolStripMenuItem.Text = "Zgłoszenia";
            // 
            // zarządzajKlubamiToolStripMenuItem
            // 
            this.zarządzajKlubamiToolStripMenuItem.Name = "zarządzajKlubamiToolStripMenuItem";
            this.zarządzajKlubamiToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.zarządzajKlubamiToolStripMenuItem.Text = "Kluby";
            this.zarządzajKlubamiToolStripMenuItem.Click += new System.EventHandler(this.zarządzajKlubamiToolStripMenuItem_Click);
            // 
            // zawodnicyToolStripMenuItem1
            // 
            this.zawodnicyToolStripMenuItem1.Name = "zawodnicyToolStripMenuItem1";
            this.zawodnicyToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.zawodnicyToolStripMenuItem1.Text = "Uczestnicy";
            this.zawodnicyToolStripMenuItem1.Click += new System.EventHandler(this.zawodnicyToolStripMenuItem1_Click);
            // 
            // listyStartoweToolStripMenuItem
            // 
            this.listyStartoweToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zapiszJakHTMLToolStripMenuItem,
            this.toolStripSeparator1,
            this.usuńWSZYSTKIEPodgrupyToolStripMenuItem});
            this.listyStartoweToolStripMenuItem.Name = "listyStartoweToolStripMenuItem";
            this.listyStartoweToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.listyStartoweToolStripMenuItem.Text = "Listy startowe";
            // 
            // zapiszJakHTMLToolStripMenuItem
            // 
            this.zapiszJakHTMLToolStripMenuItem.Name = "zapiszJakHTMLToolStripMenuItem";
            this.zapiszJakHTMLToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.zapiszJakHTMLToolStripMenuItem.Text = "Zapisz jako HTML";
            this.zapiszJakHTMLToolStripMenuItem.Click += new System.EventHandler(this.zapiszJakHTMLToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // usuńWSZYSTKIEPodgrupyToolStripMenuItem
            // 
            this.usuńWSZYSTKIEPodgrupyToolStripMenuItem.Name = "usuńWSZYSTKIEPodgrupyToolStripMenuItem";
            this.usuńWSZYSTKIEPodgrupyToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.usuńWSZYSTKIEPodgrupyToolStripMenuItem.Text = "Usuń WSZYSTKIE podgrupy";
            this.usuńWSZYSTKIEPodgrupyToolStripMenuItem.Click += new System.EventHandler(this.usuńWSZYSTKIEPodgrupyToolStripMenuItem_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramieToolStripMenuItem});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // oProgramieToolStripMenuItem
            // 
            this.oProgramieToolStripMenuItem.Name = "oProgramieToolStripMenuItem";
            this.oProgramieToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.oProgramieToolStripMenuItem.Text = "O programie";
            this.oProgramieToolStripMenuItem.Click += new System.EventHandler(this.oProgramieToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Grupy";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 708);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(931, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(400, 16);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Podział na podgrupy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(468, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Uczestnicy nieprzydzieleni";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeView2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(931, 678);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.586057F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.41394F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.SelectGroupComboBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.54839F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.45161F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(459, 62);
            this.tableLayoutPanel3.TabIndex = 21;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel4.Controls.Add(this.RemoveGroupButton, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.RemoveAllGroupsButton, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.AddGroupButton, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(47, 30);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(409, 29);
            this.tableLayoutPanel4.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.47826F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.04348F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.GroupCountcomboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.AutomaticSchedulingButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.MinParticipantsInGroupLabel, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(468, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(460, 62);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // MinParticipantsInGroupLabel
            // 
            this.MinParticipantsInGroupLabel.AutoSize = true;
            this.MinParticipantsInGroupLabel.Location = new System.Drawing.Point(134, 31);
            this.MinParticipantsInGroupLabel.Name = "MinParticipantsInGroupLabel";
            this.MinParticipantsInGroupLabel.Size = new System.Drawing.Size(13, 13);
            this.MinParticipantsInGroupLabel.TabIndex = 15;
            this.MinParticipantsInGroupLabel.Text = "0";
            // 
            // GroupsSchedulerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GroupsSchedulerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator list startowych v. 0.1";
            this.Load += new System.EventHandler(this.GroupsSchedulerForm2_Load);
            this.EnabledChanged += new System.EventHandler(this.GroupsSchedulerForm_EnabledChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectGroupComboBox;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button AddGroupButton;
        private System.Windows.Forms.Button RemoveGroupButton;
        private System.Windows.Forms.Button RemoveAllGroupsButton;
        private System.Windows.Forms.Button AutomaticSchedulingButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox GroupCountcomboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem klubyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listyStartoweToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importujDaneZXLSXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zarządzajKlubamiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszJakHTMLToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem usuńWSZYSTKIEPodgrupyToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem zawodnicyToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label MinParticipantsInGroupLabel;
    }
}