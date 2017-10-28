namespace GitModel
{
   public interface IFileSystem
   {
      bool FileExists( string filePath );

      string[] ReadAllLines( string filePath );
   }
}
