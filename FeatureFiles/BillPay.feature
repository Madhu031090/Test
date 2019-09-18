Feature: BillPay
	In order BillPay between the accounts
	As a Qa
	I want to test the BillPay  Functionality

@BillPay
Scenario: UITest - Test the Bill payemnt Service page
Given I have logged in and I am on the home page
When I click on BillPay link
Then I should land on the BillPay Page
Then I enter the Payee Information
And Submit the payee information
Then I should the bill pay service should be successful



