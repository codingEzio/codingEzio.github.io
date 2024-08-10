
## Context

- I'm NOT a DB dev
- I rarely operate on DB directly (I use ORM)
- I believe *if you didn't type the commands on the existing DB, it was all theory*
- I wanted to learn more about DB
- It was fun

-----

## How a Query is Done in MySQL

### First Principle

- I requested, it finds & returns it, I got

### Diggin' Deeper

- xx
- xx

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
