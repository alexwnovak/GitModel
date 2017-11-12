using System.Collections.Generic;
using GitModel.Internal;

namespace GitModel
{
   public class CommitFileWriter : ICommitFileWriter
   {
      private readonly IFileSystem _fileSystem;

      public CommitFileWriter() : this( new FileSystem() )
      {
      }

      internal CommitFileWriter( IFileSystem fileSystem )
      {
         _fileSystem = fileSystem;
      }

      public void ToFile( string filePath, CommitDocument document )
      {
         var lines = new List<string>
         {
            document.Subject
         };

         if ( document.Body != null )
         {
            lines.Add( string.Empty );
            lines.AddRange( document.Body );
         }

         _fileSystem.WriteAllLines( filePath, lines );
      }
   }
}
