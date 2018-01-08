/*
The database must have a MEMORY_OPTIMIZED_DATA filegroup
before the memory optimized object can be created.
*/

CREATE TYPE [dbo].[IntList] AS TABLE
(
	[Item] INT NOT NULL PRIMARY KEY 
) 