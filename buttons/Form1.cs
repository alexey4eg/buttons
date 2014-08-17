using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttons
{
    public partial class frmMain : Form
    {
        NewButtonForm buttonForm;
        EditTabForm editTabForm;
        List<List<ButtonModel>> buttons;

        public frmMain()
        {
            InitializeComponent();
            buttonForm = new NewButtonForm();
            editTabForm = new EditTabForm();
            LoadData();
            if (buttons.Count == 0)
            {
                buttons.Add(new List<ButtonModel>());
                CreateTab(Color.White);
            }
            else
                Render();
        }

        private void Render()
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                for(int j=0;j<buttons[i].Count; j++){
                    Button button = CreateButton(buttons[i][j]);
                    (tabControl1.TabPages[i].Controls[0] as Panel).Controls.Add(button);
                }
            }
        }

        private void LoadData()
        {
            String path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            String filename = Path.Combine(path, "configuration.txt");
            buttons = new List<List<ButtonModel>>();
            try
            {
                String[] inp;
                using (StreamReader infile = new StreamReader(filename))
                {
                    inp = infile.ReadLine().Split(' ');
                    int tabCount = int.Parse(inp[inp.Length-1]);
                    for (int i = 0; i < tabCount; i++)
                    {
                        
                        buttons.Add(new List<ButtonModel>());
                        inp = infile.ReadLine().Split(' ');
                        int buttonCount = int.Parse(inp[inp.Length - 1]);
                        Color tabColor = Color.FromArgb(int.Parse(inp[3]));

                        CreateTab(tabColor);
                        
                        for (int j = 0; j < buttonCount; j++)
                        {
                            inp = infile.ReadLine().Split(' ');
                            String name = "";
                            for (int k = 1; k <= inp.Length - 3; k++)
                            {
                                if (k>1)
                                    name=name+" ";
                                name = name + inp[k];
                            }
                            Color color = Color.FromArgb(int.Parse(inp[inp.Length - 1]));
                            int clicked = 0;// int.Parse(inp[inp.Length - 1]);
                            var button = new ButtonModel(name, color, clicked);
                            buttons[buttons.Count - 1].Add(button);
                            button.image = infile.ReadLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //не смог сохранить статистику
            }

            filename = Path.Combine(path, "stats.txt");
            try
            {
                using (StreamReader infile = new StreamReader(filename))
                {
                    for (int i = 0; i < tabControl1.TabPages.Count; i++)
                    {
                        if (i > 0)
                            infile.ReadLine();
                        infile.ReadLine();
                        for (int j = 0; j < buttons[i].Count; j++)
                        {
                            String[] inp = infile.ReadLine().Split(' ');
                            buttons[i][j].clicked = int.Parse(inp[inp.Length-1]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //не смог сохранить статистику
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                CreateButton();    
            }
            else if (e.Control && e.KeyCode == Keys.T)
            {

                CreateTabDialog();
            }
        }

        private void CreateTabDialog()
        {
            editTabForm.isNew = true;
            var res = editTabForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                CreateTab(editTabForm.color);
                buttons.Add(new List<ButtonModel>());
            }
        }

        private void CreateTab(Color color){
            var tab = new TabPage();
            tab.Text = (tabControl1.TabPages.Count + 1).ToString();
            tab.Controls.Add(new FlowLayoutPanel());
            tabControl1.TabPages.Add(tab);
            tab.Controls[0].Dock = DockStyle.Fill;
            tab.Controls[0].BackColor = color;
        }

        private void button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var model = button.Tag as ButtonModel;
            model.clicked++;
            if (!String.IsNullOrEmpty(model.image))
                new ImageForm(model.image).ShowDialog();
        }

        public static Color getForeColor(Color back)
        {

            if (back.GetBrightness() < 0.5)
                return Color.White;
            else
                return Color.Black;
        }

        private Button CreateButton(ButtonModel newButton)
        {
            var ret = new Button();
            ret.Text = newButton.name;
            ret.BackColor = newButton.color;
            ret.ForeColor = getForeColor(newButton.color);
            ret.Width = 200;
            ret.Height = 100;
            ret.Tag = newButton;
            ret.Font = new Font(ret.Font.FontFamily, ret.Font.Size * 2, GraphicsUnit.Pixel);
            ret.Click += button_Click;
            ret.ContextMenuStrip = contextMenuStrip1;
            return ret;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            String path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            String filename = Path.Combine(path, "configuration.txt");
            try
            {
                using (StreamWriter outfile = new StreamWriter(filename))
                {
                    outfile.WriteLine("Количество вкладок: {0}", tabControl1.TabPages.Count);
                    for (int i = 0; i < tabControl1.TabPages.Count; i++)
                    {
                        outfile.WriteLine("Вкладка {0}: цвет {1} кнопок {2}", i, tabControl1.TabPages[i].Controls[0].BackColor.ToArgb(), buttons[i].Count);
                        for (int j = 0; j < buttons[i].Count; j++)
                        {
                            outfile.WriteLine("Кнопка: {0} Цвет: {1}", buttons[i][j].name, buttons[i][j].color.ToArgb());
                            outfile.WriteLine(buttons[i][j].image);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //не смог сохранить статистику
            }

            filename = Path.Combine(path, "stats.txt");
            try
            {
                using (StreamWriter outfile = new StreamWriter(filename))
                {
                    for (int i = 0; i < tabControl1.TabPages.Count; i++)
                    {
                        if (i > 0)
                            outfile.WriteLine();
                        outfile.WriteLine("{0}", (i + 1).ToString());
                        for (int j = 0; j < buttons[i].Count; j++)
                        {
                            outfile.WriteLine("- {0} - {1}", buttons[i][j].name, buttons[i][j].clicked);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //не смог сохранить статистику
            }
        }

        private void CreateButton()
        {
            buttonForm.isNew = true;
            var res = buttonForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                ButtonModel newButton = new ButtonModel(buttonForm.name, buttonForm.color);
                buttons[tabControl1.SelectedIndex].Add(newButton);
                var button = CreateButton(newButton);
                (tabControl1.SelectedTab.Controls[0] as Panel).Controls.Add(button);
            }
        }



        private void создатьКнопкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateButton();
        }

        private void создатьВкладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateTabDialog();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl == null)
            {
                int index = (int)contextMenuStrip1.Tag;
                var panel = tabControl1.TabPages[index].Controls[0];
                editTabForm.isNew = false;
                editTabForm.color = panel.BackColor;
                var res = editTabForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    panel.BackColor = editTabForm.color;
                }
            }
            else if (contextMenuStrip1.SourceControl is Button)
            {
                var button = contextMenuStrip1.SourceControl as Button;
                var model = button.Tag as ButtonModel;
                buttonForm.isNew = false;
                buttonForm.color = button.BackColor;
                buttonForm.name = button.Text;
                var res = buttonForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    model.color = button.BackColor = buttonForm.color;
                    model.name = button.Text = buttonForm.name;
                    button.ForeColor = getForeColor(model.color);
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl == null)
            {
                int index = (int)contextMenuStrip1.Tag;
                tabControl1.TabPages.RemoveAt(index);
                buttons.RemoveAt(index);
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                    tabControl1.TabPages[i].Text = (i+1).ToString();
            }
            else if (contextMenuStrip1.SourceControl is Button)
            {
                int index = tabControl1.SelectedIndex;
                var button = contextMenuStrip1.SourceControl as Button;
                var model = button.Tag as ButtonModel;
                buttons[index].Remove(model);
                tabControl1.SelectedTab.Controls[0].Controls.Remove(button);

            }
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tabControl1.TabPages.Count == 0) return;

            if (e.Button == MouseButtons.Right)
            {
                bool shown = false;
                for (int i = 0; i < tabControl1.TabPages.Count; ++i)
                {
                    Rectangle r = tabControl1.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {

                        contextMenuStrip1.Tag = i;
                        contextMenuStrip1.Show(tabControl1.PointToScreen(e.Location));
                        shown = true;
                        break;
                    }
                }

                if (!shown)
                {
                    contextMenuStrip1.Tag = tabControl1.SelectedIndex;
                    contextMenuStrip1.Show(tabControl1.PointToScreen(e.Location));
                }
            }
        }

        private void очиститьСтатистикуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.Count; i++)
                for (int j = 0; j < buttons[i].Count; j++)
                    buttons[i][j].clicked = 0;
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmHelp().ShowDialog();
        }

        private void menuBindImage_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl is Button){
                var dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var button = contextMenuStrip1.SourceControl as Button;
                    var model = button.Tag as ButtonModel;
                    model.image = dlg.FileName;
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (contextMenuStrip1.SourceControl is Button)
                menuBindImage.Visible = true;
            else
                menuBindImage.Visible = false;
        }

        private void матрицаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MatrixForm().ShowDialog();
        }
    }
}
