using TechTalk.SpecFlow;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class CommitFileReaderSteps
   {
      [Given( @"the commit file has subject ""(.*)""" )]
      public void GivenTheCommitFileHasSubject( string subject )
      {
         ScenarioContext.Current.Pending();
      }

      [When( @"I read the commit file" )]
      public void WhenIReadTheCommitFile()
      {
         ScenarioContext.Current.Pending();
      }

      [Then( @"the subject should be ""(.*)""" )]
      public void ThenTheSubjectShouldBe( string subject )
      {
         ScenarioContext.Current.Pending();
      }
   }
}
