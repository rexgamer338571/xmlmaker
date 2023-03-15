using System;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using RestSharp;
using Newtonsoft.Json.Linq;

using XMLMaker;

namespace XMLMaker
{
    public partial class Form1 : Form
    {
        public static bool hasStarted;
        public static string fileLoc;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string xmlString = "<ITEM><ITEMTYPE>P</ITEMTYPE><ITEMID>" + this.textBox1.Text + "</ITEMID><COLOR>" + this.textBox2.Text + "</COLOR><QTY>" + this.textBox5.Text + "</QTY><PRICE>" + this.textBox4.Text + "</PRICE><CONDITION>" + this.textBox6.Text + "</CONDITION></ITEM>";

            if (hasStarted)
            {
                using (StreamWriter writer = new StreamWriter(fileLoc, true))
                {
                    writer.WriteLine(xmlString);
                }
            }

            button1.Text = "Dodano!";
            button1.BackColor = Color.White;
            button1.Enabled = false;
            Task.Delay(5000).ContinueWith(_ =>
            {
                button1.Invoke(new Action(() =>
                {
                    button1.Enabled = true;
                    button1.Text = "Dodaj";
                    button1.BackColor = Color.Black;
                }));
            });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
            dialog.Title = "Zapisz plik XMLM";
            DialogResult result = dialog.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                fileLoc = dialog.FileName;
                using (StreamWriter writer = new StreamWriter(fileLoc, true))
                {
                    writer.WriteLine("<INVENTORY>");
                }
                hasStarted = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

            this.Size = new Size(500, 489);

            FontConverter fontConverter = new FontConverter();
            Font font = (Font)fontConverter.ConvertFromString("Microsoft YaHei UI, 26.25pt");
            Font textBoxFont = (Font)fontConverter.ConvertFromString("Microsoft YaHei UI, 20.25pt");

            #region Labels

            Label settingLabel = new Label();
            settingLabel.Text = "Ustawienia (WIP)";
            settingLabel.Location = new Point(16, 16);
            settingLabel.Size = new Size(500, 46);
            this.Controls.Add(settingLabel);

            Label fontColorLabel = new Label();
            fontColorLabel.Text = "Kolor czcionki";
            fontColorLabel.Location = new Point(16, 65);
            fontColorLabel.Size = new Size(252, 46);
            this.Controls.Add(fontColorLabel);

            Label inputBackColorLabel = new Label();
            inputBackColorLabel.Text = "Kolor wejścia";
            inputBackColorLabel.Location = new Point(16, 106);
            inputBackColorLabel.Size = new Size(237, 46);
            this.Controls.Add(inputBackColorLabel);

            Label backColorLabel = new Label();
            backColorLabel.Text = "Kolor tła";
            backColorLabel.Location = new Point(16, 147);
            backColorLabel.Size = new Size(159, 46);
            this.Controls.Add(backColorLabel);

            #endregion Labels

            #region Inputs

            TextBox fontColorInput = new TextBox();
            fontColorInput.Location = new Point(272, 65);
            this.Controls.Add(fontColorInput);

            TextBox inputBackColorInput = new TextBox();
            inputBackColorInput.Location = new Point(272, 106);
            this.Controls.Add(inputBackColorInput);

            
            TextBox backColorInput = new TextBox();
            backColorInput.Location = new Point(272, 147);
            this.Controls.Add(backColorInput);

            #endregion Inputs

            #region Buttons

            Button saveSettings = new Button();
            saveSettings.Text = "Zapisz ustawienia";
            saveSettings.Location = new Point(26, 208);
            this.Controls.Add(saveSettings);

            Button backToMain = new Button();
            backToMain.Text = "Powrót";
            backToMain.Location = new Point(26, 265);
            backToMain.Click += new EventHandler(backToMain_Click);
            this.Controls.Add(backToMain);

            #endregion Buttons

            foreach (Control control in this.Controls)
            {
                control.ForeColor = Color.White;
                control.Font = font;

                string type = control.GetType().Name;

                if (type == "TextBox") 
                {
                    control.ForeColor = Color.Black;
                    control.Font = textBoxFont;
                    control.Size = new Size(200, 46);
                } else if (type == "Button") 
                {
                    control.Size = new Size(448, 57);
                }
            }
        }
        private void backToMain_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
        }

        /*
        private void saveSettings_Click(object sender, EventArgs e)
        {
            string settingsLoc = "C:\\NG5M\\XMLMaker4\\0\\settings";

            if (!File.Exists(settingsLoc + "\\labelFontColor.xmlms"))
            {
                using(FileStream fs = File.Create(settingsLoc + "\\labelFontColor.xmlms"))
                {
                    using(StreamWriter writer = new StreamWriter(settingsLoc + "\\labelFontColor.xmlms"))
                    {
                        writer.WriteLine(this.Controls.Find("fontColorInput", true));
                    }
                }
            }
        }
        
        private void LoadBLImg(string number)
        {
            var client = new RestClient("https://api.bricklink.com");
            var request = new RestRequest("items/{type}/{no}/images/{color_id}", Method.Get);
            request.AddUrlSegment("type", "P");
            request.AddUrlSegment("number", number);
            request.AddHeader("Authorization", "Bearer 7CCDCEF257CF43D89A74A7E39BEAA1E1");
            var response = client.Execute(request);

            var jsonResponse = JObject.Parse(response.Content);
            var imgURL = jsonResponse["data"]["item"]["images"][0]["thumbnail_url"];

            pictureBox1.Load(imgURL.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadBLImg("3003");
        }
        
        private void applySettings(object sender, EventArgs e)
        {
            backColor = ColorTranslator.FromHtml(backColorInput.Text);
            BackColor = backColor;

            fontColor = ColorTranslator.FromHtml(fontColorInput.Text);
            ForeColor = fontColor;

            inputColor = ColorTranslator.FromHtml(inputBackColorInput.Text);

        }
        */

    }
}
