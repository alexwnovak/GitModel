using System;

namespace GitModel
{
   public class CommitFileReader
   {
      public void FromFile( string filePath )
      {
         if ( string.IsNullOrEmpty( filePath ) )
         {
            throw new ArgumentException( "File path must not be null or empty", nameof( filePath ) );
         }

         throw new NotImplementedException();
      }
   }
}
