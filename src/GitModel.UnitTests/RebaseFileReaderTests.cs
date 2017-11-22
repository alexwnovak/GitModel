using System;
using Xunit;
using FluentAssertions;
using Moq;
using GitModel.Internal;
using GitModel.UnitTests.Helpers;

namespace GitModel.UnitTests
{
   public class RebaseFileReaderTests
   {
      [Theory]
      [InlineData( null )]
      [InlineData( "" )]
      public void FromFile_FilePathIsInvalid_ThrowsArgumentException( string filePath )
      {
         var rebaseFileReader = new RebaseFileReader( Mock.Of<IFileSystem>() );

         Action fromFile = () => rebaseFileReader.FromFile( filePath );

         fromFile.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void FromFile_RebaseFileHasOneItem_ReadsItem()
      {
         const string filePath = "RebaseFile.txt";
         string rebaseLine = RebaseItemHelper.Create( RebaseAction.Pick, "d768f10", "WIP" );

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Returns( rebaseLine.AsArray() );

         // Act

         var rebaseFileReader = new RebaseFileReader( fileSystemMock.Object );

         var rebaseDocument = rebaseFileReader.FromFile( filePath );

         // Assert

         rebaseDocument.Items.Should()
            .HaveCount( 1 )
            .And
            .Contain( i => i.Action == RebaseAction.Pick
               && i.CommitHash == "d768f10"
               && i.Subject == "WIP" );
      }

      [Fact]
      public void FromFile_RebaseFileHasOneItemWithSpacesInItsSubject_ReadsItem()
      {
         const string filePath = "RebaseFile.txt";
         string rebaseLine = RebaseItemHelper.Create( RebaseAction.Pick, "d768f10", "This has spaces in it" );

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Returns( rebaseLine.AsArray() );

         // Act

         var rebaseFileReader = new RebaseFileReader( fileSystemMock.Object );

         var rebaseDocument = rebaseFileReader.FromFile( filePath );

         // Assert

         rebaseDocument.Items.Should()
            .HaveCount( 1 )
            .And
            .Contain( i => i.Action == RebaseAction.Pick
               && i.CommitHash == "d768f10"
               && i.Subject == "This has spaces in it" );
      }

   }
}
