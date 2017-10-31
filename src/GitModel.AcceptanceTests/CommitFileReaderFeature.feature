﻿Feature: CommitFileReader
   As a commit editor writer
   I want to read Git commit files
   So I can allow the user to edit their commit message

@Acceptance
Scenario: Can read subject from commit file
   Given the commit subject is "This is the subject"
   And the commit file exists
   When I read the commit file
   Then the subject should be "This is the subject"

@Acceptance
Scenario: Can read the body from the commit file
   Given the commit subject is "This is the subject"
   And the commit body has the lines "Line one,Line two,Line three"
   And the commit file exists
   When I read the commit file
   Then the body should be the lines "Line one,Line two,Line three"
