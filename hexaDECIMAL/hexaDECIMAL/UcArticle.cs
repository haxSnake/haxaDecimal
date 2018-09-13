using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Sockets;

namespace hexaDECIMAL
{
    public partial class UcArticle : UserControl
    {

        Button[] btnButtons = new Button[25];
        List<articleClass> articleList = new List<articleClass>();
        private Label labelAuthor;
        private Label labelTitle;
        private Label labelDate;
        private Label labelText;
        private CustomInstaller customInstaller1;
        articleClass[] articleArray;

        public UcArticle()
        {
            InitializeComponent();
        }

        private void UcArticle_Load(object sender, EventArgs e)
        {
            //ONLINE MODE

            try
            {
                //OPEN MYSQL CONNECTION
                using (MySqlConnection con = new MySqlConnection(databaseOperations.mysqlDatasource))
                {
                    con.Open();
                    //PULL DATA FROM MYSQL DB
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "select * from article";

                    //CREATE ADAPTER AND TABLE TO PROCESS DATA
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    //PREPARE BUTTON DIMENSIONS
                    int btnWidth = 180;
                    int btnHeight = ClientSize.Height / 25;
                    int btnLeft = 0;
                    int btnTop = ClientSize.Height - (25 * btnHeight);

                    //GENERATE BUTTONS AND MANAGE ARTICLE DATA
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //TAKE ARTICLE INFO
                        articleClass article = new articleClass("", "", "", "")
                        {
                            ArtTitle = dt.Rows[i]["artTitle"].ToString(),
                            ArtText = dt.Rows[i]["artText"].ToString(),
                            ArtAuthor = dt.Rows[i]["artAuthor"].ToString(),
                            ArtDate = dt.Rows[i]["artDate"].ToString()
                        };

                        //COPY ARTICLE TO THE LIST
                        articleList.Add(article);

                        //CREATE BUTTON
                        btnButtons[i] = new Button();
                        btnButtons[i].Text = article.ArtTitle; //VISIBLE BUTTON TEXT
                        btnButtons[i].Width = btnWidth;
                        btnButtons[i].Height = btnHeight;
                        btnButtons[i].Left = btnLeft;
                        btnButtons[i].Top = btnTop;
                        btnButtons[i].BringToFront();
                        btnButtons[i].BackColor = Color.FromArgb(25, 96, 23);
                        btnButtons[i].ForeColor = Color.White;
                        btnButtons[i].TabStop = false;
                        btnButtons[i].FlatStyle = FlatStyle.Flat;
                        btnButtons[i].FlatAppearance.BorderSize = 0;
                        btnButtons[i].FlatAppearance.BorderColor = Color.FromArgb(25, 96, 23);
                        btnButtons[i].Font = new Font("Century Gothic", 12);
                        Controls.Add(btnButtons[i]);
                        btnButtons[i].Click += new EventHandler(btnMySQL_Click);
                        btnTop += btnHeight;
                    }
                }
                //MOVE ARTICLES TO AN ARRAY
                articleArray = articleList.ToArray();

                //PRESENT FIRST ARTICLE ON INITIAL LOAD
                labelTitle.Text = articleArray[0].ArtTitle;
                labelText.Text = articleArray[0].ArtText;
                labelAuthor.Text = articleArray[0].ArtAuthor;
                labelDate.Text = articleArray[0].ArtDate; 

            }
            catch (SocketException ex)
            {
                if (databaseOperations.errorMsg == false)
                {
                    MessageBox.Show(ex.Message, "Connection error");
                    databaseOperations.errorMsg = true;
                }
            }
            catch (Exception ex)
            {
                if (databaseOperations.errorMsg == false)
                {
                    MessageBox.Show(ex.Message, "ERROR!");
                    databaseOperations.errorMsg = true;
                }
            }
        }

        //EVENT HANDLER
        private void btnMySQL_Click(object sender, EventArgs e)
        {
            //USE BUTTON TEXT TO SWITCH BETWEEN ARTICLE
            Button clickedButton = (Button)sender;
            switch (clickedButton.Text)
            {
                default:
                    for (int i = 0; i < articleArray.Length; i++)
                    {
                        if (clickedButton.Text.Equals(articleArray[i].ArtTitle))
                        {
                            //PULL ARTICLE DATA
                            labelTitle.Text = articleArray[i].ArtTitle;
                            labelAuthor.Text = articleArray[i].ArtAuthor;
                            labelText.Text = articleArray[i].ArtText;
                            labelDate.Text = articleArray[i].ArtDate;
                        }
                    }
                    break;
            }
        }

        private void InitializeComponent()
        {
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelText = new System.Windows.Forms.Label();
            this.customInstaller1 = new MySql.Data.MySqlClient.CustomInstaller();
            this.SuspendLayout();
            // 
            // labelAuthor
            // 
            this.labelAuthor.Font = new System.Drawing.Font("Century Gothic", 15.6F);
            this.labelAuthor.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAuthor.Location = new System.Drawing.Point(784, 39);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(323, 33);
            this.labelAuthor.TabIndex = 8;
            this.labelAuthor.Text = "Author";
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Century Gothic", 15.6F);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTitle.Location = new System.Drawing.Point(311, 39);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(450, 33);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "Title";
            // 
            // labelDate
            // 
            this.labelDate.Font = new System.Drawing.Font("Century Gothic", 15.6F);
            this.labelDate.ForeColor = System.Drawing.SystemColors.Control;
            this.labelDate.Location = new System.Drawing.Point(1144, 39);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(207, 33);
            this.labelDate.TabIndex = 6;
            this.labelDate.Text = "Date";
            // 
            // labelText
            // 
            this.labelText.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.labelText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelText.Location = new System.Drawing.Point(312, 123);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(1039, 674);
            this.labelText.TabIndex = 5;
            this.labelText.Text = "Text";
            // 
            // UcArticle
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(154)))), ((int)(((byte)(70)))));
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelText);
            this.Name = "UcArticle";
            this.Size = new System.Drawing.Size(1468, 837);
            this.Load += new System.EventHandler(this.UcArticle_Load);
            this.ResumeLayout(false);

        }
    }
}
