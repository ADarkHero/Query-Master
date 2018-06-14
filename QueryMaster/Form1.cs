using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueryMaster
{
    public partial class Form1 : Form
    {
        string sqlfolder = "Z:\\Automatisierung\\sql";
        string seperator = ";";
        Boolean addHeadline = true;
        Boolean readLineFromDB = false;

        public Form1()
        {
            String[] arguments = Environment.GetCommandLineArgs(); //Read Parameters
            if(arguments.Length > 1) //Was the program called with parameters?
            {
                executeQuery(arguments[1]); //If there was a paramter -> execute the query with it.
                Environment.Exit(1);
            }
            else
            {
                InitializeComponent();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] sqlqueries = Directory.GetFiles(sqlfolder);

            foreach(string sql in sqlqueries)
            {
                string filename = Path.GetFileName(sql);
                sqlListView.Items.Add(filename);
            }
        }

        private void sqlListView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string sqlFileName = sqlListView.SelectedItems[0].SubItems[0].Text;
                executeQuery(sqlFileName);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void executeQuery(string sqlFileName)
        {
            try
            {
                OdbcDataReader dr = ConnectToSQLDatabase(sqlFileName);

                int drlenght = dr.FieldCount;
                string csv = "";
                if (addHeadline)
                {
                    csv = readSQLHeadline(dr, drlenght, csv);
                }

                while (dr.Read())
                {
                    csv = readSQLLine(dr, drlenght, csv);
                }

                if (readLineFromDB)
                {
                    saveQueryToCSV(csv, sqlFileName);
                }
                else
                {
                    MessageBox.Show("No entries found!");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           
        }

        private OdbcDataReader ConnectToSQLDatabase(string sqlFileName)
        {
            string path = @sqlfolder + "\\" + sqlFileName;

            string connectionString = "DSN=eNVenta SQL Server;Server=server-03;Database=LOE01;User Id=s.ewert;Password=loechel123;";
            string sql = File.ReadAllText(path);
            OdbcConnection conn = new OdbcConnection(connectionString);
            conn.Open();
            OdbcCommand comm = new OdbcCommand(sql, conn);
            comm.CommandTimeout = 300; //300 seconds timeout
            OdbcDataReader dr = comm.ExecuteReader();
            return dr;
        }

        private string readSQLLine(OdbcDataReader dr, int drlenght, string csv)
        {
            //Read sql lines from database
            for (int i = 0; i < drlenght; i++)
            {
                csv += dr[i].ToString() + seperator;
            }
            csv = csv.Remove(csv.Length - 1); //Cut last seperator
            csv += "\r\n"; //Add newline
            readLineFromDB = true;
            return csv;
        }

        private string readSQLHeadline(OdbcDataReader dr, int drlenght, string csv)
        {
            for (int i = 0; i < drlenght; i++)
            {
                csv += dr.GetName(i) + seperator;
            }
            csv = csv.Remove(csv.Length - 1); //Cut last seperator
            csv += "\r\n"; //Add newline
            return csv;
        }

        private static void saveQueryToCSV(string csv, string sqlFileName)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
            saveFileDialog1.FileName = DateTime.Now.ToString("ddMMyyyy-HHmm") + sqlFileName.Remove(sqlFileName.Length - 4);

            //Save csv file
            Stream savePathCheck;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((savePathCheck = saveFileDialog1.OpenFile()) != null)
                {
                    savePathCheck.Close();
                    //Write all text to selected file
                    String savePath = Path.GetFullPath(saveFileDialog1.FileName);
                    File.WriteAllText(savePath, csv);
                }
            }
        }

        private void checkBoxAddHeadline_CheckedChanged(object sender, EventArgs e)
        {
            addHeadline = checkBoxAddHeadline.Checked;
        }

        private void textBoxSeperator_TextChanged(object sender, EventArgs e)
        {
            seperator = textBoxSeperator.Text;
        }
    }
}
