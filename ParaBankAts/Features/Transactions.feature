Feature: FindTransactions

Background:
	Given 2 accounts are created for user - Acc1, Acc2 and made transactions
		| from | to   | amount |
		| Acc1 | Acc2 | 27     |

Scenario Outline: Find Transaction By Amount
	When Amount is specified with <value>
	And <selected account> is selected in Account combobox
	And Corresponding Find Transactions Button is clicked
	Then Transactions page is opened
	And Transaction table is not empty
Examples:
	| criteria | selected account | value |
	| Amount   | Acc3             | 27    |