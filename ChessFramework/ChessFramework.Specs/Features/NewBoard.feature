Feature: A new board
	When using a new board
	I want the board set up correctly

Scenario: A new board
	Given a new board
	Then the board colors should look like
	|   |   |   |   |   |   |   |	|
	| W | B | W | B | W | B | W | B |
	| B | W | B | W | B | W | B | W |
	| W | B | W | B | W | B | W | B |
	| B | W | B | W | B | W | B | W |
	| W | B | W | B | W | B | W | B |
	| B | W | B | W | B | W | B | W |
	| W | B | W | B | W | B | W | B |
	| B | W | B | W | B | W | B | W |
	And the board should look like
	|     |     |     |     |     |     |     |		|
	| BRo | BKn | BBi | BQu | BKi | BBi | BKn | BRo |
	| BPa | BPa | BPa | BPa | BPa | BPa | BPa | BPa |
	|     |     |     |     |     |     |     |		|
	|     |     |     |     |     |     |     |		|
	|     |     |     |     |     |     |     |		|
	|     |     |     |     |     |     |     |		|
	| WPa | WPa | WPa | WPa | WPa | WPa | WPa | WPa |
	| WRo | WKn | WBi | WQu | WKi | WBi | WKn | WRo |
