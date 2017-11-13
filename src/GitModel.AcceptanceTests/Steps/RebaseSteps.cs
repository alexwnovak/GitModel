using TechTalk.SpecFlow;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class RebaseSteps
   {
      [Given( @"the rebase has the following:" )]
      public void GivenTheRebaseHasTheFollowingData( Table table )
      {
         ScenarioContext.Current.Pending();
      }

      [Given( @"the rebase file exists" )]
      public void GivenTheRebaseFileExists()
      {
         ScenarioContext.Current.Pending();
      }

      [When( @"I read the rebase file" )]
      public void WhenIReadTheRebaseFile()
      {
         ScenarioContext.Current.Pending();
      }

      [Then( @"the rebase document should contain:" )]
      public void ThenTheRebaseDocumentShouldContain( Table table )
      {
         ScenarioContext.Current.Pending();
      }
   }
}
