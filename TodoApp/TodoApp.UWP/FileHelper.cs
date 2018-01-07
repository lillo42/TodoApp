using System.IO;
using TodoApp.Interface;
using Windows.Storage;

namespace TodoApp.UWP
{
    public sealed class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
