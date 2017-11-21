using System;
using TechTalk.SpecFlow;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class RebaseSteps
   {
      private readonly RebaseDocument _rebaseDocument;

      public RebaseSteps( RebaseDocument rebaseDocument )
      {
         _rebaseDocument = rebaseDocument;
      }

      [Given( @"the rebase has the following:" )]
      public void GivenTheRebaseHasTheFollowingData( Table table )
      {
      }

      [Given( @"the rebase file exists" )]
      public void GivenTheRebaseFileExists()
      {
      }

      [When( @"I read the rebase file" )]
      public void WhenIReadTheRebaseFile()
      {
      }

      [Then( @"the rebase document should contain:" )]
      public void ThenTheRebaseDocumentShouldContain( Table table )
      {
      }
   }
}
