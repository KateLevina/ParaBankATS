Feature: Account

Background:
	Given user with several accounts is logged in

Scenario Outline: Account Details info displayed
	When User navigates to Account Overview
	And Clicks on Account number link in the <row number> row of table
	Then details page is displayed
	And Account Number value is not empty
	And Account Type value is not empty
	And Balance value is not empty
	And Available value is not empty
	And Account Activity filter values are set to All
Examples:
	| row number |
	| 1          |
	| 2          |
