namespace GitModel
{
   public interface ICommitFileReader
   {
      CommitDocument FromFile( string filePath );
   }
}
