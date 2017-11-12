using System;
using System.IO;
using Xunit;
using FluentAssertions;
using Moq;
using GitModel;
using GitModel.Internal;
using GitModel.UnitTests.Helpers;

namespace GitModel.UnitTests
{
   public class CommitFileReaderTests
   {
      [Theory]
      [InlineData( null )]
      [InlineData( "" )]
      public void FromFile_FilePathIsInvalid_ThrowsArgumentException( string filePath )
      {
         var commitFileReader = new CommitFileReader( Mock.Of<IFileSystem>() );

         Action fromFile = () => commitFileReader.FromFile( filePath );

         fromFile.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void FromFile_FilePathIsEmptyString_ThrowsArgumentException()
      {
         var commitFileReader = new CommitFileReader( Mock.Of<IFileSystem>() );

         Action fromFile = () => commitFileReader.FromFile( string.Empty );

         fromFile.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void FromFile_CommitFileHasSubject_PopulatesSubject()
      {
         const string filePath = "DoesntMatter";
         const string subject = "DoesntMatter";

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Returns( new[] { subject } );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         var commitDocument = commitFileReader.FromFile( filePath );

         // Assert

         commitDocument.Subject.Should().Be( subject );
      }

      [Fact]
      public void FromFile_CommitFileHasCommentsBeforeSubject_PopulatesSubject()
      {
         const string filePath = "DoesntMatter";
         const string subject = "DoesntMatter";

         var lines = new[]
         {
            "# A comment",
            subject
         };

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Returns( lines );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         var commitDocument = commitFileReader.FromFile( filePath );

         // Assert

         commitDocument.Subject.Should().Be( subject );
      }

      [Fact]
      public void FromFile_CommitFileStartsWithBlankLine_PopulatesSubject()
      {
         const string filePath = "DoesntMatter";
         const string subject = "DoesntMatter";

         var lines = new[]
         {
            "",
            subject
         };

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Returns( lines );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         var commitDocument = commitFileReader.FromFile( filePath );

         // Assert

         commitDocument.Subject.Should().Be( subject );
      }

      [Fact]
      public void FromFile_CommitFileHasOneLineBodyAfterOneBlankLine_PopulatesBody()
      {
         const string filePath = "DoesntMatter";
         const string body = "Body";

         var lines = new[]
         {
            "Subject",
            "",
            body
         };

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Returns( lines );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         var commitDocument = commitFileReader.FromFile( filePath );

         // Assert

         commitDocument.Body.Should().BeEquivalentTo( body.AsArray() );
      }

      [Fact]
      public void FromFile_CommitFileHasOneLineBodyAfterTwoBlankLines_PopulatesBody()
      {
         const string filePath = "DoesntMatter";
         const string body = "Body";

         var lines = new[]
         {
            "Subject",
            "",
            "",
            body
         };

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Returns( lines );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         var commitDocument = commitFileReader.FromFile( filePath );

         // Assert

         commitDocument.Body.Should().BeEquivalentTo( body.AsArray() );
      }

      [Fact]
      public void FromFile_CommitFileHasTwoLineBody_PopulatesBody()
      {
         const string filePath = "DoesntMatter";
         const string bodyL1 = "BodyLine1";
         const string bodyL2 = "BodyLine2";

         var lines = new[]
         {
            "Subject",
            "",
            bodyL1,
            bodyL2
         };

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Returns( lines );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         var commitDocument = commitFileReader.FromFile( filePath );

         // Assert

         var expectedLines = ArrayHelper.Create( bodyL1, bodyL2 );

         commitDocument.Body.Should().BeEquivalentTo( expectedLines );
      }

      [Fact]
      public void FromFile_CommitFileHasTwoLineBodySeparatedByBlankLine_PopulatesBody()
      {
         const string filePath = "DoesntMatter";
         const string bodyL1 = "BodyLine1";
         const string bodyL2 = "BodyLine2";

         var lines = new[]
         {
            "Subject",
            "",
            bodyL1,
            "",
            bodyL2
         };

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Returns( lines );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         var commitDocument = commitFileReader.FromFile( filePath );

         // Assert

         var expectedLines = ArrayHelper.Create( bodyL1, "", bodyL2 );

         commitDocument.Body.Should().BeEquivalentTo( expectedLines );
      }

      [Fact]
      public void FromFile_CommitFileHasTwoLineBodySeparatedByBlankLineWithCommentInTheMiddle_PopulatesBody()
      {
         const string filePath = "DoesntMatter";
         const string bodyL1 = "BodyLine1";
         const string bodyL2 = "BodyLine2";

         var lines = new[]
         {
            "Subject",
            "",
            bodyL1,
            "# This comment should be ignored",
            "",
            bodyL2
         };

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Returns( lines );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         var commitDocument = commitFileReader.FromFile( filePath );

         // Assert

         var expectedLines = ArrayHelper.Create( bodyL1, "", bodyL2 );

         commitDocument.Body.Should().BeEquivalentTo( expectedLines );
      }

      [Fact]
      public void FromFile_FilesDoesNotExist_ThrowsGitModelExceptionWithCorrectInnerException()
      {
         const string filePath = "COMMIT_EDITMSG";
         var innerException = new FileNotFoundException();

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Throws( innerException );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         Action fromFile = () => commitFileReader.FromFile( filePath );

         // Assert

         fromFile.ShouldThrow<GitModelException>().Which.InnerException.Should().Be( innerException );
      }
   }
}
