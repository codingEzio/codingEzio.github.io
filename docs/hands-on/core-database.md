
## Context

- I'm NOT a DB dev
- I rarely operate on DB directly (I use ORM)
- I believe *if you didn't type the commands on the existing DB, it was all theory*
- I wanted to learn about DB from the ground up
- It was fun

-----

## Types of Keys

### Context

- Lots of types
- Some were DB-oriented, some were ER-oriented
- Identify the *One*, link each other or many
- Tightly related to real-world scenarios

### Explanation

> Words that were wrapped in brackets mean they are optional (excluding the end of the sentence)

- Primary Key: absolutely the *One*, not null (== CK)
- Foreign Key: link to another table's *One*
- Candidate Key: any Key that could ID the *One* (~= PK)
- Super Key: any (sets) of CK(s) that could ID the *One*
- Composite Key: any sets of Keys that could ID the *One*
- Alternate Key: any non-PK that could ID the *One* (CK - PK)

### Graph

```txt
+----------------------------------+
|             SUPER KEY            |
|  +----------------------------+  |
|  |      CANDIDATE KEYS        |  |
|  |  +----------------------+  |  |
|  |  |    PRIMARY KEY       |  |  |
|  |  |  +----------------+  |  |  |
|  |  |  |  FOREIGN KEY   |  |  |  |
|  |  |  +----------------+  |  |  |
|  |  +----------------------+  |  |
|  |                            |  |
|  |    ALTERNATE KEYS          |  |
|  +----------------------------+  |
|                                  |
|        COMPOSITE KEYS            |
+----------------------------------+
```

## How a Query was Executed in MySQL

### First Principle

- I requested, it finds & returns it, I got

### Diggin' Deeper

> Errors n mistakes happen. Lots of guesses n little time I got. References were from the project *mysql-server* in branch `trunk`, official documentation, StackOverflow and LLM (Sonnet 3.5 mostly)

#### Rough Process

- 连接管理：服务器随时候着，身份验证，权限验证
- 解析预理：析句为词元，检确语法，查数验限
- 查询优化：优写法，用索引，判联序，*想*好执行计划
- 计划生成：用 `EXPLAIN` 看引擎思路，其余发生在内部
- 执行计划：调用 CRUD API on DB files 并处理响应

#### Actual Process

##### Connection Handling

- <u>`sql/conn_handler/connection_handler_manager.cc` manages the connection handling</u>
- files like `connection_handler_one_thread.cc`  in the same level does the connection handling
- think of it like a powered n mature version of your own *setup a socket listening*  n *respond when specific command is received*

##### Parsing and Preparing

- <u>`parse_sql`  in `sql/sql_parse.cc` setup the parsing procedures</u>
- Line `thd→sql_parser()`  calls `THD:sql_parser`  in `sql/sql_class.c`  to transforming **received commands** into a parse tree
- External function "imported" inside `my_sql_parser_parse` does the parsing
    - First we got the `sql/sql_yacc.yy` which is the definition of the **SQL language subset understood by SQL** that could be compiled into parser functions which we would use later on
    - Gotta use *bison* that was declared in the `/CMakeLists.txt` which compiles the `.yy` file into each of its own `.cc` file that has methods we could invoke and use
    - The `sql/CMakeLists.txt` does the actual work for the conversion from `.yy` to `.cc` along with some other useful functions spanned in different generated files

##### Optimization and Preparation

- <u>`JOIN::optimize` in `sql/sql_optimizer.cc` does various kinds of optimizations from the parsed query statement</u>
    - a fuck ton of optimizations by types, in stages
    - preparations made specifically for the executor

##### Execution

- <u>`JOIN:get_best_combination` in `sql/sql_optimizer.cc` does additional optimizations and adjustments</u>
    - `Sql_cmd_dml::execute` does the actual SQL DML operations (Data Manipulation Language, aka. CRUD)
    - Via the `RowIterator` in `sql/iterators/row_iterator.h`to do something about the results you got from query execution

## How a SQL Query is Executed

### The Example

```sql
SELECT employees.name, COUNT(projects.project_id) as project_count
FROM employees
JOIN projects ON employees.id = projects.employee_id
WHERE employees.salary > 20000
GROUP BY employees.name
HAVING COUNT(projects.project_id) > 5
ORDER BY project_count DESC;
```

### The Procedure

- `FROM` the `employee` table
- With `JOIN`ing the `projects` table `ON` `employee_id` column
- Filter `WHERE` the `salary` is greater than 20000
- `GROUP BY` the `employee`'s `name`
- `HAVING` `project`s the `employee`s working on is greater than 5
- `ORDER BY` the number of `project`s the `employee` is working on in descending order

## Common Index Types

### B+ Tree Index

- most common, efficient enough
- support both exact and range queries

### Hash Index

- only avialable for *Memory* tables
- only support exact lookups (`=`, `IN`)

### Full-Text Index

- I'll write the notes once I've done the hands-on testing ;P

### Spatial Index

- I'll write the notes once I've done the hands-on testing ;P

-----

## Data Definition Operations

### Renaming a Database

> I guess it wasn't normally done. I purely changed it for the sake of learning.

- Get the new one created before renaming

```sql
CREATE DATABASE testdb;
```

- Generate the script based on the existing database

```sql
SELECT CONCAT(
    'RENAME TABLE ','`旧库`','.`',TABLE_NAME,
    '` TO ','`testdb`.`',TABLE_NAME,'`;'
)
FROM information_schema.TABLES
WHERE table_schema LIKE '旧库';
```

- Run the script

```sql
USE `旧库`;

