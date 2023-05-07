using System.Data;

namespace BankersAlgorithm
{
    public partial class Form1 : Form
    {

        int numRows;
        int numCols;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {


                int numRows = int.Parse(textBox1.Text);
                int numCols = int.Parse(textBox2.Text);

                DataTable dataTable = new DataTable();

                // Add columns to the DataTable
                for (int i = 0; i < numCols; i++)
                {

                    string columnName = ((char)('A' + i)).ToString(); // Convert index to alphabet
                    dataTable.Columns.Add(columnName, typeof(string));
                }

                // Add rows to the DataTable based on user input
                for (int i = 0; i < numRows; i++)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int j = 0; j < numCols; j++)
                    {

                        string cellValue = Microsoft.VisualBasic.Interaction.InputBox($"Enter value for row {i + 1}, column {j + 1}", "Enter Cell Value", "");

                        if (cellValue == "")
                        {
                            while (cellValue == "")
                            {
                                string message = "MISSING TABLE INFO";
                                string title = "WARNING";
                                MessageBox.Show(message, title);
                                cellValue = Microsoft.VisualBasic.Interaction.InputBox($"Enter value for row {i + 1}, column {j + 1}", "Enter Cell Value", "");
                            }
                        }
                        dataRow[j] = cellValue;
                    }
                    dataTable.Rows.Add(dataRow);
                }

                // Set the DataTable as the DataGridView's DataSource
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                string message = "MISSING INFO";
                string title = "WARNING";
                MessageBox.Show(message, title);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {


                int numRows = int.Parse(textBox1.Text);
                int numCols = int.Parse(textBox2.Text);

                DataTable dataTable = new DataTable();

                // Add columns to the DataTable
                for (int i = 0; i < numCols; i++)
                {

                    string columnName = ((char)('A' + i)).ToString(); // Convert index to alphabet
                    dataTable.Columns.Add(columnName, typeof(string));
                }

   
                for (int i = 0; i < numRows; i++)
                {
                    
                    DataRow dataRow = dataTable.NewRow();

                    for (int j = 0; j < numCols; j++)
                    {

                        string cellValue = Microsoft.VisualBasic.Interaction.InputBox($"Enter value for row {i +1}, column {j + 1}", "Enter Cell Value", "");

                        if (cellValue == "")
                        {
                            while (cellValue == "")
                            {
                                string message = "MISSING TABLE INFO";
                                string title = "WARNING";
                                MessageBox.Show(message, title);
                                cellValue = Microsoft.VisualBasic.Interaction.InputBox($"Enter value for row {i + 1}, column {j + 1}", "Enter Cell Value", "");
                            }
                        }
                       dataRow[j] = cellValue;
                       
                    }
                   dataTable.Rows.Add(dataRow);
                    
                }

                // Set the DataTable as the DataGridView's DataSource
                dataGridView2.DataSource = dataTable;
            }
            else
            {
                string message = "MISSING INFO";
                string title = "WARNING";
                MessageBox.Show(message, title);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0 && dataGridView2.Rows.Count != 0)
            {
                // Subtract the values of dataGridView2 from dataGridView1
                DataTable resultTable = SubtractDataTables(dataGridView1.DataSource as DataTable, dataGridView2.DataSource as DataTable);
                DataTable alloctable =  dataGridView2.DataSource as DataTable;
                DataTable maximum = dataGridView1.DataSource as DataTable;
                int numCols = int.Parse(textBox2.Text);
                int numRow= int.Parse(textBox1.Text);
                // Show Form2 and pass the subtracted DataTable as a parameter
                this.Hide();
                Form2 f2 = new Form2(resultTable,numCols, numRow, alloctable, maximum);
                f2.Show();
                Visible = false;
            }
            else
            {
                string message = "MISSING INFO IN TABLES";
                string title = "WARNING";
                MessageBox.Show(message, title);
            }
        }

        private DataTable SubtractDataTables(DataTable dt1, DataTable dt2)
        {
            DataTable resultTable = new DataTable();

            // Create columns for resultTable with alphabetical column names
            for (int i = 0; i < dt1.Columns.Count; i++)
            {
                string columnName = ((char)('A' + i)).ToString(); // Convert index to alphabet
                resultTable.Columns.Add(columnName, typeof(string));
            }


            // Subtract the values of dt2 from dt1 and add the result to resultTable
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow newRow = resultTable.NewRow();

                for (int j = 0; j < dt1.Columns.Count; j++)
                {

                        newRow[j] = (int.Parse(dt1.Rows[i][j].ToString()) - int.Parse(dt2.Rows[i][j].ToString())).ToString();
                   
                }

                resultTable.Rows.Add(newRow);
            }


            return resultTable;
        }

    }
    
}