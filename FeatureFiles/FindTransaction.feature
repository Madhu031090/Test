Feature: FindTransactions
	In order to find any previous transactions
	As a QA
	I want to test the Find Transactions functionality

@FindTransactions
Scenario: UITest - Find Transactions by Amount
	Given I have logged in and I am on the home page
	When I click on transfer funds link
	And I enter an amount in the amount Field
	And then I select a From Account and a To Account
	When I click transfer to transfer the funds
	Then the transfer happens successfully
	When I click on Find transactions link
	And I enter an amount in the Find Transaction's amount Field
	And I click on Find Transactions by Amount
	Then I should see the Transaction Results

