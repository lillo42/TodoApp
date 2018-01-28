using System.IO;
using TodoApp.Interface;
using Windows.Storage;

namespace TodoApp.UWP.Helper
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);
        }
    }
}
