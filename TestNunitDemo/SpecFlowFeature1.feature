Feature: SpecFlowFeature1
	Here to automate my application by using all possible Speclfow options


@Login
Scenario Outline: Login to Application with Different users
When I Enter UserName <UserName> and Password <Password>
And I Perform Login Action
Then I should be landed on the appropriate <landingPage> pages
Examples: 
| UserName      | Password      | landingPage |
| opensourcecms | opensourcecms | True         |
| InvalidUser   | Test@123      | False        |

@Publish
Scenario: Publish New Pages 
When I Enter the UserName as "opensourcecms" and Password as "opensourcecms" 
And I Perform Login Action
And I Click Pages Link
And I get the Published Page Count
And I click Add New Page
And I enter Page Title do actions
| PageActions  |
| Publish |
Then I validate the Published count has been increrased 

@Draft
Scenario: Draft New Pages 
When I Enter the UserName as "opensourcecms" and Password as "opensourcecms" 
And I Perform Login Action
And I Click Pages Link
And I get the Drafted Page Count
And I click Add New Page
And I enter Page Title do actions
| PageActions  |
| SavePages |
Then I validate the Drafted count has been increrased 
