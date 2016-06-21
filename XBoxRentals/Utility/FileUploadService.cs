using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using XBoxRentals.Models;
using File = XBoxRentals.Models.File;

namespace XBoxRentals.Utility
{
    public class FileUploadService
    {
        private ApplicationDbContext _context;

        public FileUploadService(ApplicationDbContext context)
        {
            _context = context;
        }

        public File ConvertHttpPostedFileBaseToFile(HttpPostedFileBase file)
        {
            if (file == null)
                return null;

            var newFile = new File
            {
                ContentType = file.ContentType,
                Bytes = ConvertToBytes(file)
            };

            return newFile;
        }

        private static byte[] ConvertToBytes(HttpPostedFileBase file)
        {

            var reader = new BinaryReader(file.InputStream);
            var bytes = reader.ReadBytes(file.ContentLength);
            return bytes;
        }
    }
}