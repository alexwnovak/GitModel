using System;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using GitModel.AcceptanceTests.ModelObjects;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class RebaseSteps
   {
      private readonly RebaseDocumentObject _rebaseDocument;

      public RebaseSteps( RebaseDocumentObject rebaseDocument )
      {
         _rebaseDocument = rebaseDocument;
      }

      [Given( @"the rebase has the following:" )]
      public void GivenTheRebaseHasTheFollowingData( Table table )
      {
         _rebaseDocument.Items = table.CreateSet<RebaseItem>().ToArray();
      }

      [Given( @"the rebase file exists" )]
      public void GivenTheRebaseFileExists()
      {
         _rebaseDocument.Save();
      }

      [When( @"I read the rebase file" )]
      public void WhenIReadTheRebaseFile()
      {
         _rebaseDocument.Load();
      }

      [Then( @"the rebase document should contain:" )]
      public void ThenTheRebaseDocumentShouldContain( Table table )
      {
         var expectedItems = table.CreateSet<RebaseItem>();

         _rebaseDocument.Items.Should().BeEquivalentTo( expectedItems );
      }
   }
}
