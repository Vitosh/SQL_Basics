(localdb)\MSSQLLocalDB

To Check in CommandPrompt:
sqllocaldb info

Visual Studio Data Tools -> needed for -> SQL Server Object Explorer
http://stackoverflow.com/questions/30894755/ssdt-for-visual-studio-2015
SSDT 2015 RTM for visual studio 2015 is found here.
https://msdn.microsoft.com/en-us/mt186501.aspx

Problem with diagram:
DB>Properties>Files>Owner>sa

When deleting DB:
checkbox "close existing connection" - checked

AutoIncrement>Property>Identity Specification>Yes

Tools>Options>Designers node>Uncheck
Prevent saving changes that require table recreation.

types:
ntext - for a big text
nvarchar(MAX) - when it is small - nvarchar, when it is big - ntext

Default value:
Date>Properties>Default Value or Binding>GETDATE()

To add new key:
select column in table in diagram;
select indexes/keys from dropdown;
select column;
Is Unique-> Yes;
