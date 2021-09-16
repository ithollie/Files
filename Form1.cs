using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Files
{
    public partial class Form1 : Form
    {
        private const char Separator = ' ';
        private const char Separator1 = ' ';
        private bool clear;

        private string[] newArray;
        private string[] upperCaseArray;
        private string[] text;

        private string longestWord;

        private int[]  intArray;


        private bool selectIsActive;
        private bool PerformedActions; 

        public int arrayLen;

        public Form1()
        {
            InitializeComponent();
            this.selectIsActive = false;
            this.PerformedActions = false;
            this.clear = false;

            this.arrayLen = 0;
            this.upperCaseArray = new string[arrayLen];

            this.longestWord = null;
       
        }

        public void  convertToUpperCase()
        {
            upperCaseArray = new String[newArray.Length];

            for (int i = 0; i < newArray.Length; i++)
            {
                
                if (newArray.Length > 0)
                {
                    string  word  =  newArray[i].ToUpper();

                    if(word  != null)
                    {
                        upperCaseArray[i] = word;
                    }
                }
            }
            insertItemsUpperCase(upperCaseArray);
        }

        public void DisplayArray()
        {
            if (arrayLen > 0)
            {
                for (int i = 0; i < newArray.Length; i++)
                {
                    Console.WriteLine(" index " + i + " = " + newArray[i]);
                }
            }
        }
        public string findFirstWord()
        {
            string word = "";

            for (int i = 0; i < newArray.Length; i++)

            {
                string current = newArray[i];

                for (int j = 0; j < current.Length; j++)
                {

                    if (current[j] == 'a')
                    {

                       word = newArray[i];
                          

                    }
                }
            }
            return word;
        }

        public string findLastWord()
        {
            string word = "";
        
            for(int i = 0; i < newArray.Length;  i++)
            {

                word = newArray[i];
                
            }
            return word; 
        }
        // function  that  perform action.
        public void PerformedAction() {

            if(PerformedActions == false)
            {
                PerformedActions = true;
            }

            try
            {
                string[] text = File.ReadAllText(openFileDialog1.FileName).Split(Separator);
             
                newArray = new string[text.Length];

                if (File.Exists(openFileDialog1.FileName) != true)
                {

                    MessageBox.Show("That file don't exist");
                }

                for (int i = 0; i < text.Length; i++)
                {
                    string loopWord = "";

                    string newWord = text[i]; 

                    for(int j  = 0;  j  < newWord.Length; j++)
                    {
                        if (newWord[j] != '.')
                        {
                            arrayLen++;
                            loopWord += newWord[j];
                        }   
                       
                    }
                    newArray[i] = loopWord;
                   
                }

                if(newArray.Length > 0)
                {
                    
                    insertItems();
                }
            }
            catch (Exception  e)
            {
                Console.WriteLine("-----> " + e);
            }
            
        
        }

        public void insertItems()
        {
            for(int i = 0;  i < newArray.Length; i++)
            {
                listBox1.Items.Add(newArray[i]);
            }
        }

        public void insertItemsUpperCase(string[] upperCaseArray)
        {
            for (int i = 0; i < upperCaseArray.Length; i++)
            {
                listBox3.Items.Add(upperCaseArray[i]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectIsActive == false)
            {
                selectIsActive = true;
                clear = false;
                label7.Text = "On";
                //openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.ShowDialog();
                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Title = "Browse Text Files";
                openFileDialog1.DefaultExt = "txt";
                PerformedAction();
            }

            if(selectIsActive == true)
            {
                label3.Text = "Please  click the clear  button to  input  a  new  file";
            }
            
        }
        public string findLongestWord()
        {
            string tempLong = "word";
            try
            {
                for (int i = 0; i < newArray.Length; i++)
                {
                    if (newArray[i].Length > tempLong.Length)
                    {
                        tempLong = newArray[i];
                    }
                }
            }catch(Exception e)
            {
                e.ToString();
            }
            return tempLong;
                
        }
        public string  mostVawels()
        {
            int num = 0;
            int index = 0;
            string mainWord = ""; 

            intArray = new int[newArray.Length];
            
            try
            {
                    char[] vawols = { 'a', 'e', 'i', 'o', 'u' };

                    for (int i = 0; i < newArray.Length; i++)
                    {
                        

                        string arrayWord = newArray[i];
                        int tempValue = 0;
                        int u = 0;

                      
                        for (int j = 0; j < arrayWord.Length; j++) {
                            
                                u++;

                                for (int k = 0; k < vawols.Length; k++)
                                {

                              
                                    if (arrayWord[j] == vawols[k])
                                    {

                                        tempValue++;
                                        //MessageBox.Show( arrayWord[j] + " " + " == Equals to " + vawols[k]);

                                    }
                                    else
                                    {
                                         //MessageBox.Show(arrayWord[j] + "!=" + vawols[k] );
                                    }
                                }

                        }

                        if (arrayWord.Length == u)
                        {
                         

                            if(tempValue > index)
                            {
                                index = tempValue;
                                mainWord = newArray[i];
                                
                            }
                            //MessageBox.Show("Temp  value is " + tempValue);
                        }
                    }
                
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return mainWord;
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String label = "Longest Word";

            if(selectIsActive == true){
                label4.Text = label;
                label5.Text = findLongestWord();
            }

            if (selectIsActive == false)
            {
                MessageBox.Show("Selection  is not active please  select a file ");
            }
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectIsActive  !=  false)
            {
                label7.Text = "On";
                convertToUpperCase();
            }

            if (selectIsActive == false)
            {
                label3.Text = "Selection  is not active please  select a file ";

            }


        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (selectIsActive == true)
            {
                
                selectIsActive = false;
                clear = false;

                label7.Text = "Off";
                label5.Text = "";
                label3.Text = "";
                listBox1.Items.Clear();
                listBox3.Items.Clear();
                newArray = null;
                  
            }
            else
            {
                    if(clear == false)
                    {
                        label3.Text = "clear is off";
                    }
                     else
                     {
                         label3.Text = "Please press clear in order to select a new file";
                     }
             }

            
                    

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String label = " The word with the  most vawols  is ";

            if (selectIsActive == true)
            {
                label4.Text = label;
                label5.Text = mostVawels();

                //MessageBox.Show("The word with the  most vawols  is " + mostVawels());
          
            }
            
            if(selectIsActive == false)
            {
                MessageBox.Show("Please input a text  file to continue");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (selectIsActive == true)
            {
                
                MessageBox.Show("The last  word is  " + findLastWord());
            }

            if (selectIsActive != true)
            {
                MessageBox.Show("Button  is not active");
                
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (selectIsActive == true)
            {

                MessageBox.Show("The first   word alphabetically  is  " + findFirstWord());
            }

            if (selectIsActive != true)
            {
                MessageBox.Show("Button  is not active");

            }
        }
    }
}
