using Xunit;
using FluentAssertions;
using GitModel;
using GitModel.Internal;

namespace GitModel.UnitTests.Internal
{
   public class RebaseActionParserTests
   {
      [Theory]
      [InlineData( "pick", RebaseAction.Pick )]
      [InlineData( "p", RebaseAction.Pick )]
      [InlineData( "reword", RebaseAction.Reword )]
      [InlineData( "r", RebaseAction.Reword )]
      [InlineData( "edit", RebaseAction.Edit )]
      [InlineData( "e", RebaseAction.Edit )]
      [InlineData( "squash", RebaseAction.Squash )]
      [InlineData( "s", RebaseAction.Squash )]
      [InlineData( "fixup", RebaseAction.Fixup )]
      [InlineData( "f", RebaseAction.Fixup )]
      [InlineData( "exec", RebaseAction.Exec )]
      [InlineData( "x", RebaseAction.Exec )]
      public void ToRebaseAction_ActionStringIsValid_ConvertsToRebaseAction( string actionString, RebaseAction expectedAction )
      {
         RebaseActionParser.ToRebaseAction( actionString ).Should().Be( expectedAction );
      }
   }
}