-- the SQL generated from the previous step
```

### Table Partitioning

#### Context

> I wasn't in a position to do this in production, but I still wanted to learn about it.
>
> So I got a local MySQL database in Docker and tried it out.
all normal CRUDs would be exactly the same if not considering efficient queries.

- Firstly, it was normally done in the design phase with the table creation so that it knows which table it was operating on.

```sql
CREATE TABLE Quotes (
    row_id INT AUTO_INCREMENT,
    creator VARCHAR(255),
    quotes VARCHAR(255),
    created DATE,
    PRIMARY KEY (row_id, created)
)
PARTITION BY RANGE (YEAR(created)) (
    PARTITION p2019 VALUES LESS THAN (2020),
    PARTITION p2020 VALUES LESS THAN (2021),
    PARTITION p2021 VALUES LESS THAN (2022),
    PARTITION p2022 VALUES LESS THAN (2023),
    PARTITION p2023 VALUES LESS THAN (2024),
    PARTITION p2024 VALUES LESS THAN (2025)
);
```

- Secondly

    > making sure it was properly done, logically, in detail

```sql
SELECT * FROM information_schema.PARTITIONS
WHERE TABLE_SCHEMA = 'testdb' AND TABLE_NAME = 'Quotes';
```

- Checking how it was done, physically, in the file system

    > If you were like me, using MySQL Docker and be able to access the container

```sh
# enter the shell
docker exec -it mysql sh

# testdb is your database name
# quotes is your table name
ls /var/lib/mysql/testdb | grep -i quotes

# you are expected to see something like this

# /var/lib/mysql/testdb/
# ├── Quotes#P#p2019.ibd
# ├── Quotes#P#p2020.ibd
# ├── Quotes#P#p2021.ibd
# ├── Quotes#P#p2022.ibd
# ├── Quotes#P#p2023.ibd
# └── Quotes#P#p2024.ibd
```

- issues I've faced when *operating on an existing table* with complex relations (conclusion: not reading the docs long/carefully enough; should have done it in the design phase)
    - Foreign keys are not yet supported in conjunction with partitioning
    - A PRIMARY KEY must include all columns in the table's partitioning function (prefixed columns are not considered).
    - ..

### Get Sample Data for a Table

> The last line is the one you need to edit to match your table schema

```sql
USE `testdb`;

DELIMITER //

CREATE PROCEDURE GenerateSampleData(IN dbName VARCHAR(255), IN tableName VARCHAR(255))
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE randomName VARCHAR(255);
    DECLARE randomQuote VARCHAR(255);
    DECLARE randomDate DATE;

    DECLARE nameList VARCHAR(255) DEFAULT 'Alice,Bob,Charlie,David,Eve,Frank,Grace,Hank,Ivy,Jack';
    DECLARE quoteList VARCHAR(255) DEFAULT 'Sample quote 1.,Sample quote 2.,Sample quote 3.,Sample quote 4.,Sample quote 5.';

    WHILE i < 100000 DO
        SET randomName = ELT(1 + FLOOR(RAND() * 10), 'Alice', 'Bob', 'Charlie', 'David', 'Eve', 'Frank', 'Grace', 'Hank', 'Ivy', 'Jack');
        SET randomQuote = ELT(1 + FLOOR(RAND() * 5), 'Sample quote 1.', 'Sample quote 2.', 'Sample quote 3.', 'Sample quote 4.', 'Sample quote 5.');
        SET randomDate = DATE_ADD('2019-01-01', INTERVAL FLOOR(RAND() * 1825) DAY); -- Random date between 2019 and 2024

        SET @insertQuery = CONCAT('INSERT INTO ', dbName, '.', tableName, ' (creator, quotes, created) VALUES (''', randomName, ''', ''', randomQuote, ''', ''', randomDate, ''')');
        PREPARE stmt FROM @insertQuery;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;

        SET i = i + 1;
    END WHILE;
END //

DELIMITER ;

-- the DB wasn't specfial, just run `CREATE DATABASE testdb;` before this
-- the table definition shall be the same as **table partitioning** section
CALL GenerateSampleData('testdb', 'Quotes');
```

-----

## What's Up with the MVCC

> Full form: [*M*ulti*v*ersion *c*oncurrency *c*ontrol](https://en.wikipedia.org/wiki/Multiversion_concurrency_control)

### Databases are designed to be concurrent

- access/update, by users, by transactions and so on
- when accessing some record, others might be updating it
    - action of updating takes time
    - order of updating matters
- we might consider block it after writers are done
    - the transactions for read/update might be a huge one
    - this was achieved using locks
    - this would cause *contention* (subjects fight over something)

### MVCC is more of an addtional tool helping with concurrency

- IMO, it was meant to be used in conjunction with locks
- It does three main things, IMO
    > All got a hidden timestamp/transaction id to ensure uniqueness

- Read
    - get the most recent ver. of the record, no blocking
    - might not be the latest (someone might be updating it)
- Write
    - current operation creates new ver (with timestamp or transaction ID), no blocking
    - Older versions are still available for reading
- Garbage collection
    - the older versions [were stored in the undo log](https://mariadb.com/kb/en/innodb-purge/)
    - for InnoDB in MySQL, it's a process that [runs periodically](https://dev.mysql.com/doc/refman/8.4/en/innodb-purge-configuration.html)

- For the case explained above, *Isolation Level* came into play, context below
    - Different types of them for different strictness levels
    - Categorized by read phenomenon (~=how bad is it)
    - Scenarios mentioned above were *Snapshot Isolation* <sup>reference needed</sup>
    - Different DB have widely different *default* isolation levels
