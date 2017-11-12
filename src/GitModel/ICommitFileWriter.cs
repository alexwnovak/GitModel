namespace GitModel
{
   public interface ICommitFileWriter
   {
      void ToFile( string filePath, CommitDocument document );
   }
}
