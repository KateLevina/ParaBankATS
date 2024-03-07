Feature: FindTransactions

Background:
	Given Accounts are created for user - Acc1, Acc2 and made transactions

Scenario Outline: Find Transaction By Amount
	When Amount is specified with <value>
	And Last created account is selected in Account combobox
	And Corresponding Find Transactions Button is clicked
	Then Transactions page is opened
	And Transaction table is not empty
Examples:
	| criteria | value |
	| Amount   | 27    |