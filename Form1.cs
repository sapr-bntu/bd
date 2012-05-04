using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bd_osan_
{
    public partial class Form1 : Form
    {
        //SqlCommandBuilder commands;
        SqlCommand command;

        public Form1()
        {
            InitializeComponent();
            command = new SqlCommand("", table_1TableAdapter.Connection);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.table_1TableAdapter.Fill(this.osanbdDataSet.Table_1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.table_1TableAdapter.Update(this.osanbdDataSet.Table_1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            table_1TableAdapter.Connection.Open();
            command.CommandText = "TRUNCATE TABLE table_1";
            command.ExecuteNonQuery();
            command.CommandText ="INSERT INTO table_1 VALUES (0,'1','-1',	1,-1);  "
                +"INSERT INTO table_1 VALUES (1,'11','1',2,4);  "
                + "INSERT INTO table_1 VALUES (2,'111','11',	-1,-1);  "
                + "INSERT INTO table_1 VALUES (3,'12','2',5,14);  "
                + "INSERT INTO table_1 VALUES (4,	'12',	'1',	5,	7);  "
                + "INSERT INTO table_1 VALUES (5,	'121',	'12',	-1,	6);  "
                + "INSERT INTO table_1 VALUES (6,	'122',	'12',	8,	-1);  "
                + "INSERT INTO table_1 VALUES (7,	'13',	'1',	12,	-1);  "
                + "INSERT INTO table_1 VALUES (8,	'1221',	'122',	-1,	9);  "
                + "INSERT INTO table_1 VALUES (9,	'1222',	'122',	10,	-1);  "
                + "INSERT INTO table_1 VALUES (10,	'122а',	'1222',	-1,	11);  "
                + "INSERT INTO table_1 VALUES (11,	'122б',	'1222',	-1,	-1);  "
                + "INSERT INTO table_1 VALUES (12,	'1221',	'13',	-1,	13);  "
                + "INSERT INTO table_1 VALUES (13,	'1222',	'13',	10,	-1);  "
                + "INSERT INTO table_1 VALUES (14,	'21',	'2',	17,	-1);  "
                + "INSERT INTO table_1 VALUES (15,	'221',	'21',	16,	-1);  "
                + "INSERT INTO table_1 VALUES (16,	'1222',	'221',	10,	-1);  "
                + "INSERT INTO table_1 VALUES (17,	'13',	'21',	12,	15);  ";

            command.ExecuteNonQuery();
            this.table_1TableAdapter.Fill(this.osanbdDataSet.Table_1);
            table_1TableAdapter.Connection.Close();
        }

        List<string> names = new List<string>();
        List<int> keys = new List<int>();
        int currkey,bro;
        bool NO;
        Label m1,m2;


        private void button3_Click(object sender, EventArgs e)
        {
            keys.Add(Convert.ToInt32(maskedTextBox1.Text));
            currkey = Convert.ToInt32(maskedTextBox1.Text);
            NO = true;
            m1:
            if (NO)
            {
                names.Add(dataGridView1.Rows[currkey].Cells[1].Value.ToString());
                if (Convert.ToInt32(dataGridView1.Rows[currkey].Cells[3].Value) != -1)
                {
                    keys.Add(currkey);
                    currkey = Convert.ToInt32(dataGridView1.Rows[currkey].Cells[3].Value);
                    goto m1;
                }
                else
                {
                    NO = true;
                    if (Convert.ToInt32(dataGridView1.Rows[currkey].Cells[4].Value) != -1)
                    {
                        currkey = Convert.ToInt32(dataGridView1.Rows[currkey].Cells[4].Value);
                        goto m1;
                    }
                    else
                    {
                        NO = false;
                        currkey = keys.Last();
                        goto m1;
                    }
                }
            }
            else
            {
                
                NO = true;
                if (Convert.ToInt32(dataGridView1.Rows[currkey].Cells[4].Value) != -1 && Convert.ToInt32(dataGridView1.Rows[currkey].Cells[4].Value)!=bro)
                {
                    currkey = Convert.ToInt32(dataGridView1.Rows[currkey].Cells[4].Value);
                    goto m1;
                }
                else
                {
                    NO = false;
                    keys.RemoveAt(keys.Count - 1);
                    bro = currkey;
                    if (keys.Count != 0)
                        currkey = keys.Last();
                    else goto m2;
                    goto m1;
                }
            }
            m2:
            int i=0;
            foreach (string item in names)
            {
                textBox1.Text +=i.ToString()+") "+ item+Environment.NewLine;
                i++;
            }
        }
        
        

    }
}
