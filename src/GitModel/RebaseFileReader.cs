using System;
using System.Collections.Generic;
using GitModel.Internal;

namespace GitModel
{
   /// <summary>
   /// 
   /// </summary>
   public class RebaseFileReader : IRebaseFileReader
   {
      private readonly IFileSystem _fileSystem;

      /// <summary>
      /// 
      /// </summary>
      public RebaseFileReader() : this( new FileSystem() )
      {
      }

      internal RebaseFileReader( IFileSystem fileSystem )
      {
         _fileSystem = fileSystem;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="filePath"></param>
      /// <returns></returns>
      public RebaseDocument FromFile( string filePath )
      {
         if ( string.IsNullOrEmpty( filePath ) )
         {
            throw new ArgumentException( "File path must not be null or empty", nameof( filePath ) );
         }

         var allLines = _fileSystem.ReadAllLines( filePath );
         var rebaseItems = new List<RebaseItem>();

         foreach ( string line in allLines )
         {
            int firstSpace = line.IndexOf( ' ' );
            int secondSpace = line.IndexOf( ' ', firstSpace + 1 );

            string firstToken = line.Substring( 0, firstSpace );
            string secondToken = line.Substring( firstSpace + 1, secondSpace - firstSpace - 1 );
            string thirdToken = line.Substring( secondSpace + 1 );

            var rebaseItem = new RebaseItem
            {
               Action = RebaseActionParser.ToRebaseAction( firstToken ),
               CommitHash = secondToken,
               Subject = thirdToken
            };

            rebaseItems.Add( rebaseItem );
         }

         return new RebaseDocument
         {
            Items = rebaseItems.ToArray()
         };
      }
   }
}
