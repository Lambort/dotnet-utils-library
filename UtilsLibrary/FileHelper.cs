using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using ExcelDataReader;

namespace UtilsLibrary
{
    public static class FileHelper
    {
        static FileHelper() { }

        /// <summary>
        /// read simple text CSV file, ignore blank space and split with ','
        /// </summary>
        /// <param name="path"></param>
        /// <returns>List with String Array</returns>
        public static List<string[]> ReadCSV(string path)
        {
            try
            {
                if (!File.Exists(path)) { throw new Exception("No File Found"); }

                List<string[]> targetLines = File.ReadAllLines(path)
                    .Where(line => (!string.IsNullOrEmpty(line)) && line.Contains(","))
                    .Select(line => line.Split(','))
                    .ToList();

                return targetLines;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
                throw;
            }
        }


        /// <summary>
        /// read ms-office excel file and return dataset for all sheets
        /// </summary>
        /// <param name="path"></param>
        /// <returns>DataSet</returns>
        public static DataSet ReadExcel(string path)
        {
            try
            {
                if (!File.Exists(path)) { throw new Exception("No File Found"); }

                FileStream excelStream = File.Open(path, FileMode.Open, FileAccess.Read);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(excelStream);

                DataSet reaultData = excelReader.AsDataSet();

                excelReader.Dispose();
                excelStream.Dispose();

                return reaultData;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.StackTrace);
                throw;
            }
        }


        /// <summary>
        /// copy single file to target file folder
        /// </summary>
        /// <param name="fromPath"></param>
        /// <param name="destinFolder"></param>
        /// <returns>Boolean to show if success</returns>
        public static bool FileCopy(string fromPath, string destinFolder)
        {
            try
            {
                if (!File.Exists(fromPath)) { throw new Exception("no such file found!"); }

                if (new DirectoryInfo(destinFolder) == null) { throw new Exception("destinaton folder access failed!"); }

                FileInfo fileSource = new FileInfo(fromPath);

                fileSource.CopyTo(Path.Combine(destinFolder, fromPath.Split('\\').ToList().Last()), false);

                return true;
            }
            catch (Exception) { return false; }
        }


        /// <summary>
        /// copy single file to target folder, move file is supported
        /// </summary>
        /// <param name="fromPath"></param>
        /// <param name="destinFolder"></param>
        /// <param name="isMove"></param>
        /// <returns>Boolean to show if success</returns>
        public static bool FileCopy(string fromPath, string destinFolder, bool isMove)
        {
            try
            {
                if (!File.Exists(fromPath)) { throw new Exception("no such file found!"); }

                if (new DirectoryInfo(destinFolder) == null) { throw new Exception("destinaton folder access failed!"); }

                FileInfo fileSource = new FileInfo(fromPath);

                if (!isMove)
                {
                    fileSource.CopyTo(Path.Combine(destinFolder, fromPath.Split('\\').ToList().Last()), false);
                }
                else
                {
                    fileSource.MoveTo(Path.Combine(destinFolder, fromPath.Split('\\').ToList().Last()));
                }

                return true;
            }
            catch (Exception) { return false; }
        }


        /// <summary>
        /// copy all file in given folder to target folder
        /// </summary>
        /// <param name="fromFolder"></param>
        /// <param name="destinFolder"></param>
        /// <returns>Boolean to show if success</returns>
        public static bool FolderCopy(string fromFolder, string destinFolder)
        {
            try
            {
                if (new DirectoryInfo(fromFolder) == null || new DirectoryInfo(destinFolder) == null)
                {
                    throw new Exception("form or destinaton folder access failed!");
                }

                FileInfo[] sourceFileList = new DirectoryInfo(fromFolder).GetFiles();

                foreach (FileInfo sourceFile in sourceFileList)
                {
                    sourceFile.CopyTo(Path.Combine(destinFolder, sourceFile.Name), false);
                }
                return true;
            }
            catch (Exception) { return false; }
        }


        /// <summary>
        /// copy file filtered by extension to target folder
        /// </summary>
        /// <param name="fromFolder"></param>
        /// <param name="destinFolder"></param>
        /// <param name="extension"></param>
        /// <returns>Boolean to show if success</returns>
        public static bool FolderCopy(string fromFolder, string destinFolder, string extension)
        {
            try
            {
                if (new DirectoryInfo(fromFolder) == null || new DirectoryInfo(destinFolder) == null)
                {
                    throw new Exception("form or destinaton folder access failed!");
                }

                FileInfo[] sourceFileList = new DirectoryInfo(fromFolder).GetFiles();

                foreach (FileInfo sourceFile in sourceFileList)
                {
                    if (sourceFile.Extension == extension)
                    {
                        sourceFile.CopyTo(Path.Combine(destinFolder, sourceFile.Name), false);
                    }
                }
                return true;
            }
            catch (Exception) { return false; }
        }


        /// <summary>
        /// copy file filtered by extension to target folder, move these file is supported
        /// </summary>
        /// <param name="fromFolder"></param>
        /// <param name="destinFolder"></param>
        /// <param name="extension"></param>
        /// <param name="isMove"></param>
        /// <returns>Boolean to show if success</returns>
        public static bool FolderCopy(string fromFolder, string destinFolder, string extension, bool isMove)
        {
            try
            {
                if (new DirectoryInfo(fromFolder) == null || new DirectoryInfo(destinFolder) == null)
                {
                    throw new Exception("form or destinaton folder access failed!");
                }

                FileInfo[] sourceFileList = new DirectoryInfo(fromFolder).GetFiles();

                foreach (FileInfo sourceFile in sourceFileList)
                {
                    if (sourceFile.Extension == extension)
                    {
                        if (!isMove) { sourceFile.CopyTo(Path.Combine(destinFolder, sourceFile.Name), false); }
                        else { sourceFile.MoveTo(Path.Combine(destinFolder, sourceFile.Name)); }
                    }
                }
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
