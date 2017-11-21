namespace GitModel
{
   /// <summary>
   /// 
   /// </summary>
   public class RebaseItem
   {
      /// <summary>
      /// 
      /// </summary>
      public RebaseAction Action
      {
         get;
         set;
      }

      /// <summary>
      /// 
      /// </summary>
      public string CommitHash
      {
         get;
         set;
      }

      /// <summary>
      /// 
      /// </summary>
      public string Subject
      {
         get;
         set;
      }

      public override string ToString() => $"{Action.ToString().ToLower()} {CommitHash} {Subject}";
   }
}
