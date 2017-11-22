﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using FluentAssertions;
using GitModel.Internal;
using GitModel.UnitTests.Helpers;

namespace GitModel.UnitTests
{
   public class RebaseFileWriterTests
   {
      [Theory]
      [InlineData( null )]
      [InlineData( "" )]
      public void ToFile_FilePathIsInvalid_ThrowsArgumentException( string filePath )
      {
         var rebaseFileWriter = new RebaseFileWriter( Mock.Of<IFileSystem>() );

         Action toFile = () => rebaseFileWriter.ToFile( filePath, null );

         toFile.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void ToFile_RebaseDocumentIsNull_ThrowsArgumentException()
      {
         var rebaseFileWriter = new RebaseFileWriter( Mock.Of<IFileSystem>() );

         Action toFile = () => rebaseFileWriter.ToFile( "NotNullString", null );

         toFile.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void ToFile_RebaseDocumentHasOneCompleteItem_ItemIsWritten()
      {
         const string filePath = "COMMIT_EDITMSG";

         var fileSystemMock = new Mock<IFileSystem>();

         var rebaseItem = new RebaseItem
         {
            Action = RebaseAction.Edit,
            CommitHash = "Hash",
            Subject = "Subject"
         };

         var rebaseDocument = new RebaseDocument
         {
            Items = rebaseItem.AsArray()
         };

         var rebaseFileWriter = new RebaseFileWriter( fileSystemMock.Object );

         rebaseFileWriter.ToFile( filePath, rebaseDocument );

         fileSystemMock.Verify( fs => fs.WriteAllLines( filePath, It.Is<IEnumerable<string>>( c =>
            c.Contains( rebaseItem.ToString() ) ) ), Times.Once() );
      }
   }
}
