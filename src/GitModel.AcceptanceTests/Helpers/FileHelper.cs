using System.IO;

namespace GitModel.AcceptanceTests.Helpers
{
   internal static class FileHelper
   {
      public static void DeleteFile( string path )
      {
         if ( File.Exists( path ) )
         {
            File.Delete( path );
         }
      }

      public static string WriteTempFile( params string[] contents )
      {
         string tempFileName = Path.GetTempFileName();

         File.WriteAllLines( tempFileName, contents );

         return tempFileName;
      }
   }
}
