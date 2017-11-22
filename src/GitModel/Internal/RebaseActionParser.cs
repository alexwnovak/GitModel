using System.Collections.Generic;

namespace GitModel.Internal
{
   internal static class RebaseActionParser
   {
      private static readonly Dictionary<string, RebaseAction> _rebaseActionDictionary = new Dictionary<string, RebaseAction>
      {
         ["pick"] = RebaseAction.Pick,
         ["p"] = RebaseAction.Pick,
         ["reword"] = RebaseAction.Reword,
         ["r"] = RebaseAction.Reword,
         ["edit"] = RebaseAction.Edit,
         ["e"] = RebaseAction.Edit,
         ["squash"] = RebaseAction.Squash,
         ["s"] = RebaseAction.Squash,
         ["fixup"] = RebaseAction.Fixup,
         ["f"] = RebaseAction.Fixup,
         ["exec"] = RebaseAction.Exec,
         ["x"] = RebaseAction.Exec
      };

      public static RebaseAction ToRebaseAction( string actionString ) =>
          _rebaseActionDictionary[actionString.ToLower()];
   }
}
