Solution:
--------

The solution was created using the following technology:

Project created with Visual Studio 2019, after open the solution do a "Restore Nuget Packages"over the SalesTaxes solution followed by a Rebuild Solution.

Portal:
   Sales.Portal -> Net Framework 4.6.1 - ASPNET Core 2.1 with React (Simple front end app with basic layout)

Api:
   Sales.Api    -> Net Framework 4.6.1 - ASPNET Core 2.1 with AutoFac, AutoMapper

Services:
   SalesServices   -> Net Framework 4.6.1 - with AutoMapper for DTO

Data:
   SalesRepository -> Net Framework 4.6.1 - with Entity Framework using Repository Pattern



Test unit can be created upon request (are not part of the assigment)



Assignment
-------------
Problem Statement: Sales Taxes

Basic tax is applicable at a rate of 10% on all goods, except books, food, and medical products that are
exempt. Import duty is an additional tax applicable on all imported goods at a rate of 5%, with no exceptions.
When I purchase items I receive a receipt which lists the name of all the items and their price (including tax),
finishing with the total cost of items, and the total amount of tax paid.

The rounding rules for tax are:
For a tax rate of n%, a shelf price of p contains (np / 100 rounded up to the nearest 0.05) amount of
tax.

Write an application that prints out the receipt details for these shopping baskets:

Input 1:
1 Book at 12.49
1 Music CD at 14.99
1 Chocolate bar at 0.85

Input 2:
1 Imported box of chocolates at 10.00
1 Imported bottle of perfume at 47.50

Input 3:
1 Imported bottle of perfume at 27.99
1 Bottle of perfume at 18.99
1 Packet of paracetamol at 9.75
1 Box of imported chocolates at 11.25


Once calculated the following output should be shown.

Output 1:
1 book : 12.49
1 music CD: 16.49
1 chocolate bar: 0.85
Sales Taxes: 1.50
Total: 29.83

Output 2:
1 imported box of chocolates: 10.50
1 imported bottle of perfume: 54.65
Sales Taxes: 7.65
Total: 65.15

Output 3:
1 imported bottle of perfume: 32.19
1 bottle of perfume: 20.89
1 packet of headache pills: 9.75
1 Box of imported chocolates: 11.85
Sales Taxes: 6.70
Total: 74.68