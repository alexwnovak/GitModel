namespace GitModel
{
   internal interface IFileSystem
   {
      bool FileExists( string filePath );

      string[] ReadAllLines( string filePath );
   }
}
