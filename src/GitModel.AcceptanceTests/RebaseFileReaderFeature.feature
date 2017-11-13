Feature: RebaseFileReaderFeature
	As an interactive rebase editor writer
	I want to read Git rebase files
	So I can allow the user to configure how their rebase behaves

@Acceptance
Scenario: Reading rebase file
	Given the rebase has the following:
   | RebaseAction | CommitHash | Description                  |
   | Pick         | 5bf115d    | This is a commit             |
   | Pick         | 2525a53    | Another commit               |
   | Pick         | f799a4f    | A third commit               |
	And the rebase file exists
   When I read the rebase file
   Then the rebase document should contain:
   | RebaseAction | CommitHash | Description                  |
   | Pick         | 5bf115d    | This is a commit             |
   | Pick         | 2525a53    | Another commit               |
   | Pick         | f799a4f    | A third commit               |
	