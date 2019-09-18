Feature: SmokeTests
	In order to make sure my application is stable
	As a QA
	I want to test if all the pages in my application is up and running


@SmokeTest	
Scenario: SmokeTest - All sites in the application are up and Running
Given I have logged in and I am on the home page
When I click on Open New Account link
Then I should land on the Open New Account Page
When I click on Accounts Overview link
Then I should land on the Accounts Overview Page
When I click on transfer funds link
Then I should land on the transfer funds page
When I click on BillPay link
Then I should land on the BillPay Page
When I click on Find transactions link
Then I should land on the Find transactions Page


	

