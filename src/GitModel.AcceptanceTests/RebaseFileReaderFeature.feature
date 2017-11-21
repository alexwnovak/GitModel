Feature: RebaseFileReaderFeature
	As an interactive rebase editor writer
	I want to read Git rebase files
	So I can allow the user to configure how their rebase behaves

@Acceptance
Scenario: Reading rebase file
	Given the rebase has the following:
   | Action | CommitHash | Subject                  |
   | Pick         | 5bf115d    | This is a commit             |
   | Squash         | 2525a53    | Another commit               |
   | Squash       | f799a4f    | A third commit               |
	And the rebase file exists
   When I read the rebase file
   Then the rebase document should contain:
   | Action | CommitHash | Subject                  |
   | Pick         | 5bf115d    | This is a commit             |
   | Squash         | 2525a53    | Another commit               |
   | Squash         | f799a4f    | A third commit               |
	