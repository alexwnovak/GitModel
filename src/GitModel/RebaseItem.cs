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

      /// <summary>
      /// Returns a string that represents the current object properties.
      /// </summary>
      /// <returns>A string that contains the current property values.</returns>
      public override string ToString() => $"{Action.ToString().ToLower()} {CommitHash} {Subject}";
   }
}
