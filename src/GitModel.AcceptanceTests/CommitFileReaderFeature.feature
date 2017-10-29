Feature: CommitFileReader
   As a commit editor writer
   I want to read Git commit files
   So I can allow the user to edit their commit message

@Acceptance
Scenario: Can read subject from commit file
   Given the commit file has subject "This is the subject"
   When I read the commit file
   Then the subject should be "This is the subject"
