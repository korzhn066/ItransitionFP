CREATE FULLTEXT CATALOG FullTextCatalog AS DEFAULT;
CREATE FULLTEXT INDEX ON Items(Name) KEY INDEX PK_Items ON FullTextCatalog;
CREATE FULLTEXT INDEX ON Collections(Name, Description) KEY INDEX PK_Collections ON FullTextCatalog;
CREATE FULLTEXT INDEX ON TagItems(Body) KEY INDEX IX_TagItems_Index ON FullTextCatalog;