using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Moq;
using GitModel;
using GitModel.Internal;

namespace GitModel.UnitTests
{
   public class CommitFileWriterTests
   {
      [Theory]
      [InlineData( null )]
      [InlineData( "" )]
      public void ToFile_FilePathIsInvalid_ThrowsArgumentException( string filePath )
      {
         var commitFileWriter = new CommitFileWriter( Mock.Of<IFileSystem>() );

         Action toFile = () => commitFileWriter.ToFile( filePath, new CommitDocument() );

         toFile.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void ToFile_CommitDocumentIsNull_ThrowsArgumentException()
      {
         var commitFileWriter = new CommitFileWriter( Mock.Of<IFileSystem>() );

         Action toFile = () => commitFileWriter.ToFile( "NotNullString", null );

         toFile.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void ToFile_CommitDocumentHasSubject_SubjectIsWritten()
      {
         const string filePath = "COMMIT_EDITMSG";
         const string subject = "Commit subject";

         var fileSystemMock = new Mock<IFileSystem>();

         var commitDocument = new CommitDocument
         {
            Subject = subject
         };

         var commitFileWriter = new CommitFileWriter( fileSystemMock.Object );

         commitFileWriter.ToFile( filePath, commitDocument );

         fileSystemMock.Verify( fs => fs.WriteAllLines( filePath, It.Is<IEnumerable<string>>( c =>
            c.Contains( subject ) ) ), Times.Once() );
      }

      [Fact]
      public void ToFile_CommitDocumentHasSubjectAndBody_BodyIsWritten()
      {
         const string filePath = "COMMIT_EDITMSG";
         var body = new[]
         {
            "Line 1",
            "Line 2"
         };

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.WriteAllLines( It.IsAny<string>(), It.IsAny<IEnumerable<string>>() ) )
            .Callback<string, IEnumerable<string>>( Assert );

         var commitDocument = new CommitDocument
         {
            Subject = "DoesntMatter",
            Body = body
         };

         var commitFileWriter = new CommitFileWriter( fileSystemMock.Object );

         commitFileWriter.ToFile( filePath, commitDocument );

         void Assert( string actualFilePath, IEnumerable<string> actualContents )
         {
            actualContents.Should().Contain( body );
         }
      }

      [Fact]
      public void ToFile_DiskAccessFails_ThrowsGitModelExceptionWithCorrectInnerException()
      {
         var innerException = new UnauthorizedAccessException();

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.WriteAllLines( It.IsAny<string>(), It.IsAny<IEnumerable<string>>() ) )
            .Throws( innerException );

         var commitDocument = new CommitDocument
         {
            Subject = "Valid Subject",
            Body = new[] { "Valid Body" }
         };

         var commitFileWriter = new CommitFileWriter( fileSystemMock.Object );

         Action toFile = () => commitFileWriter.ToFile( "Valid File Path", commitDocument );

         toFile.ShouldThrow<GitModelException>().Which.InnerException.Should().Be( innerException );
      }
   }
}
