using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankersAlgorithm
{
    public partial class Form2 : Form
    {
       
        private DataTable resultTable;
        private DataTable alloctable;
        private DataTable maximum;
        int numCols;
        int numRows;
        int[] available = new int[100];
        int[] requestresource = new int[100];
        int[] requestprocess = new int[100];


        public Form2(DataTable resultTable, int numCols, int numRows, DataTable alloctable, DataTable maximum)
        {
            InitializeComponent();
            this.resultTable = resultTable;
            this.numCols = numCols;
            this.numRows = numRows;
            this.alloctable = alloctable;
            this.maximum = maximum;
            // Set the resultTable as the DataSource of the DataGridView
            dataGridViewR.DataSource = resultTable;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public static int[,] DataTableToArray(DataTable dataTable)
        {
            int rows = dataTable.Rows.Count;
            int cols = dataTable.Columns.Count;
            int[,] array = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = Convert.ToInt32(dataTable.Rows[i][j]);
                }
            }

            return array;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // int count=0;
            //for(int i=0;count-1<= numRows;i++)
            if (textBox1.Text != "")
            {
                string avalibleText = textBox1.Text;
                string[] substrings = avalibleText.Split(',');
                for (int i = 0; i < substrings.Length; i++)
                {
                    available[i] = int.Parse(substrings[i].Trim());

                }
                string message = "Values Entered";
                string title = "Information";
                MessageBox.Show(message, title);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[,] allocation = DataTableToArray(alloctable);
            // Get the number of rows and columns in the DataGridView
            int rowCount = dataGridViewR.Rows.Count;
            int colCount = dataGridViewR.Columns.Count;

            // Create a 2D array to store the data
            int[,] needarr = new int[rowCount, colCount];

            // Iterate over the rows and columns of the DataGridView
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    // Get the value of the cell at this row and column and parse it to an integer
                    DataGridViewCell cell = dataGridViewR.Rows[i].Cells[j];
                    int value;
                    if (int.TryParse(cell.Value.ToString(), out value))
                    {
                        needarr[i, j] = value;
                    }
                    else
                    {
                        // Handle the case where the value is not an integer
                        // You can either skip this cell or add a default value instead
                        needarr[i, j] = 0;
                    }
                }
            }
            int[] work = new int[numCols];
            Array.Copy(available, work, numCols);

            bool[] finish = new bool[numRows];
            for (int i = 0; i < numRows; i++)
            {
                finish[i] = false;
            }

            int count = 0;
            int[] safeSequence = new int[numRows];

            while (count < numRows)
            {
                bool found = false;
                for (int i = 0; i < numRows; i++)
                {
                    if (!finish[i])
                    {
                        bool canExecute = true;
                        for (int j = 0; j < numCols; j++)
                        {
                            if (needarr[i, j] > work[j])
                            {
                                canExecute = false;
                                break;
                            }
                        }

                        if (canExecute)
                        {
                            for (int j = 0; j < numCols; j++)
                            {
                                work[j] += allocation[i, j];
                            }

                            finish[i] = true;
                            safeSequence[count] = i;

                            found = true;
                        }
                        count++;
                    }
                }

                if (!found)
                {
                    // We were unable to find a safe sequence
                    string myString = "  We were unable to find a safe sequence";
                    label3.Text = myString;

                }
            }

            // If we made it here, we found a safe sequence
            string myString1 = "If we made it here, we found a safe sequence";
            label3.Text = myString1;
        }


        private void button2_Click_1(object sender, EventArgs e)
        {

            string avalibleText = textBox1.Text;
            string requestresourcet = textBox2.Text;
            string requestprocesst = textBox3.Text;
            int[,] need = DataTableToArray(resultTable);
            int[,] allocation = DataTableToArray(alloctable);
            int[,] max = DataTableToArray(maximum);
            int numRows = dataGridViewR.Rows.Count ;
            int numCols = dataGridViewR.Columns.Count ;
    


            this.Hide();
            Form3 f3 = new Form3(need, avalibleText, requestresourcet, requestprocesst,allocation, max, numRows, numCols);
            f3.Show();
            Visible = false;
        }
    }
}
    
    

