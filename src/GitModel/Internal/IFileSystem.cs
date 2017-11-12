using System.Collections.Generic;

namespace GitModel.Internal
{
   internal interface IFileSystem
   {
      bool FileExists( string filePath );

      string[] ReadAllLines( string filePath );

      void WriteAllLines( string filePath, IEnumerable<string> contents );
   }
}
