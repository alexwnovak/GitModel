using System;

namespace GitModel.Internal
{
   internal static class RebaseActionParser
   {
      public static RebaseAction ToRebaseAction( string actionString )
      {
         actionString = actionString.ToLower();

         if ( actionString == "pick" || actionString == "p" )
         {
            return RebaseAction.Pick;
         }
         if ( actionString == "reword" || actionString == "r" )
         {
            return RebaseAction.Reword;
         }
         if ( actionString == "edit" || actionString == "e" )
         {
            return RebaseAction.Edit;
         }

         throw new NotImplementedException();
      }
   }
}
