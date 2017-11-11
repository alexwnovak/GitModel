using System.IO;
using TechTalk.SpecFlow;
using FluentAssertions;
using GitModel;
using GitModel.AcceptanceTests.ModelObjects;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class CommitFileWriterSteps
   {
      private readonly CommitDocumentObject _commitDocumentObject;

      public CommitFileWriterSteps( CommitDocumentObject commitDocumentObject )
      {
         _commitDocumentObject = commitDocumentObject;
      }
   }
}
