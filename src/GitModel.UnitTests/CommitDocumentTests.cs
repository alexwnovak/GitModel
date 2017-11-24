using FluentAssertions;
using Xunit;

namespace GitModel.UnitTests
{
   public class CommitDocumentTests
   {
      [Fact]
      public void Clear_HasSubject_SubjectIsCleared()
      {
         var commitDocument = new CommitDocument( "Not empty" );

         commitDocument.Clear();

         commitDocument.Subject.Should().BeEmpty();
      }

      [Fact]
      public void Clear_HasBody_BodyIsCleared()
      {
         var commitDocument = new CommitDocument
         {
            Body = new[] { "Not empty" }
         };

         commitDocument.Clear();

         commitDocument.Body.Should().BeEmpty();
      }
   }
}
