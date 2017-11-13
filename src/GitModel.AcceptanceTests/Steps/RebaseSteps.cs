using TechTalk.SpecFlow;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class RebaseSteps
   {
      private readonly ScenarioContext _scenarioContext;

      public RebaseSteps( ScenarioContext scenarioContext )
      {
         _scenarioContext = scenarioContext;
      }

      [Given( @"the rebase has the following:" )]
      public void GivenTheRebaseHasTheFollowingData( Table table )
      {
         _scenarioContext.Pending();
      }

      [Given( @"the rebase file exists" )]
      public void GivenTheRebaseFileExists()
      {
         _scenarioContext.Pending();
      }

      [When( @"I read the rebase file" )]
      public void WhenIReadTheRebaseFile()
      {
         _scenarioContext.Pending();
      }

      [Then( @"the rebase document should contain:" )]
      public void ThenTheRebaseDocumentShouldContain( Table table )
      {
         _scenarioContext.Pending();
      }
   }
}
