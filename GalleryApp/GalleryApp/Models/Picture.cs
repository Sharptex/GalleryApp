using System;
using System.IO;

namespace GalleryApp.Models
{
    public class Picture
    {
        public string FullPath { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public Picture(string fullPath)
        {
            FullPath = fullPath;
            Name = Path.GetFileName(fullPath);
            CreationDate = File.GetCreationTime(fullPath);
        }

    }
}
