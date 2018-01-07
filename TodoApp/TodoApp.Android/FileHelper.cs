using System;
using System.IO;
using TodoApp.Interface;

namespace TodoApp.Droid
{
    public sealed class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}