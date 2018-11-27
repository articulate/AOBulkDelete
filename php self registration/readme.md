Self Registration
=================

What it does?

This web application takes the email address and password from a form on a web page and then creates a user on a specified Articulate Online account.  In other words, it does “self-registration.”

What are the requirements?

An Articulate Online account with the AO API enabled (How to?)
A server that supports and has PHP installed
Nusoap (don’t be scared by this, it is free, and I’ll explain later)
How it works?

Here is basically what happens:

A user goes to the registration form (selfreg.php)
The user fills in the form and clicks “Register”
The form data is sent to register.php
register.php takes the data from the form, connects to the AO API
register.php tries to create the user in your Articulate Online account
The user gets a status message saying they were added to the Articulate Online account (or not added in the case of an error)
Installation and Configuration Instructions:

Installation and configuration is meant to be pretty straight forward and as painless as possible. 

Here is what you need to do:

1. Install nusoap

Nusoap is basically just a set of files (PHP class files) that allow you to connect to the Articulate Online API via PHP.

Download nusoap from SourceForge
Unzip the files
Upload the folder to your webserver
That’s it.  You now have access to nusoap.

2. Next, Install and Configure the application

There are 3 files included in this application:

selfreg.php – is a straight forward HTML page that contains a form that asks for email, password, and confirm password.  It also does some input validation to make sure the email address is valid, and the passwords are valid passwords.
register.php – is the meat of the application.  It connects to the API, creates the user, then gives a status message (success, or fail)
config.php – contains all the configuration options of the application.
Download the source files here.
Unzip the files
Open the register.php file in notepad
Find this line:
require_once(‘../../lib/nusoap.php’); 
Change this section ‘../../lib/nusoap.php’ to point to your nusoap installation
Open config.php in notepad
The config.php file contains all the configuration options for your application.  You will need to change these to meet your needs.  In this file you will have several different variables you need to set.  These variables are what are used to connect to the API, and what you want the app to do.  Here is an explanation of what they are:
$emailaddress – an administrators email address
$password – the administrators password
$customerID – your customer ID.  Your customer ID can be found by looking at the URL in your browser’s address bar after logging in to Articulate Online. The numeric value specified in the title bar for CustID is your customer id.
$accountURL – the URL of your Articulate Online account.
$sendLoginEmail – When a user registers, should AO send them an email?  (true/false are values)
$comment – If you want to send an email to the registered user, what text should it contain.  Leave blank for nothing.
After changing the configuration options, save the config.php file
Upload the application to your website
You are done, that is it.

Try the application

Now that you have installed and configured the application, point your browser to the selfreg.php file.  Fill in the options and test it out.

Sample in action

Now that I have explained the applicaiton, maybe you want to check it out.  I have uploaded this sample to my website, and connected it to a sample Articulate Online account.  You can try it here:

http://www.mozealous.com/samples/selfregister/selfreg.php

Once you have registered, you will be given an opportunity to login to my Articulate Online account as a newly registered user.

That is it, hope this was all straight forward and easy to follow.  Feel free to comment if you have any questions!

