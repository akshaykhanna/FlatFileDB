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
                    
                    //display heading according to type file to be uploaded
                    lbHeading.Text = "Upload or choose " + fileNamesList[count] + " File";
                }
            }
            catch (Exception er)
            {
               lbMsg.Text = er.Message;
            }

        }

        void GetFilesFromFolderInListBox()
        {
            try
            {
                //add all in files in particular type of folder in list box
                string[] fileEntries = Directory.GetFiles(pathSource+ fileNamesList[count]+@"\");
                ListBox1.Items.Clear();
                String temp;
                foreach (string fileName in fileEntries)
                {
                    temp= fileName.ToString().Substring(fileName.LastIndexOf("\\")+1);
                    ListBox1.Items.Add(temp);
                     
                }
                //to display files in destination folder
                //fileEntries = Directory.GetFiles(pathDestination);
                //lbFinalItems.Items.Clear();
                //foreach (string fileName in fileEntries)
                //{
                //    lbFinalItems.Items.Add(fileName.ToString());
                //}

                //add name of file moved in list box 2
                lbFinalItems.Items.Clear();
                foreach (string fileName in filesAdded)
                {
                    if(fileName!=null && fileName.Length>0)
                    {
                        temp = fileName.ToString().Substring(fileName.LastIndexOf("\\") + 1);
                        lbFinalItems.Items.Add(temp);
                    }
                   
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
                String path = pathSource + fileNamesList[count] + @"\";
                String outputFileName = path  + fileNamesList[count] + "_"+ DateTime.Now.ToString().Replace(":", "") + ".xml";
                
                String savePath = path+ postedFile.ToString();
                //FileUpload1.SaveAs(savePath);
                FileUpload1.SaveAs(outputFileName);
                //File.Delete(newFileName); // Delete the existing file if exists
                lbMsg.Text = savePath + " - " + outputFileName;
                ////File.Move(savePath,outputFileName);
                //File.Copy(savePath, outputFileName);
                //File.Delete(savePath);
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
                //get file selected in list box 1
                String fileToMoveWithpath="";
                for (int i = 0; i < ListBox1.Items.Count; i++)
                {
                    if (ListBox1.Items[i].Selected)
                    {
                        lbMsg.Text = "Copy & renaming file " + ListBox1.Items[i].Text.ToString();
                        fileToMoveWithpath = ListBox1.Items[i].Text.ToString();
                    }
                }
                fileToMoveWithpath = pathSource + fileNamesList[count] + @"\"+fileToMoveWithpath;
                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                System.IO.File.Copy(fileToMoveWithpath, pathDestination+ fileNamesList[count]+".xml", true);
                filesAdded[count] = fileToMoveWithpath.ToString();
                GetFilesFromFolderInListBox();
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
    }
}