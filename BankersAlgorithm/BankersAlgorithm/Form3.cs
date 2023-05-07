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
    public partial class Form3 : Form
    {
        int[,] need;
        string avalibleText;
        string requestresourcet ;
        string requestprocesst ;
        //private DataTable resultTable;
        int[] available= new int[100];
        int[] request =new int[100];
        int requestingProcess;
        int[,] allocation;
        int[,] max;
        int n;//number of processes
        int m;//number of columns
        int[] work;

        public Form3(int[,] need , string avalibleText, string requestresourcet, string requestprocesst,
            int[,] allocation, int[,] max, int numRows, int numCols)
        {
            InitializeComponent();
            this.need = need;
            this.avalibleText = avalibleText;
            this.max = max;
            this.requestresourcet = requestresourcet;
            this.requestprocesst = requestprocesst;
            this.allocation = allocation;
            n = numRows;
            m = numCols;
         



            if (avalibleText != "")
            {
                string[] substrings = this.avalibleText.Split(',');
                for (int i = 0; i < substrings.Length; i++)
                {
                    available[i] = int.Parse(substrings[i].Trim());

                }

            }

            this.work = (int[])available.Clone();

            if (requestresourcet != "")
            {
                string[] substrings = this.requestresourcet.Split(',');
                for (int i = 0; i < substrings.Length; i++)
                {
                    request[i] = int.Parse(substrings[i].Trim());

                }

            }
            requestingProcess = int.Parse(this.requestprocesst);
            
        }


        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            // Check if the request can be granted
            if (!CanGrantRequest(request, available, need,m))
            {
                label3.Text = "The request cannot be granted. The process must wait.";
                return;
            }

            // Simulate the allocation of resources
            int[,] newAllocation = AddArrays(allocation, request, requestingProcess);
            int[] newAvailable = SubtractArrays(available, request);
            int[,] newNeed = SubtractArrays(max, newAllocation);
            work = (int[])newAvailable.Clone();
            // Check if the system is in a safe state
            if (IsSafeState(newAllocation, newNeed, newAvailable,m,work,n))
            {
                allocation = newAllocation;
                available = newAvailable;
                max = newNeed;
                label3.Text = "The request has been granted. The new state of the system is safe.";
                DisplaySystemState();
            }
            else
            {
                allocation = newAllocation;
                available = newAvailable;
                max = newNeed;
                label3.Text = "The request cannot be granted. The process must wait.";
                DisplaySystemState();
            }
           
    
        }



        // Check if the current state of the system is safe
        static bool IsSafeState(int[,] allocation, int[,] need, int[] available, int m, int[] work ,int n)
        {

            // Initialize the finish array
            bool[] finish = new bool[n];
            for (int i = 0; i < n; i++)
            {
                finish[i] = false;
            }

            // Initialize the safe sequence
            int[] safeSequence = new int[n];
            int safeSequenceIndex = 0;

            // Loop until all processes are finished
            while (safeSequenceIndex < n)
            {
                // Find an unfinished process whose needs can be satisfied
                int i;
                for (i = 0; i < n; i++)
                {
                    if (!finish[i] && CanBeSatisfied(need, work, i, m))
                    {
                        break;
                    }
                }

                // If no such process is found, the system is in an unsafe state
                if (i == n)
                {
                    return false;
                }

                // Add the process to the safe sequence and update the work array
                safeSequence[safeSequenceIndex] = i;
                //-----------------------------------------
                int[] row = new int[allocation.GetLength(1)];
                for (int j = 0; j < allocation.GetLength(1); j++)
                {
                    row[j] = allocation[i, j];
                }
                //------------------------------------------
                work = AddArrays(work, row);
                safeSequenceIndex++;
                finish[i] = true;
            }
            return true;
        }


        static bool CanGrantRequest(int[] request, int[] available, int[,] need, int m)
        {
            for (int i = 0; i < m ; i++)
            {
                if (request[i] > available[i] || request[i] > need[0, i])
                {
                    return false;
                }
            }
            return true;
        }

        // Add two arrays element-wise
        static int[] AddArrays(int[] a, int[] b)
        {
            int n = a.Length;
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = a[i] + b[i];
            }
            return result;
        }

        // Add an array to a row of a matrix element-wise
        static int[,] AddArrays(int[,] matrix, int[] array, int rowIndex)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] result = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == rowIndex)
                    {
                        result[i, j] = matrix[i, j] + array[j];
                    }
                    else
                    {
                        result[i, j] = matrix[i, j];
                    }
                }
            }
            return result;
        }


        // Subtract two arrays element-wise
        static int[] SubtractArrays(int[] a, int[] b)
        {
            int n = a.Length;
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = a[i] - b[i];
            }
            return result;
        }

        static int[,] SubtractArrays(int[,] array1, int[,] array2)
        {
            int n = array1.GetLength(0); // number of rows
            int m = array1.GetLength(1); // number of columns
            int[,] result = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = array1[i, j] - array2[i, j];
                }
            }

            return result;
        }




        // Subtract a row of a matrix from another row element-wise
        static int[,] SubtractArrays(int[,] matrix, int[,] array, int rowIndex)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(0);
            int[,] result = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                if (i == rowIndex)
                {
                    for (int j = 0; j < m; j++)
                    {
                        result[i, j] = array[0, j];
                    }
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        result[i, j] = matrix[i, j] - array[0, j];
                    }
                }
            }
            return result;
        }


        public static int[,] SubtractArrays(int[,] matrix, int[] array, int rowIndex)
        {
            int numRows = matrix.GetLength(0); // Get number of rows in matrix
            int numCols = matrix.GetLength(1); // Get number of columns in matrix
            int[,] result = new int[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (i == rowIndex)
                    {
                        result[i, j] = matrix[i, j] - array[j];
                    }
                    else
                    {
                        result[i, j] = matrix[i, j];
                    }
                }
            }

            return result;
        }



        // Check if a process's needs can be satisfied
        static bool CanBeSatisfied(int[,] need, int[] work, int processIndex, int m)
        { 

            for (int i = 0; i < m; i++)
            {
                if (need[processIndex, i] > work[i])
                {
                    return false;
                }
            }
            return true;
        }


        // Display the current state of the system
        private void DisplaySystemState()
        {
            string output = "Current state of the system:\n\nAllocation:\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    output += allocation[i, j] + " ";
                }
                output += "\n";
            }
            output += "\nMax:\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    output += max[i, j] + " ";
                }
                output += "\n";
            }
            output += "\nNeed:\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    output += need[i, j] + " ";
                }
                output += "\n";
            }
            output += "\nAvailable:\n";
            for (int i = 0; i < m; i++)
            {
                output += work[i] + " ";
            }
            output += "\n";
            label2.Text = output; // Update the label with the output
        }


        // Check if the system is in a safe state


        private void CheckSafeStateButton_Click_Click(object sender, EventArgs e)
        {// Initialize the work array
            work = new int[m];
            for (int i = 0; i < m; i++)
            {
                work[i] = available[i];
            }

            // Initialize the finish array
            bool[] finish = new bool[n];
            for (int i = 0; i < n; i++)
            {
                finish[i] = false;
            }

            // Initialize the safe sequence
            int[] safeSequence = new int[n];
            int safeSequenceIndex = 0;

            // Loop until all processes are finished
            while (safeSequenceIndex < n)
            {
                // Find an unfinished process whose needs can be satisfied
                int i;
                for (i = 0; i < n; i++)
                {
                    if (!finish[i] && CanBeSatisfied(need, work, i, m))
                    {
                        break;
                    }
                }

                // If no such process is found, the system is in an unsafe state
                if (i == n)
                {
                    label3.Text = "The request cannot be granted. The process must wait.";
                    DisplaySystemState();
                    MessageBox.Show("The system is in an unsafe state.", "Unsafe state");
                    return;
                }

                // Add the process to the safe sequence and update the work array
                safeSequence[safeSequenceIndex] = i;
                //-----------------------------------------
                int[] row = new int[allocation.GetLength(1)];
                for (int j = 0; j < allocation.GetLength(1); j++)
                {
                    row[j] = allocation[i, j];
                }
                //------------------------------------------
                work = AddArrays(work, row);
                safeSequenceIndex++;
                finish[i] = true;
            }

            // If all processes are finished, the system is in a safe state
            int[,] newAllocation = AddArrays(allocation, request, requestingProcess);
            allocation = newAllocation;
            label3.Text = "The request has been granted. The new state of the system is safe.";
            DisplaySystemState();
            string output = "The system is in a safe state.\nSafe sequence: ";
            for (int i = 0; i < n; i++)
            {
                output += "P" + safeSequence[i];
                if (i < n - 1)
                {
                    output += " -> ";
                }
            }
            MessageBox.Show(output, "Safe state");

        }

        private void RequestResourcesButton_Click_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < m; i++)
            {
                if (request[i] > need[requestingProcess, i])
                {
                    MessageBox.Show("The request exceeds the maximum need for this process.", "Invalid request");
                    return;
                }
                if (request[i] > available[i])
                {
                    MessageBox.Show("The request exceeds the available resources.", "Invalid request");
                    return;
                }
            }

            // Try to allocate the request
            int[,] newAllocation = AddArrays(allocation, request, requestingProcess);
            int[,] newNeed = SubtractArrays(need, request, requestingProcess);
            int[] newAvailable = SubtractArrays(available, request);

            // Check if the new state is safe
            bool[] finish = new bool[n];
            for (int i = 0; i < n; i++)
            {
                finish[i] = false;
            }
            int[] work = new int[m];
            for (int i = 0; i < m; i++)
            {
                work[i] = newAvailable[i];
            }
            while (true)
            {
                bool foundProcess = false;
                for (int i = 0; i < n; i++)
                {
                    if (!finish[i] && CanBeSatisfied(newNeed, work, i ,m))
                    {
                        foundProcess = true;
                        //-----------------------------------------
                        int[] row = new int[allocation.GetLength(1)];
                        for (int j = 0; j < allocation.GetLength(1); j++)
                        {
                            row[j] = newAllocation[i, j];
                        }
                        //------------------------------------------
                        work = AddArrays(work, row);
                        finish[i] = true;
                        break;
                    }
                }
                if (!foundProcess)
                {
                    break;
                }
            }
            bool isSafe = true;
            for (int i = 0; i < n; i++)
            {
                if (!finish[i])
                {
                    isSafe = false;
                    break;
                }
            }

            // Update the state if it is safe
            if (isSafe)
            {
                allocation = newAllocation;
                need = newNeed;
                available = newAvailable;
                //UpdateDataGridViews();
                MessageBox.Show("The request has been granted.", "Request granted");
            }
            else
            {
                MessageBox.Show("The request cannot be granted without causing an unsafe state.", "Request denied");
            }
        }



       



      
        private void button2_Click(object sender, EventArgs e)
        {
            // Display the steps happening in the banker's algorithm
            bool[] finished = new bool[n];
            int[] work1 = new int[m];
            List<string> steps = new List<string>();
            for (int i = 0; i < m; i++)
            {
                work1[i] = available[i];
            }

            int count = 0;
            while (count < n)
            {
                bool found = false;
                for (int i = 0; i < n; i++)
                {
                    if (!finished[i])
                    {
                        int j;
                        for (j = 0; j < m; j++)
                        {
                            if (need[i, j] > work1[j])
                            {
                                break;
                            }
                        }

                        if (j == m)
                        {
                            for (int k = 0; k < m; k++)
                            {
                                work1[k] += allocation[i, k];
                            }

                            finished[i] = true;
                            found = true;
                            count++;

                            string step = "Process P" + i + " executed";
                            for (int k = 0; k < m; k++)
                            {
                                step += " R" + k + "=" + work1[k];
                            }
                            steps.Add(step);

                            break;
                        }
                    }
                }

                if (!found)
                {
                    steps.Add("System is not in safe state");
                    break;
                }
            }

            // Display the steps happening in the banker's algorithm to the user
            string stepsText = "";
            foreach (string step in steps)
            {
                stepsText += step + Environment.NewLine;
            }
            MessageBox.Show(stepsText.Trim());
        }
    }    
}


