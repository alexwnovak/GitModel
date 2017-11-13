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
      public void ToRebaseAction_ActionStringIsValid_ConvertsToRebaseAction( string actionString, RebaseAction expectedAction )
      {
         RebaseActionParser.ToRebaseAction( actionString ).Should().Be( expectedAction );
      }
   }
}
