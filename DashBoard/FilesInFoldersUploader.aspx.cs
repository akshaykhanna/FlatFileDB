using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DashBoard
{
    public partial class FilesInFoldersUploader : System.Web.UI.Page
    {
        String pathSource = @"F:\PrevData\";
        String pathDestination = @"F:\CurrData\";
        string[] fileNamesList= new string[] { "checkstyle_report", "findbugs", "interpret", "JPetStore_CD_changelog", "PMD_Report" };
        static string[] filesAdded = new string[5];
        static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetFilesFromFolderInListBox();
                    //addNamesToFiles();
                    lbHeading.Text = "Upload or choose " + fileNamesList[count] + " File";
                }
            }
            catch (Exception er)
            {
               lbMsg.Text = er.Message;
            }

        }

        //private void addNamesToFiles()
        //{
        //    fileNamesList= 

        //}

        void GetFilesFromFolderInListBox()
        {
            try
            {
                string[] fileEntries = Directory.GetFiles(pathSource+ fileNamesList[count]+@"\");
                ListBox1.Items.Clear();
                foreach (string fileName in fileEntries)
                {
                    ListBox1.Items.Add(fileName.ToString());
                     
                }
                //to display files in destination folder
                //fileEntries = Directory.GetFiles(pathDestination);
                //lbFinalItems.Items.Clear();
                //foreach (string fileName in fileEntries)
                //{
                //    lbFinalItems.Items.Add(fileName.ToString());
                //}

                lbFinalItems.Items.Clear();
                foreach (string fileName in filesAdded)
                {
                    if(fileName!=null && fileName.Length>0)
                    lbFinalItems.Items.Add(fileName.ToString());
                }
            }
            catch (Exception er)
            {

                lbMsg.Text = er.Message;
            }
        }

        protected void btAddFileToFolder_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                // Call a helper method routine to save the file.
                SaveFile(FileUpload1.FileName);
                Response.Redirect(Request.RawUrl);
            }
            else
                // Notify the user that a file was not uploaded.
                lbMsg.Text = "You did not browse a file to upload.";

            
        }

        private void SaveFile(String postedFile)
        {
            try
            {
                String savePath = pathSource + postedFile.ToString();
                FileUpload1.SaveAs(savePath);
            }
            catch (Exception er)
            {
                lbMsg.Text = er.Message;
            }
        }

        protected void btMoveToRigt_Click(object sender, EventArgs e)
        {
            try
            {
                //var temp = ListBox1.SelectedItem;
                //lbMsg.Text = "Data "+ListBox1.se
                //lbMsg.Text = "Data " + ListBox1.Items[ListBox1.SelectedIndex];
                String fileToMoveWithpath="";
                for (int i = 0; i < ListBox1.Items.Count; i++)
                {
                    if (ListBox1.Items[i].Selected)
                    {
                        lbMsg.Text = "Copy & renaming file " + ListBox1.Items[i].Text.ToString();
                        fileToMoveWithpath = ListBox1.Items[i].Text.ToString();
                    }
                }
                
                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(fileToMoveWithpath, pathDestination+ fileNamesList[count]+".xml", true);
                filesAdded[count] = fileToMoveWithpath.ToString();
            }
            catch (Exception er)
            {
                lbMsg.Text = er.Message;
            }
        }

        protected void btnNextFile_Click(object sender, EventArgs e)
        {
            try
            {
                count++;
                if(count>=fileNamesList.Length)
                {
                    count = 0;
                }
                lbHeading.Text = "Upload or choose " + fileNamesList[count] + " File";
                GetFilesFromFolderInListBox();
            }
            catch (Exception er)
            {
                lbMsg.Text = er.Message;
            }
        }

        protected void btPrev_Click(object sender, EventArgs e)
        {
            try
            {
                count--;
                if (count <0)
                {
                    count = fileNamesList.Length-1;
                }
                lbHeading.Text = "Upload or choose " + fileNamesList[count] + " File";
                GetFilesFromFolderInListBox();
            }
            catch (Exception er)
            {
                lbMsg.Text = er.Message;
            }
        }


        //protected void ListBox1_SelectedIndexChanged1(object sender, EventArgs e)
        //{
        //    // Get the currently selected item in the ListBox.
        //    curItem = ListBox1.SelectedItem.ToString();
        //    lbMsg.Text = "papu " + curItem;
        //    // Find the string in ListBox2.
        //}
    }
}