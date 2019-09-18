Feature: TransferFunds
	In order Transfer funds between the accounts
	As a Qa
	I want to test the Transfer Funds  Functionality

@TransferFunds 
Scenario: UITest - Transfer Funds between Accounts
   Given I have logged in and I am on the home page
   When I click on transfer funds link
	And I enter an amount in the amount Field
	And then I select a From Account and a To Account
	When I click transfer to transfer the funds
	Then the transfer happens successfully
