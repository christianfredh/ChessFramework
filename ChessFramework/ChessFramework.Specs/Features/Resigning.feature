Feature: Resigning

Scenario: Resigning
	Given a new game
	And the game has just started
	When White resigns
	Then Black should be the winner
