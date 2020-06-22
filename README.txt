Hi,

I developed this project with dotnet core3.1 and AWS Lambda. I couldn't have configured a deployment artifact. 

If you have an installed visual studio with AWS lambda deployment tools and configured AWS profile, it is easy to deploy by using VS lambda deployment wizard or "dotnet lambda deploy-function" command. 

If not, you can configure the profile by following steps in this page : 
https://docs.aws.amazon.com/cli/latest/userguide/cli-configure-files.html -- https://docs.aws.amazon.com/cli/latest/userguide/cli-chap-configure.html ( to create user in AWS). 
And you can deploy the package by following steps in this page : 
https://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/lambda-cli-publish.html

As well as, I suggest ad quick and manual way to deploy the service below. 

WHAT IT DONE

* Fibonacci function is developed with three, Ackermann Functions is developed with two and Factorial function is developed with three different algoriths.
  Fibonacci has recursive, iterative and memorized functions
  Ackermann has recursive and iterative functions
  Factorial has recursive, iterative and memorized functions.
* All three functions work in parallel. However, their sub methods work in sequential.
* Their processing times are logged in AWs Cloudwatch 

WHAT IT CONSIDERED
* You can calculate maximum 20! because of long value type size. The value is validated by the code.
* Please don't use higher m and n values for Ackermann function because it takes longer to calculate and causes timeout error it is 15 secs. My suggestion is maximum 3 for m  and 10 for n.
* Please don't use higher n value for Fibonacci function because it takes longer to calculate and causes timeout error it is 15 secs. My suggestion is maximum 40 for n.

HOW TO DEPLOY

1. Create an aws free user account if you already don't have it. Follow the steps in this page -- https://aws.amazon.com/tr/premiumsupport/knowledge-center/create-and-activate-aws-account/
2. Login to AWS and Go to AWS Management Colsole
3. Search for "Lambda" in Find Services seach area and click it. AWS Lambda page has to be displayed. 
4. Click "Create Function" button on the right top side of the AWS Lambda page
5. Select "Author from scratch" section on the above list.
6. Type "DemoServerlessService" or any function name you want in the "Function Name" text area inside Basic Information section
7. Select ".NET Core 3.1 (C#/PowerShell)" from Runtime list inside Basic Information section.
8. Click "Create Function" button. The function must be created successfullly. The function configuration page should be displayed.
9. Go to "Basic Settings" section inside the function configuration page and click "Edit" button.
10. Enter "DemoServerlessService::DemoServerlessService.DemoServerlessService::ServiceHandler" into Handler text area 
11. Change the timeout value as you want. I suggest at least 59 secs.
12. Click "Save" button
13. Then, go to "Function code" section inside the function configuration page and Click "upload a .zip file" inside "Actions" list.
14. Upload "DemoServerlessServicePublish.zip" file that I sent by email and Click "Save" button. The file must be successfully uploaded.
Now, the function is ready to test.



HOW TO TEST 

1. If you are not in the DemoServerlessService page, please click DemoServerlessService inside the functions list in AWS Lambda page
2. Click "Configure test events" inside test list beside "Test" button on the top-right of the function configuration page.
3. Click "Create new test event" from the radio button list
4. Select "Hello World" event template from Event Template list if it is not selected by default.
5. Enter an event name you prefer into Event name text area
6. Paste the json text inside sample test data (sampletestdata.json) that I sent by email into json text area.
7. Click "Create" button.
8. Click "Test" button on the top-right of the function configuration page
 Now the result is displayed on the page.
