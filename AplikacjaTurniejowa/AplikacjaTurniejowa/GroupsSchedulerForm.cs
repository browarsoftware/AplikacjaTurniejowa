using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SQLite;
using System.IO;
using NPOI.SS.UserModel;




namespace AplikacjaTurniejowa
{
    public partial class GroupsSchedulerForm : Form
    {
        public GroupsSchedulerForm()
        {
            InitializeComponent();
            //TO DO: Poprawić wydruk
            //zrobić import z CSV

            //open xls file with npoi library
            //Utils.ImportToDatabaseFromXLS("e:\\Projects\\Karate\\karta zgłoszeniowa_puchar_krakowa_test4.xlsx", false);

            //ManageClubsForm mgf = new ManageClubsForm();
            //mgf.ShowDialog();

            //ManageParticipantsForm mgf = new ManageParticipantsForm();
            //mgf.ShowDialog();

            int z = 0;
            z++;

            //SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=II_Ogolnopolski_Puchar_Krakowa_2017.db;Version=3;");
            //HTMLPrinter.print();
            //PDFSaver pdfS = new PDFSaver();
            //PDFSaver.PdfSharpConvert();

            //m_dbConnection.Open();
            //Utils.ImportToDatabaseFromCSV(@"e:\Projects\Karate\CSV\klub4.txt", "4", true);
            //m_dbConnection.Close();
            //Utils.InitializeAllAtheletsToGroups();
            //int a = 0;
            //a++;
            //Utils.AddAllAthletesToNextLevel(1);

            //Utils.GetAllAthletesAtLevelAndGroup(1, 1);
            //Utils.SplitIntoSubGroups(4, 1, "D", 0, 1);
        }


        ArrayList allGroups = new ArrayList();
        //ArrayList subGroups = new ArrayList();
        private void GroupsSchedulerForm2_Load(object sender, EventArgs e)
        {

            this.GroupCountcomboBox.SelectedIndex = 2;
            MinParticipantsInGroupLabel.Text = "2";

            allGroups = Utils.ReturnAllGroupsAtLevel(0, 0);
            for (int a = 0; a < allGroups.Count; a++)
            {
                Group g = (Group)allGroups[a];
                SelectGroupComboBox.Items.Add(g.name);
            }
            if (allGroups.Count > 0)
                SelectGroupComboBox.SelectedIndex = 0;
            //treeView1.Nodes.Clear();

            this.treeView1.AllowDrop = true;
            this.treeView2.AllowDrop = true;

            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.treeView2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
            this.treeView2.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDropGroups);
            this.treeView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDropAthletes);

