namespace GitModel
{
   public class CommitDocument
   {
      public string FilePath
      {
         get;
         set;
      }

      public string Subject
      {
         get;
         set;
      }

      public string[] Body
      {
         get;
         set;
      }
   }
}
