using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testone
{
    public partial class Form1 : Form
    {
        int totalMBct = 0;
        int totalMBct1 = 0;
        int count = 1;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {     
            listView1.View = View.Details;
            listView1.Columns.Add("P#", 80);
            listView1.Columns.Add("Size all in MB", 80);
            listView1.Columns.Add("Allocation Bit", 92);
            ListViewItem item1 = new ListViewItem("Free Space");
            SetHeight(listView1, 256);
            item1.BackColor = Color.Yellow;
            item1.UseItemStyleForSubItems = false;
            item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1,
            "1000", Color.Black, Color.Yellow, item1.Font));
            item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1,
            "        0", Color.Black, Color.White, item1.Font));
            listView1.Items.Add(item1);
        }

        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView1.SmallImageList = imgList;
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (listView1.Items.Cast<ListViewItem>().Any(i => i.SubItems[2].Text.ToLower().Contains("        1")) && listView1.Items.Cast<ListViewItem>().Any(i => i.SubItems[1].Text.ToLower().Contains("1000")))
            {
                string content = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text;
                int newTotalct = int.Parse(content);
                listView1.Items.Remove(listView1.FocusedItem);
                ListViewItem item3 = new ListViewItem("Free Space");
                item3.BackColor = Color.Yellow;
                item3.UseItemStyleForSubItems = false;
                item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                content, Color.Black, Color.Yellow, item3.Font));
                item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                "        0", Color.Black, Color.White, item3.Font));
                listView1.Items.Insert(0, item3);
                totalMBct1 += newTotalct;
                SetHeight(listView1, 256 / listView1.Items.Count);
                if (button1.Enabled == false)
                {
                    MessageBox.Show("Enabling button again memory less then full!");
                    button1.Enabled = true;
                }
            }

            if (listView1.SelectedItems.Count == 1)
            { 
                int iIndex = listView1.SelectedItems[0].Index;
                string content = listView1.Items[listView1.SelectedIndices[0]].SubItems[1].Text;
                int newTotalct = int.Parse(content);
                if (iIndex == 0 && listView1.Items.Count >=2 )
                {
                     string contentSelect = listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text;
                    int TotalFsCt1 = int.Parse(content);
                    string contentBelow = listView1.Items[listView1.SelectedIndices[0] + 1].SubItems[0].Text;
                    string NumCellBelow = listView1.Items[listView1.SelectedIndices[0] + 1].SubItems[1].Text;
                    int TotalFsCtBelow1 = int.Parse(NumCellBelow);
                    int TotalFsCtBelow = TotalFsCt1 + TotalFsCtBelow1;
                    if (contentSelect == "        1" && contentBelow != "Free Space")
                    {
                        listView1.Items.Remove(listView1.FocusedItem);
                        ListViewItem item3 = new ListViewItem("Free Space");
                        item3.BackColor = Color.Yellow;
                        item3.UseItemStyleForSubItems = false;
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        content, Color.Black, Color.Yellow, item3.Font));
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        "        0", Color.Black, Color.White, item3.Font));
                        listView1.Items.Insert(iIndex, item3);
                        totalMBct1 += newTotalct;
                        SetHeight(listView1, 256 / listView1.Items.Count);
                        
                        if (button1.Enabled == false)
                        {
                            MessageBox.Show("Enabling button again memory less then full!");
                            button1.Enabled = true;
                        }
                    }
                    else if (contentSelect == "        1" && contentBelow == "Free Space")
                    {
                        string Below = TotalFsCtBelow.ToString();
                        listView1.Items[iIndex + 1].Remove();
                        listView1.Items.Remove(listView1.FocusedItem);
                        ListViewItem item3 = new ListViewItem("Free Space");
                        item3.BackColor = Color.Yellow;
                        item3.UseItemStyleForSubItems = false;
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        Below, Color.Black, Color.Yellow, item3.Font));
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        "        0", Color.Black, Color.White, item3.Font));
                        listView1.Items.Insert(0, item3);
                        totalMBct1 += newTotalct;
                        SetHeight(listView1, 256 / listView1.Items.Count);

                        if (button1.Enabled == false)
                        {
                            MessageBox.Show("Enabling button again memory less then full!");
                            button1.Enabled = true;
                        }
                    }

                }
               else if (iIndex == listView1.Items.Count-1 && listView1.Items.Count >= 2)
               {

                    string contentSelect = listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text;
                    int TotalFsCt1 = int.Parse(content);
                    string contentAbove = listView1.Items[listView1.SelectedIndices[0] - 1].SubItems[0].Text;
                    string NumCellAbove = listView1.Items[listView1.SelectedIndices[0] - 1].SubItems[1].Text;
                    int TotalFsCtAbove1 = int.Parse(NumCellAbove);
                    int TotalFsCtAbove = TotalFsCt1 + TotalFsCtAbove1;

                    if (contentSelect == "        1" && contentAbove != "Free Space")
                    {
                        listView1.Items.Remove(listView1.FocusedItem);
                        ListViewItem item3 = new ListViewItem("Free Space");
                        item3.BackColor = Color.Yellow;
                        item3.UseItemStyleForSubItems = false;
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        content, Color.Black, Color.Yellow, item3.Font));
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        "        0", Color.Black, Color.White, item3.Font));
                        listView1.Items.Add(item3);
                        totalMBct1 += newTotalct;
                        SetHeight(listView1, 256 / listView1.Items.Count);

                        if (button1.Enabled == false)
                        {
                            MessageBox.Show("Enabling button again memory less then full!");
                            button1.Enabled = true;
                        }
                    }
                    else if (contentSelect == "        1" && contentAbove == "Free Space")
                    {
                        string Above = TotalFsCtAbove.ToString();
                        listView1.Items[iIndex - 1].Remove();
                        listView1.Items.Remove(listView1.FocusedItem);
                        ListViewItem item3 = new ListViewItem("Free Space");
                        item3.BackColor = Color.Yellow;
                        item3.UseItemStyleForSubItems = false;
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        Above, Color.Black, Color.Yellow, item3.Font));
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        "        0", Color.Black, Color.White, item3.Font));
                        listView1.Items.Add(item3);
                        totalMBct1 += newTotalct;
                        SetHeight(listView1, 256 / listView1.Items.Count);
                        if (button1.Enabled == false)
                        {
                            MessageBox.Show("Enabling button again memory less then full!");
                            button1.Enabled = true;
                        }
                    }
               }

                if (iIndex>=1&&listView1.Items.Count >= 3&& iIndex != listView1.Items.Count - 1&&iIndex!=0)
                {                
                    string contentSelect = listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text;
                    int TotalFsCt1 = int.Parse(content);
                    string contentAbove = listView1.Items[listView1.SelectedIndices[0] - 1].SubItems[2].Text;
                    string contentBelow = listView1.Items[listView1.SelectedIndices[0] + 1].SubItems[2].Text;
                    string NumCellAbove = listView1.Items[listView1.SelectedIndices[0] - 1].SubItems[1].Text;
                    string NumCellBelow = listView1.Items[listView1.SelectedIndices[0] + 1].SubItems[1].Text;
                    int TotalFsCtAbove1 = int.Parse(NumCellAbove);
                    int TotalFsCtBelow1 = int.Parse(NumCellBelow);
                    int TotalFsCtAbove = TotalFsCt1 + TotalFsCtAbove1;
                    int TotalFsCtBelow = TotalFsCt1 + TotalFsCtBelow1;
                    int TotalFsCt = TotalFsCt1 + TotalFsCtAbove1 + TotalFsCtBelow1;
                    if (contentAbove == "        0" && contentSelect == "        1" && contentBelow == "        0")
                    {
                        string Total = TotalFsCt.ToString();
                        listView1.Items[iIndex+1].Remove();
                        listView1.Items[iIndex - 1].Remove();
                        listView1.Items.Remove(listView1.FocusedItem);
                        ListViewItem item3 = new ListViewItem("Free Space");
                        item3.BackColor = Color.Yellow;
                        item3.UseItemStyleForSubItems = false;
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        Total, Color.Black, Color.Yellow, item3.Font));
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        "        0", Color.Black, Color.White, item3.Font));
                        listView1.Items.Insert(iIndex-1, item3);
                        totalMBct1 += newTotalct;
                        SetHeight(listView1, 256 / listView1.Items.Count);
                        if (button1.Enabled == false)
                        {
                            MessageBox.Show("Enabling button again memory less then full!");
                            button1.Enabled = true;
                        }
                    }

                    if (contentAbove == "        0" && contentSelect == "        1" && contentBelow == "        1")
                    {
                        string Above = TotalFsCtAbove.ToString();
                        listView1.Items[iIndex-1].Remove();
                        listView1.Items.Remove(listView1.FocusedItem);
                        ListViewItem item3 = new ListViewItem("Free Space");
                        item3.BackColor = Color.Yellow;
                        item3.UseItemStyleForSubItems = false;
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        Above, Color.Black, Color.Yellow, item3.Font));
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        "        0", Color.Black, Color.White, item3.Font));
                        listView1.Items.Insert(iIndex-1, item3);
                        totalMBct1 += newTotalct;
                        SetHeight(listView1, 256 / listView1.Items.Count);
                        if (button1.Enabled == false)
                        {
                            MessageBox.Show("Enabling button again memory less then full!");
                            button1.Enabled = true;
                        }
                    }
                    if (contentAbove == "        1" && contentSelect == "        1" && contentBelow == "        0")
                    {
                        string Below = TotalFsCtBelow.ToString();
                        listView1.Items[iIndex].Remove();
                        listView1.Items.Remove(listView1.FocusedItem);
                        ListViewItem item3 = new ListViewItem("Free Space");
                        item3.BackColor = Color.Yellow;
                        item3.UseItemStyleForSubItems = false;
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        Below, Color.Black, Color.Yellow, item3.Font));
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        "        0", Color.Black, Color.White, item3.Font));
                        listView1.Items.Insert(iIndex, item3);
                        totalMBct1 += newTotalct;
                        SetHeight(listView1, 256 / listView1.Items.Count);
                        if (button1.Enabled == false)
                        {
                            MessageBox.Show("Enabling button again memory less then full!");
                            button1.Enabled = true;
                        }
                    }
                    if (contentAbove == "        1" && contentSelect == "        1" && contentBelow == "        1")
                    {
                        listView1.Items.Remove(listView1.FocusedItem);
                        ListViewItem item3 = new ListViewItem("Free Space");
                        item3.BackColor = Color.Yellow;
                        item3.UseItemStyleForSubItems = false;
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        content, Color.Black, Color.Yellow, item3.Font));
                        item3.SubItems.Add(new ListViewItem.ListViewSubItem(item3,
                        "        0", Color.Black, Color.White, item3.Font));
                        listView1.Items.Insert(iIndex, item3);
                        totalMBct1 += newTotalct;
                        SetHeight(listView1, 256 / listView1.Items.Count);
                        if (button1.Enabled == false)
                        {
                            MessageBox.Show("Enabling button again memory less then full!");
                            button1.Enabled = true;
                        }
                    }
                }
                
            }
            count = 1;
            MessageBox.Show("Totalmbct " + totalMBct + "Totalmbct " + totalMBct1 + "Count" + count);
        }

    private void button1_Click(object sender, EventArgs e)
        {
            totalMBct -= totalMBct1;
            totalMBct1 = 0;
            MessageBox.Show("Totalmbct " + totalMBct + "Totalmbct " + totalMBct1 + "Count" + count);
            int userVal = int.Parse(textBox1.Text);
            totalMBct += userVal;
            if (totalMBct1 > 1000||totalMBct1 < 0)
            {   
                totalMBct = 0;
            }

            MessageBox.Show("Totalmbct " + totalMBct + "Totalmbct " + totalMBct1+"Count"+count);
            int NewFs = 1000 - totalMBct;         
            string NewFs1 = NewFs.ToString();
            if (totalMBct == 1000)
            {
                MessageBox.Show("The memory is Full no more entries!");
                button1.Enabled = false;
            }
            else if (totalMBct > 1000)
            {
                MessageBox.Show("You entered an amount over the Size limit by " + NewFs + "Putting in Correct Amount!");
                int NewTextbox = NewFs + userVal;
                textBox1.Text = NewTextbox.ToString();
            }

            if (listView1.Items.Cast<ListViewItem>().Any(i => i.SubItems[2].Text.ToLower().Contains("        0"))&& listView1.Items.Cast<ListViewItem>().Any(i => i.SubItems[1].Text.ToLower().Contains("1000")))
            {
                if (count == 1)
                {
                    listView1.Items.Clear();
                }
                ListViewItem item = new ListViewItem();
                item.Text = "P" + count;
                item.BackColor = Color.LightSteelBlue;
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item,
                textBox1.Text, Color.Black, Color.LightSteelBlue, item.Font));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item,
                "        1", Color.Black, Color.White, item.Font));
                listView1.Items.Insert(listView1.Items.Count, item);
                SetHeight(listView1, 256 / listView1.Items.Count);

                ListViewItem item2 = new ListViewItem("Free Space");
                item2.BackColor = Color.Yellow;
                item2.UseItemStyleForSubItems = false;
                item2.SubItems.Add(new ListViewItem.ListViewSubItem(item2,
                NewFs1, Color.Black, Color.Yellow, item2.Font));
                item2.SubItems.Add(new ListViewItem.ListViewSubItem(item2,
                "        0", Color.Black, Color.White, item2.Font));
                listView1.Items.Insert(listView1.Items.Count, item2);
                SetHeight(listView1, 256 / listView1.Items.Count);
                if (NewFs <= 0)
                {
                    NewFs = 0;
                    listView1.Items[listView1.Items.Count - 1].Remove();
                    SetHeight(listView1, 256 / listView1.Items.Count);
                    count = 1;
                }
            }

                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    int z = 1;

                if (listView1.Items[i].SubItems[2].Text.Contains("        0") && i < listView1.Items.Count - 1)
                {
                    string ContentDeleteRow = listView1.Items[i].SubItems[z].Text;
                    int TotalFsCtAbove1 = int.Parse(ContentDeleteRow);
                    if (count==1)
                    {
                        count++;
                    }
                    if (userVal <= TotalFsCtAbove1)
                    { 
                        listView1.Items[i].Remove();
                        MessageBox.Show("12   " + NewFs);
                        ListViewItem item = new ListViewItem();
                        item.Text = "P" + count;
                        item.BackColor = Color.LightSteelBlue;
                        item.UseItemStyleForSubItems = false;
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item,
                        textBox1.Text, Color.Black, Color.LightSteelBlue, item.Font));
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item,
                        "        1", Color.Black, Color.White, item.Font));
                        listView1.Items.Insert(i, item);
                        SetHeight(listView1, 256 / listView1.Items.Count);
                    }
                    else if(userVal > TotalFsCtAbove1)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = "P" + count;
                        item.BackColor = Color.LightSteelBlue;
                        item.UseItemStyleForSubItems = false;
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item,
                        textBox1.Text, Color.Black, Color.LightSteelBlue, item.Font));
                        item.SubItems.Add(new ListViewItem.ListViewSubItem(item,
                        "        1", Color.Black, Color.White, item.Font));
                        listView1.Items.Insert(listView1.Items.Count - 1, item);
                        SetHeight(listView1, 256 / listView1.Items.Count);

                        if (listView1.Items[listView1.Items.Count - 1].SubItems[0].Text == "Free Space")
                        { int NewFsCom= int.Parse(NewFs1);
                            NewFsCom -= TotalFsCtAbove1;
                            
                            listView1.Items[listView1.Items.Count - 1].SubItems[1].Text = NewFsCom.ToString(); 
                            if (NewFs <= 0)
                            {
                                NewFs = 0;
                                listView1.Items[listView1.Items.Count - 1].Remove();
                                SetHeight(listView1, 256 / listView1.Items.Count);
                                count = 1;
                            }
                        }
                        break;
                    }
                    z++;

                }
                if (listView1.Items[listView1.Items.Count - 1].SubItems[0].Text == "Free Space" && count > 1)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = "P" + count;
                    item.BackColor = Color.LightSteelBlue;
                    item.UseItemStyleForSubItems = false;
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item,
                    textBox1.Text, Color.Black, Color.LightSteelBlue, item.Font));
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item,
                    "        1", Color.Black, Color.White, item.Font));
                    listView1.Items.Insert(listView1.Items.Count - 1, item);
                    SetHeight(listView1, 256 / listView1.Items.Count);

                    if (listView1.Items[listView1.Items.Count - 1].SubItems[0].Text == "Free Space")
                    {
                        listView1.Items[listView1.Items.Count - 1].SubItems[1].Text = NewFs1;
                        if (NewFs <= 0)
                        {
                            NewFs = 0;
                            listView1.Items[listView1.Items.Count - 1].Remove();
                            SetHeight(listView1, 256 / listView1.Items.Count);
                            count = 1;
                        }
                    }
                    break;
                }
            }
            textBox1.Clear();
            count++;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int TotalFsCtAbove2 = 0;
            string LastRow=listView1.Items[listView1.Items.Count - 1].SubItems[1].Text;
            int Lastrow = int.Parse(LastRow);
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                int z = 1;            
                if (listView1.Items[i].SubItems[2].Text.Contains("        0"))
                {
                    if (i != listView1.Items.Count - 1)
                    {
                        string ContentDeleteRow = listView1.Items[i].SubItems[z].Text;
                        int TotalFsCtAbove1 = int.Parse(ContentDeleteRow);
                        TotalFsCtAbove2 += TotalFsCtAbove1;          
                        listView1.Items[i].Remove();
                        SetHeight(listView1, 256 / listView1.Items.Count);
                        
                    }
                }
                z++;              
            }
            Lastrow += TotalFsCtAbove2;
            listView1.Items[listView1.Items.Count - 1].SubItems[1].Text = Lastrow.ToString();
        }
    }
}
