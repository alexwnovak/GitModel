Feature: CommitFileWriter
   As a commit editor writer
   I want to write Git commit files
   So I can give the user's commit to Git for committing

@Acceptance
Scenario: Can write subject to commit file
   Given the commit subject is "This is the subject"
   When I write the commit file
   Then the commit file subject is "This is the subject"

@Acceptance
Scenario: Can write the body to the commit file
   Given the commit subject is "This is the subject"
   And the commit body has the lines "Line one,Line two,Line three"
   And I write the commit file
   When I read the commit file
   Then the commit file subject body has the lines "Line one,Line two,Line three"
