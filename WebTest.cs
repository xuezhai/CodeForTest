
test plan for google signup page

functinal:

1. test signup page can be launched in brown if url is sign up entered in browser
    verify the following
    a. the google loco shows
    b. signup form show
    c. google apps icon shows
    d. sign button show and can be navigate to another signin page.
    e. the url link ("I prefer", "term of service",  "privacy policy", "learn more", "help"), verify link to right pages

2. user signup forms
    a. new user can sign in with all valid information as specified by the page.
       try all valid inputs for all fields should allow user sign up;
    b. form field validation
       b1. user name: firstname, last name should not be blank, either one, or both, hint should show it is invalid, 
           try user name same as existed one should has hint show  (any error or still valid?)
       b2. email address: user can use a new gmail address or other email address, (try both invalid or valid no gmail address)
           specify an existed gmail account for new user should ask user to change the name
           create both valid or invalid account name (different chars with non alphanumeric chars)  or leave empty
       b3. password created meet the criteria should be success, 
           pwd type in should be hidden/encypted, no normal char display;
           pwd and confirmed match should be valid, pwd mismatch should display right mismatch error msg.
           invalid password (length not enough, invalid char included, special requirement not follow (number+char, lower/upper etc.) should fail and show error msg
       b4. DOB, 
           month dropdownlis verify, selectable for user.
           valid DOB should accept
           invlid DOB should fail (negative DOB, or DOB more than 120 year earlier?)
       b5. gender dropdown verify, and selectable for user
       b6. mobile phone: county list drop should be a complete list of all country/region in the world
                         mobile phone valid should work, tolerate space, dash, (), different length for mininum valid phone number or maximum phone number (try US valid phone first)
                    
       b7. robot field should show if checkbox not checked. and message should be verified for the right message
           robot field "sound", "help", "retry" all should be verified to work as expected.
       b8. location dropdown list should be verified to have right country list;
       b9. privacy checkbox should be checkable

     c. more user signup scenario
        1. try duplicate user name, but different email account, verify if fail 
        2. try duplicate user name, same or different DOB, verify if same user detected
        3. try different user name, but same email account, verify if fail
        4. try right error will be generated for user or not if has one, or multiple fields invalid, 
        5. try use the robot verification field to input to verify it is success for invalid signup;
        6. try use the robot verification field to input an invalid image number to verify it is fail for valid signup;
        7. try mandatory input field (name, email, pwd) and non mandatory field, verify missed mandatory fields will fail signup, and missed optional fields will stil allow signup

     d. verify all the create new user information is persistent/save in backend when user signup success
     e. co-current signup verification (same user in differnt browsers signup same time)
     f. expired(deprecated) user signup
     g, previous failed signup user retry.
  
security:
     1. verify user signup data is not cached/auto saved in current browser after the browser session expired or browser close. not expose to other users.
        either for failed signup or success signup.
     2. no auto user signin if user logout or without user permission for specific machines
     3. user profile access/update always need user signin
     4. password creation criteria should be applied to make sure passwords created to meet these criteria
     5. signup success need to be verified through email verification
     6. user signup senstive data (age, race, DOB, etc) only accessible to user him/herself, never exposed to third partys or other users;
     7. any hacking input (some script or batch/exe cmd through the input field) will cause any security threaten?
     8, signup url input in browser with extra parameters or script or batch/exe cmd will cause any security threaten?

performance/stress
    1. dropdown list load, signup page load should all be less than a second (or requirements defined), 
    2. signup failure, or success response page load should be less than a second.
    3. use UI automation to simulate thousands (or peak time user signup number, like 1000000?) users to signup at the specific time, and log the service respone time.
    4. url link in the page load time verification (all in second, no more than 2~3 second) on stardard config machine.
    5. load signup pages and do signup in machine with lower CPU, lower RAM, verify it is still accessible and finish signup
    6. load signup pages and do signup in machine with machines OS which may not suport javascript or not support latest javascript, verify the funitional feature is still accessible and finish signup
  
 
platforms: try select list of above scenario in different browsers(chrome(differnt, ie, firefox, etc) with different Browser version, and also try browser no longer support

           try select list above in diffent OS platform, windows (8, 10, 7, xp), Mac, linux with different OS version, also try OS no longer support.

languages: try select list above in all different languages (KOR, JPN, FR, ITA, etc.) where the signup page support

policheck: any pictures, words, logo, icon need to be verified that no violation to political/religious/race or other sensitive data. 
   
