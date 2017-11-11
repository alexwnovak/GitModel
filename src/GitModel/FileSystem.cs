﻿using System.Collections.Generic;
using System.IO;

namespace GitModel
{
   internal class FileSystem : IFileSystem
   {
      public bool FileExists( string filePath ) => File.Exists( filePath );

      public string[] ReadAllLines( string filePath ) => File.ReadAllLines( filePath );

      public void WriteAllLines( string filePath, IEnumerable<string> contents ) =>
         File.WriteAllLines( filePath, contents );
   }
}
