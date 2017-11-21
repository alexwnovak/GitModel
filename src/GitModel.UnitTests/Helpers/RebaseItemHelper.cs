namespace GitModel.UnitTests.Helpers
{
   internal static class RebaseItemHelper
   {
      public static string Create( RebaseAction action, string commitHash, string subject )
      {
         var rebaseItem = new RebaseItem
         {
            Action = action,
            CommitHash = commitHash,
            Subject = subject
         };

         return rebaseItem.ToString();
      }
   }
}