            //ManageParticipantsForm mgf = new ManageParticipantsForm(allGroups);
            //mgf.ShowDialog();
        }



        private void treeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void treeView_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeNode NewNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                if (DestinationNode == null) return;
                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                //if (DestinationNode.TreeView != NewNode.TreeView)
                //{
                DestinationNode.Nodes.Add((TreeNode)NewNode.Clone());
                DestinationNode.Expand();
                //Remove Original Node
                NewNode.Remove();
                // }
            }

        }

        private void treeView_DragDropGroups(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeNode NewNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                if (DestinationNode == null) return;
                if (!(DestinationNode.Tag is Group)) return;

                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (NewNode.Tag is Group) return;
                //if (DestinationNode.TreeView != NewNode.TreeView)
                //{
                DestinationNode.Nodes.Add((TreeNode)NewNode.Clone());
                DestinationNode.Expand();
                //Remove Original Node
                NewNode.Remove();
                Group g = (Group)DestinationNode.Tag;
                Participant p = (Participant)NewNode.Tag;
                //String ii = (String)SelectSubgroupListBox.SelectedItem;
                int si = SelectGroupComboBox.SelectedIndex;
                Group mainGroup = (Group)allGroups[si];

                Utils.AddUserToGroup(g.id, mainGroup.id, p.id, g.level);
                // }
            }

        }

        //TreeView AthletesTreeView = null;
        private void treeView_DragDropAthletes(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeNode NewNode;

            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                if (DestinationNode != null) return;


                

                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");

                TreeNode parentNode = NewNode.Parent;

                if (NewNode.Tag is Group) return;
                //if (DestinationNode.TreeView != NewNode.TreeView)
                //{
                treeView2.Nodes.Add((TreeNode)NewNode.Clone());
                //AthletesTreeView.Nodes.Expand();
                //Remove Original Node
                NewNode.Remove();

                //Group g = (Group)DestinationNode.Tag;

                Group g = (Group)parentNode.Tag;
                Participant p = (Participant)NewNode.Tag;

                Utils.RemoveUserFromGroup(g.id, p.id, g.level);
                // }
            }

        }









































        private void UpdateComponents()
        {
            int si = SelectGroupComboBox.SelectedIndex;
            Group g = (Group)allGroups[si];

            if (g.id == 1)
            {
                AddGroupButton.Enabled = false;
                RemoveGroupButton.Enabled = false;
                AutomaticSchedulingButton.Enabled = false;
                RemoveAllGroupsButton.Enabled = false;
            }
            else
            {
                AddGroupButton.Enabled = true;
                RemoveGroupButton.Enabled = true;
                AutomaticSchedulingButton.Enabled = true;
                RemoveAllGroupsButton.Enabled = true;
            }


            //SelectSubgroupListBox.Items.Clear();
            //ArrayList al = Utils.ReturnAllLevels(g.id);
            /*for (int a = 0; a < al.Count; a++)
            {
                SelectSubgroupListBox.Items.Add((String)al[a]);
            }*/

            UpdateSubgroups();
            /*
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();
            //String level = SelectSubgroupListBox.SelectedItem.ToString();
            ArrayList ul = Utils.GetAllAthletesAtLevelAndGroup(g.id, 1);
            for (int a = 0; a < ul.Count; a++)
            {

                Participant p = (Participant)ul[a];
                //if (p.idGrupaLevel == -1)
                {
                    TreeNode tn = new TreeNode(p.name + " " + p.surname + " (" + p.nazwaKlubu + ")");
                    tn.Tag = p;
                    int idN = treeView2.Nodes.Add(tn);
                }
            }*/
            CalculateMinUsersPerGroup();
        }

        private void SelectGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateComponents();
        }


        private void UpdateSubgroups()
        {
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();
            int si = SelectGroupComboBox.SelectedIndex;
            Group g = (Group)allGroups[si];
            String level = "1";// SelectSubgroupListBox.SelectedItem.ToString();
            ArrayList al = Utils.ReturnAllGroupsAtLevel(g.id, int.Parse(level));

            ArrayList ul = Utils.GetAllAthletesAtLevelAndGroup(g.id, int.Parse(level));
            for (int a = 0; a < al.Count; a++)
            {
                g = (Group)al[a];
                TreeNode tn = new TreeNode(g.name);
                tn.Tag = g;
                int idN = treeView1.Nodes.Add(tn);

                TreeNode ParentNode = treeView1.Nodes[idN];
                for (int b = 0; b < ul.Count; b++)
                {

                    Participant p = (Participant)ul[b];
                    if (p.idPodgrupa == g.id)
                    {
                        TreeNode tn2 = new TreeNode(p.name + " " + p.surname + " (" + p.nazwaKlubu + ")");
                        tn2.Tag = p;
                        ParentNode.Nodes.Add(tn2);
                    }
                }
                ParentNode.ExpandAll();
            }
            for (int a = 0; a < ul.Count; a++)
            {

                Participant p = (Participant)ul[a];
                if (p.idPodgrupa == -1)
                {
                    TreeNode tn = new TreeNode(p.name + " " + p.surname + " (" + p.nazwaKlubu + ")");
                    tn.Tag = p;
                    int idN = treeView2.Nodes.Add(tn);
                }
            }
        }
        /*
        private void SelectSubgroupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();
            int si = SelectGroupComboBox.SelectedIndex;
            Group g = (Group)allGroups[si];
            String level = "1";// SelectSubgroupListBox.SelectedItem.ToString();
            ArrayList al = Utils.ReturnAllGroupsAtLevel(g.id, int.Parse(level));

            ArrayList ul = Utils.GetAllAthletesAtLevelAndGroup(g.id, int.Parse(level));
            for (int a = 0; a < al.Count; a++)
            {
                g = (Group)al[a];
                TreeNode tn = new TreeNode(g.name);
                tn.Tag = g;
                int idN = treeView1.Nodes.Add(tn);

                TreeNode ParentNode = treeView1.Nodes[idN];
                for (int b = 0; b < ul.Count; b++)
                {

                    Participant p = (Participant)ul[b];
                    if (p.idPodgrupa == g.id)
                    {
                        TreeNode tn2 = new TreeNode(p.name + " " + p.surname + " (" + p.nazwaKlubu + ")");
                        tn2.Tag = p;
                        ParentNode.Nodes.Add(tn2);
                    }
                }
                ParentNode.ExpandAll();
            }
            for (int a = 0; a < ul.Count; a++)
            {

                Participant p = (Participant)ul[a];
                if (p.idPodgrupa == -1)
                {
                    TreeNode tn = new TreeNode(p.name + " " + p.surname + " (" + p.nazwaKlubu + ")");
                    tn.Tag = p;
                    int idN = treeView2.Nodes.Add(tn);
                }
            }
            
            //ArrayList u = Utils.GetAllAthletesAtLevel(
        }*/

        private void RemoveGroupButton_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            if (tn != null)
            {
                if (tn.Tag is Group)
                {
                    Group g = (Group)tn.Tag;
                    String sql = "UPDATE UczestnikGrupa SET IdPodgrupa = NULL WHERE IdPodgrupa = " + g.id + " AND poziom = " + g.level;
                    SQLiteConnection connection = Utils.getConnection();
                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();
                    sql = "DELETE FROM Grupa WHERE id = " + g.id;
                    command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();
                    tn.Remove();
                    UpdateComponents();
                    //ArrayList al = Utils.GetAllAthletesAtLevelAndGroup(
                }
            }
        }

        private void AddGroupButton_Click(object sender, EventArgs e)
        {
            int si = SelectGroupComboBox.SelectedIndex;
            Group g = (Group)allGroups[si];
            int level = 1;
            /*if (SelectSubgroupListBox.Items.Count > 0)
            {
                level = int.Parse(SelectSubgroupListBox.SelectedItem.ToString());
            }*/

            String sql = "INSERT INTO GRUPA (Nazwa, Opis, Rodzic,Poziom,IdGrupaWiekowa,IdStopienOd,IdStopienDo,IdTypRywalizacji,IdPlec,CzyDruzynowa) VALUES "
                                          + "('TEST!!', ''," + g.id + "," + level +"," + g.IdGrupaWiekowa + "," + g.IdStopienOd + "," + g.IdStopienDo + "," + g.IdTypRywalizacji + "," + g.IdPlec + "," + g.CzyDruzynowa + ")";

            //String sql = "INSERT INTO GRUPA (Nazwa, Rodzic, Poziom) VALUES ('TEST!!', " + g.id + "," + level +"," + g.IdGrupaWiekowa + "," + g.IdStopienOd + "," + g.IdStopienDo + "," + g.IdTypRywalizacji + "," + "," + g.IdPlec + "," + g.CzyDruzynowa + ")";
            SQLiteConnection connection = Utils.getConnection();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            UpdateComponents();
        }

        private void AutomaticSchedulingButton_Click(object sender, EventArgs e)
        {
            int si = SelectGroupComboBox.SelectedIndex;
            Group g = (Group)allGroups[si];
            int level = 1;
            /*if (SelectSubgroupListBox.Items.Count > 0)
            {
                level = int.Parse(SelectSubgroupListBox.SelectedItem.ToString());
            }*/
            //int min = int.Parse(MinParticipantsInGroupcomboBox1.SelectedItem.ToString());

            //ScheduleToGroups(min, "", level, g.type, g);
            int groupCount = int.Parse(GroupCountcomboBox.SelectedItem.ToString());

            ScheduleToGroups(groupCount, g.nazwaGrupyWiekowej, level, g.type, g);
            /*String rezultat = Utils.SplitIntoSubGroups(groupCount, level, g.type, g, null);

            if (rezultat != null)
                MessageBox.Show(rezultat, "Podział na podgrupy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            UpdateComponents();*/
        }

        private void RemoveAllGroupsButton_Click(object sender, EventArgs e)
        {
            while (treeView1.Nodes.Count > 0)
            {
                TreeNode tn = treeView1.Nodes[0];
                if (tn != null)
                {
                    if (tn.Tag is Group)
                    {
                        Group g = (Group)tn.Tag;
                        String sql = "UPDATE UczestnikGrupa SET IdPodgrupa = NULL WHERE IdPodgrupa = " + g.id + " AND poziom = " + g.level;
                        SQLiteConnection connection = Utils.getConnection();
                        SQLiteCommand command = new SQLiteCommand(sql, connection);
                        command.ExecuteNonQuery();
                        sql = "DELETE FROM Grupa WHERE id = " + g.id;
                        command = new SQLiteCommand(sql, connection);
                        command.ExecuteNonQuery();
                        tn.Remove();
                        //UpdateComponents();
                        //ArrayList al = Utils.GetAllAthletesAtLevelAndGroup(
                    }
                }
            }
            UpdateComponents();
        }

        private void treeView1_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            // Get the node at the current mouse pointer location.
            TreeNode theNode = this.treeView1.GetNodeAt(e.X, e.Y);

            // Set a ToolTip only if the mouse pointer is actually paused on a node.
            if ((theNode != null))
            {
                // Verify that the tag property is not "null".
                if (theNode.Tag != null)
                {
                    // Change the ToolTip only if the pointer moved to a new node.
                    if (theNode.Tag.ToString() != this.toolTip1.GetToolTip(this.treeView1))
                    {
                        String text = "";
                        if (theNode.Tag is Participant)
                        {
                            text = ((Participant)theNode.Tag).GenerateTooltipText();
                        }
                        else if (theNode.Tag is Group)
                        {
                            text = ((Group)theNode.Tag).GenerateTooltipText();
                        }
                        this.toolTip1.SetToolTip(this.treeView1, text);
                    }
                }
                else
                {
                    this.toolTip1.SetToolTip(this.treeView1, "");
                }
            }
            else     // Pointer is not over a node so clear the ToolTip.
            {
                this.toolTip1.SetToolTip(this.treeView1, "");
            }*/
        }

        private void treeView1_MouseHover(object sender, EventArgs e)
        {
            // Get the node at the current mouse pointer location.
            //TreeNode theNode = this.treeView1.GetNodeAt(e.X, e.Y);

            //TreeNode theNode = (TreeNode)treeView1.GetNodeAt(Cursor.Position);
            TreeNode theNode = (TreeNode)treeView1.GetNodeAt(treeView1.PointToClient(Cursor.Position));
            // Set a ToolTip only if the mouse pointer is actually paused on a node.
            if ((theNode != null))
            {
                // Verify that the tag property is not "null".
                if (theNode.Tag != null)
                {
                    // Change the ToolTip only if the pointer moved to a new node.
                    if (theNode.Tag.ToString() != this.toolTip1.GetToolTip(this.treeView1))
                    {
                        String text = "";
                        if (theNode.Tag is Participant)
                        {
                            text = ((Participant)theNode.Tag).GenerateTooltipText();
                        }
                        else if (theNode.Tag is Group)
                        {
                            text = ((Group)theNode.Tag).GenerateTooltipText();
                        }
                        this.toolTip1.SetToolTip(this.treeView1, text);
                    }
                }
                else
                {
                    this.toolTip1.SetToolTip(this.treeView1, "");
                }
            }
            else     // Pointer is not over a node so clear the ToolTip.
            {
                this.toolTip1.SetToolTip(this.treeView1, "");
            }
        }

        private void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            TreeNode theNode = e.Node;
       
            if ((theNode != null))
            {
                // Verify that the tag property is not "null".
                if (theNode.Tag != null)
                {
                    // Change the ToolTip only if the pointer moved to a new node.
                    //if (theNode.Tag.ToString() != this.toolTip1.GetToolTip(this.treeView1))
                    String text = "";
                    if (theNode.Tag is Participant)
                    {
                        text = ((Participant)theNode.Tag).GenerateTooltipText();
                    }
                    else if (theNode.Tag is Group)
                    {
                        text = ((Group)theNode.Tag).GenerateTooltipText();
                    }
                    if (text != this.toolTip1.GetToolTip(this.treeView1))
                    {
                        this.toolTip1.SetToolTip(this.treeView1, text);
                        Point point = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y + 50));
                        this.toolTip1.Show(text, this, point,4000);
                        //this.toolTip1.UseFading = true;
                    }

                }
                else
                {
                    this.toolTip1.SetToolTip(this.treeView1, "");
                }
            }
            else     // Pointer is not over a node so clear the ToolTip.
            {
                this.toolTip1.SetToolTip(this.treeView1, "");
            }
        }

        private void treeView2_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            TreeNode theNode = e.Node;

            if ((theNode != null))
            {
                // Verify that the tag property is not "null".
                if (theNode.Tag != null)
                {
                    // Change the ToolTip only if the pointer moved to a new node.
                    //if (theNode.Tag.ToString() != this.toolTip1.GetToolTip(this.treeView1))
                    String text = "";
                    if (theNode.Tag is Participant)
                    {
                        text = ((Participant)theNode.Tag).GenerateTooltipText();
                    }
                    else if (theNode.Tag is Group)
                    {
                        text = ((Group)theNode.Tag).GenerateTooltipText();
                    }
                    if (text != this.toolTip1.GetToolTip(this.treeView1))
                    {
                        this.toolTip1.SetToolTip(this.treeView1, text);
                        Point point = PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y + 50));
                        this.toolTip1.Show(text, this, point, 4000);
                        //this.toolTip1.UseFading = true;
                    }

                }
                else
                {
                    this.toolTip1.SetToolTip(this.treeView1, "");
                }
            }
            else     // Pointer is not over a node so clear the ToolTip.
            {
                this.toolTip1.SetToolTip(this.treeView1, "");
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void treeView2_DoubleClick(object sender, EventArgs e)
        {
            if (treeView2.SelectedNode != null)
            {
                if (treeView2.SelectedNode.Tag is Participant)
                {
                    Participant p = (Participant)treeView2.SelectedNode.Tag;
                    AddParticipantForm apf = new AddParticipantForm(p.id.ToString(), this.allGroups);
                    apf.ShowDialog();
                    if (apf.NewAdded)
                    {
                        UpdateComponents();
                    }

                    /*Participant p = (Participant)treeView2.SelectedNode.Tag;
                    ParticipantDetailsForm pdf = new ParticipantDetailsForm(p, allGroups, 1);
                    pdf.ShowDialog();
                    if (pdf.changesMade)
                        UpdateComponents();*/
                }
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
                if (treeView1.SelectedNode.Tag != null)
                {
                    if (treeView1.SelectedNode.Tag is Participant)
                    {
                        Participant p = (Participant)treeView1.SelectedNode.Tag;
                        AddParticipantForm apf = new AddParticipantForm(p.id.ToString(), this.allGroups);
                        apf.ShowDialog();
                        if (apf.NewAdded)
                        {
                            UpdateComponents();
                        }
                        /*
                        Participant p = (Participant)treeView1.SelectedNode.Tag;
                        ParticipantDetailsForm pdf = new ParticipantDetailsForm(p, allGroups, 1);
                        pdf.ShowDialog();
                        if (pdf.changesMade)
                            UpdateComponents();*/
                    }
                    else if (treeView1.SelectedNode.Tag is Group)
                    {
                        Group g = (Group)treeView1.SelectedNode.Tag;
                        GroupDetailsForm gdf = new GroupDetailsForm(g);
                        gdf.ShowDialog();
                        if (gdf.changesMade)
                            UpdateComponents();
                    
                    }
                }

        }


        private void RemoveTotallyAllGroups()
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć WSZYSTKIE podgrupy?", "Usuwanie podgrup", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.Cancel)
                return;

            if (MessageBox.Show("Zmiany, które dokonasz będą nieodwracalne. Czy POZOSTAWIĆ utworzone podgrupy?", "Usuwanie podgrup", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                return;

            String sql = "UPDATE UczestnikGrupa SET IdPodgrupa = NULL WHERE poziom = " + 1;
            SQLiteConnection connection = Utils.getConnection();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            sql = "DELETE FROM Grupa WHERE poziom = " + 1;
            command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
            UpdateComponents();
        }
        /*
        private void AutomaticSchedulingAll()
        {
            if (MessageBox.Show("Czy na pewno chcesz dokonać automatycznego rozmieszczenia WSZYSTKICH uczestników?", "Rozmieszczanie w podgrupach", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;
            String rezultatAll = "";
            for (int a = 0; a < allGroups.Count; a++)
            {
                Group g = (Group)allGroups[a];
                int level = 1;
                
                int min = int.Parse(MinParticipantsInGroupcomboBox1.SelectedItem.ToString());
                if (g.id != 1)
                {
                    String rezultat = Utils.SplitIntoSubGroups(min, "", level, g.type, g);
                    if (rezultat != null)
                        rezultatAll += rezultat + "\r\n";
                }
            }
            if (rezultatAll != "")
                MessageBox.Show(rezultatAll, "Podział na podgrupy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Podział na podgrupy zakończył się pomyślnie.", "Podział na podgrupy", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateComponents();
        }*/



        private void CrateLists(int groupId)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.RestoreDirectory = true;

            String printDir = AppDomain.CurrentDomain.BaseDirectory + "print\\";
            if (!Directory.Exists(printDir))
            {
                Directory.CreateDirectory(printDir);
            }

            saveFileDialog1.InitialDirectory = printDir;
            saveFileDialog1.Filter = "html file|*.html";
            saveFileDialog1.Title = "Save as html";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                String destPathToCSS = Path.GetDirectoryName(saveFileDialog1.FileName) + "\\styl.css";
                String sourcePathToCSS = AppDomain.CurrentDomain.BaseDirectory + "html\\styl.css";


                File.Copy(sourcePathToCSS, destPathToCSS, true);
                int a = 0;
                HTMLPrinter.SaveToFile(saveFileDialog1.FileName, groupId);
            }
        }
        /*
        private void CreateStartListsButton_Click(object sender, EventArgs e)
        {
            CrateLists();
        }*/

        private int getGroupCountcomboBoxValue()
        {
            return int.Parse(GroupCountcomboBox.SelectedItem.ToString());
        }

        private void CalculateMinUsersPerGroup()
        {
            int participantsCount = treeView2.Nodes.Count;
            for (int a = 0; a < treeView1.Nodes.Count; a++)
            {
                TreeNode tn = treeView1.Nodes[a];
                participantsCount += tn.Nodes.Count;
            }
            double groupCountcomboBoxValueD = (double)getGroupCountcomboBoxValue();
            double minUsersPerGroupD = (double)participantsCount / groupCountcomboBoxValueD;
            int minUsersPerGroup = (int)Math.Floor(minUsersPerGroupD);
            if (minUsersPerGroup <= 0)
                minUsersPerGroup = 1;
            //if (MinParticipantsInGroupcomboBox1.Items.Count < minUsersPerGroup)
                //minUsersPerGroup = MinParticipantsInGroupcomboBox1.Items.Count;
            //MinParticipantsInGroupcomboBox1.SelectedIndex = minUsersPerGroup - 1;
            MinParticipantsInGroupLabel.Text = (minUsersPerGroup).ToString();
        }

        private void GroupCountcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateMinUsersPerGroup();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program napisany dla Krakowskiego Klubu Karate Tradycyjnego do generowania list startowych na turnieje. \r\n\r\nCopyright Tomasz Hachaj, Browarsoft ©  2017", "O programie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void zapiszJakHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintSetupForm psf = new PrintSetupForm(allGroups, ((Group)allGroups[SelectGroupComboBox.SelectedIndex]).id);
            psf.ShowDialog();
            if (psf.save)
            {
                CrateLists(psf.groupId);
            }
            //CrateLists();
        }

        private void usuńWSZYSTKIEPodgrupyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveTotallyAllGroups();
        }
        /*
        private void automatycznieUtwórzWSZYSKITPodgrupyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AutomaticSchedulingAll();
        }*/

        private void zarządzajKlubamiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClubsForm mcf = new ManageClubsForm();
            mcf.ShowDialog();
        }

        private void zawodnicyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String sql = "SELECT COUNT(id) FROM Klub";
            SQLiteConnection connection = Utils.getConnection();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            int countG = int.Parse(command.ExecuteScalar().ToString());
            if (countG > 0)
            {
                ManageParticipantsForm mpf = new ManageParticipantsForm(this.allGroups);
                mpf.ShowDialog();
                UpdateComponents();
            }
            else
            {
                MessageBox.Show("Dodaj najpierw co najmniej jeden klub.", "Edycja zawodników", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importujDaneZXLSXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opemFileDialog1 = new OpenFileDialog();
            opemFileDialog1.RestoreDirectory = true;

            String printDir = AppDomain.CurrentDomain.BaseDirectory;

            opemFileDialog1.InitialDirectory = printDir;
            opemFileDialog1.Filter = "xlsx file|*.xlsx";
            opemFileDialog1.Title = "Open Excel file";
            opemFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (opemFileDialog1.FileName != "")
            {
                toolStripProgressBar1.ToolTipText = "Import danych";
                XMLImporter(opemFileDialog1.FileName, false);
                /*toolStripProgressBar1.ToolTipText = "Import danych";
                this.Enabled = false;
                //Utils.ImportToDatabaseFromXLS("e:\\Projects\\Karate\\karta zgłoszeniowa_puchar_krakowa_test4.xlsx", false);
                String ff = opemFileDialog1.FileName;
                try
                {
                    String nazwaKlubu = "";
                    int count = Utils.ImportToDatabaseFromXLS(ff, false, ref nazwaKlubu);
                    MessageBox.Show("Dodano " + count + " uczestników z klubu " + nazwaKlubu + ".", "Import z Excela", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "Import z Excela", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                toolStripProgressBar1.ToolTipText = "Brak zadań";
                this.Enabled = true;*/
            }
        }


        private void XMLImporter(String fileName, bool nadpiszGrupy)
        {
            BackgroundWorker bw = new BackgroundWorker();

            // this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;



                
                EnabledForm(false);
                //Utils.ImportToDatabaseFromXLS("e:\\Projects\\Karate\\karta zgłoszeniowa_puchar_krakowa_test4.xlsx", false);
                try
                {
                    String NazwaKlubu = "";
                    int count = Utils.ImportToDatabaseFromXLS(fileName, false, ref NazwaKlubu, b);
                    MessageBox.Show("Dodano " + count + " uczestników z klubu " + NazwaKlubu + ".", "Import z Excela", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "Import z Excela", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {
                int progress = (int)(((double)toolStripProgressBar1.Maximum * (double)args.ProgressPercentage) / 100.0);
                toolStripProgressBar1.Value = progress;
                //label1.Text = string.Format("{0}% Completed", args.ProgressPercentage);
            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate(object o, RunWorkerCompletedEventArgs args)
            {
                //label1.Text = "Finished!";
                EnabledForm(true);
            });

            bw.RunWorkerAsync();
        }


        delegate void EnabledFormCallback(bool val);

        private void EnabledForm(bool val)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                EnabledFormCallback d = new EnabledFormCallback(EnabledForm);
                this.Invoke(d, new object[] { val });
            }
            else
            {
                this.Enabled = val;
            }
        }


        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }




        private void ScheduleToGroups(int groupCount, String groupName, int level, int typKonkurencji, Group parent)
        {
            BackgroundWorker bw = new BackgroundWorker();

            // this allows our worker to report progress during work
            bw.WorkerReportsProgress = true;

            // what to do in the background thread
            bw.DoWork += new DoWorkEventHandler(
            delegate(object o, DoWorkEventArgs args)
            {
                BackgroundWorker b = o as BackgroundWorker;




                EnabledForm(false);
                //Utils.ImportToDatabaseFromXLS("e:\\Projects\\Karate\\karta zgłoszeniowa_puchar_krakowa_test4.xlsx", false);

                String rezultat = Utils.SplitIntoSubGroups(groupCount, level, typKonkurencji, groupName, parent, b);
                //String rezultat = Utils.SplitIntoSubGroups(min, groupName, level, typKonkurencji, parent, b);

                if (rezultat != null)
                    MessageBox.Show(rezultat, "Podział na podgrupy", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //UpdateComponents();
            });

            // what to do when progress changed (update the progress bar for example)
            bw.ProgressChanged += new ProgressChangedEventHandler(
            delegate(object o, ProgressChangedEventArgs args)
            {
                int progress = (int)(((double)toolStripProgressBar1.Maximum * (double)args.ProgressPercentage) / 100.0);
                toolStripProgressBar1.Value = progress;
                //label1.Text = string.Format("{0}% Completed", args.ProgressPercentage);
            });

            // what to do when worker completes its task (notify the user)
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
            delegate(object o, RunWorkerCompletedEventArgs args)
            {
                //label1.Text = "Finished!";
                EnabledForm(true);
            });

            bw.RunWorkerAsync();
        }

        private void GroupsSchedulerForm_EnabledChanged(object sender, EventArgs e)
        {
            UpdateComponents();
        }
    }
}
