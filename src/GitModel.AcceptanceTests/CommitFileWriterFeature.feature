Feature: CommitFileWriter
   As a commit editor writer
   I want to write Git commit files
   So I can give the user's commit to Git for committing

@Acceptance
Scenario: Can write subject to commit file
   Given the commit document subject is "This is the subject"
   When I write commit file
   Then the commit file subject is "This is the subject"
