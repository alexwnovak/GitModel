using System;
using Xunit;
using FluentAssertions;
using Moq;
using GitModel.Internal;

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
         var lines = new[]
         {
            "pick d768f10 WIP"
         };

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.ReadAllLines( filePath ) ).Returns( lines );

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
   }
}
