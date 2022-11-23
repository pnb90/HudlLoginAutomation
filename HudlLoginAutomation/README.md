# HudlLoginAutomation

A simple test automation suite for Phuoc's Hudl interview to test the basic functionality of the login page. 

## Description

This test automation suite is written in C# and Selenium with NUnit. 

## Getting Started

### Dependencies

* [DotNet v6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [NUnit v3.13.3](https://nunit.org/)
* [Selenium.WebDriver v4.6.0](https://www.selenium.dev/documentation/webdriver/)
* [Selenium.WebDriver.ChromeDriver v107](https://chromedriver.chromium.org/downloads)

### TroubleShooting

* Most common error is that the ChromeDriver included is out of date. If this occurs, then update the ChromeDriver to match the version running on your local machine. Learn more here: https://www.google.com/chrome/update/
* For further assistance in installing the Chromedriver, please refer to the article here: https://testguild.com/selenium-webdriver-visual-studio

### Installing

* Rename the `.samplerunsettingsfile` to `.runsettings` and insert test values to allow the test to run. Currently, `.runsettings` is added to .gitignore to prevent accidentally uploading sensitive data to GitHub. Make sure that the baseUrl does not have a trailing slash "/".
* Contact a QA team member to get the appropriate values for the `.runsettings` file.

### Executing program

* To run the test automation suite locally, navigate to the HudlLoginAutomation folder and run the following command in your terminal:

```
dotnet test --settings .runsettings
```

* Alternatively, if you have Visual Studio already installed
1. Open the solution locally.
2. Clean the solution.
3. Build the solution.
4. Open Test -> Test Explorer
5. Feel free to run/debug individually or as a group by either clicking the "Run All Tests in View" green arrow icon in the upper lefthand corner of the Test Explorer or by right-clicking the tests and selecting "Run" or "Debug."
`
### Future Steps 
* Add a driver management system to programatically update the driver to the most current/viable chromedriver as appropriate per environment
* Implementing a reporting system to be able to quickly diagnose and resolve errors
* Implementing fake data for login probably by using Faker to avoid hardcoding personal emails and passwords
* Adding API testing to speed up testing especially for more minor and repetitive test cases (i.e. null emails, etc.)
* Mobile testing
* Add testing for multiple browsers most commonly used by users
* Add parallel testing to cut down on time, especially with parallel browsers. 
* Remember Me testing with cookies
* Better/more secure method of storing/obscuring sensitive data
