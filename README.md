# Simple Payroll

A complete console application that generates the salary slips of a small company 

## Overview
This application consists of six classes as shown below:
1. Staff
	* contains information about each staff in the company.
	* contains virtual method that calculates the pay of each staff.
2. Manager : Staff
	* inherit the staff class and override the paying method
3. Admin : Staff
	* inherit the staff class and override the paying method
4. FileReader
	* contains a method that reads from .txt file and create a list of Staff objects based on the contents in .txt file.
5. PaySlip
	* generates the pay slip of each employee in the company and summary of details of staff who worked less than 10 hours in a month.
6. Program
	* contains main method which acts as the main entry point of our application
