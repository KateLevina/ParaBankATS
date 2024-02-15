Feature: Account

A short summary of the feature

Background:
	Given user with several accounts is logged in


Scenario: Account Details info displayed
	When User navigates to Account Overview
	And Clicks on Account number link
	Then details page is displayed
	And Account Number value is not empty
	And Account Type value is not empty
	And Balance value is not empty
	And Available value is not empty
	And Account Activity filter values are set to All