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
    }
}
