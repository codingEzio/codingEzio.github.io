from dataclasses import dataclass, field
from typing import List, Dict, Any, Optional
from uuid import uuid4
import time


@dataclass
class Row:
    data: Dict[str, Any]
    row_id: str = field(default_factory=lambda: str(uuid4()))
    created_at: float = field(default_factory=time.time)
    deleted: bool = False


@dataclass
class Page:
    page_id: str = field(default_factory=lambda: str(uuid4()))
    size: int = 16384  # 16KB default page size
    rows: List[Row] = field(default_factory=list)
    free_space: int = 16384

    def add_row(self, row: Row) -> bool:
        row_size = len(str(row.data))  # Simplified size calculation
        if self.free_space >= row_size:
            self.rows.append(row)
            self.free_space -= row_size
            return True
        return False


@dataclass
class Extent:
    extent_id: str = field(default_factory=lambda: str(uuid4()))
    size: int = 1048576  # 1MB default extent size
    pages: List[Page] = field(default_factory=list)

    def add_page(self, page: Page):
        if len(self.pages) * page.size < self.size:
            self.pages.append(page)


@dataclass
class Segment:
    segment_id: str = field(default_factory=lambda: str(uuid4()))
    extents: List[Extent] = field(default_factory=list)

    def add_extent(self, extent: Extent):
        self.extents.append(extent)


@dataclass
class TableSpace:
    name: str
    tablespace_id: str = field(default_factory=lambda: str(uuid4()))
    segments: List[Segment] = field(default_factory=list)

    def add_segment(self, segment: Segment):
        self.segments.append(segment)


@dataclass
class Index:
    name: str
    columns: List[str]
    unique: bool = False


@dataclass
class Table:
    name: str
    columns: List[str]
    primary_key: Optional[str] = None
    indexes: List[Index] = field(default_factory=list)
    auto_increment: int = 1

    def add_index(self, index: Index):
        self.indexes.append(index)

    def insert_row(self, data: Dict[str, Any]) -> Row:
        if self.primary_key and self.primary_key not in data:
            data[self.primary_key] = self.auto_increment
            self.auto_increment += 1
        return Row(data=data)


@dataclass
class Database:
    name: str
    tables: Dict[str, Table] = field(default_factory=dict)
    tablespaces: Dict[str, TableSpace] = field(default_factory=dict)

    def create_table(self, table: Table):
        self.tables[table.name] = table

    def create_tablespace(self, tablespace: TableSpace):
        self.tablespaces[tablespace.name] = tablespace


@dataclass
class Instance:
    port: int = 3306
    max_connections: int = 151
    databases: Dict[str, Database] = field(default_factory=dict)

    def create_database(self, database: Database):
        self.databases[database.name] = database


def main():
    # Create instance
    mysql_instance = Instance(port=3307, max_connections=200)

    # Create database
    db = Database(name="example_db")
    mysql_instance.create_database(db)

    # Create table
    users_table = Table(name="users", columns=["id", "name", "email"], primary_key="id")
    users_table.add_index(Index(name="idx_email", columns=["email"], unique=True))
    db.create_table(users_table)

    # Create tablespace
    users_tablespace = TableSpace(name="users_space")
    db.create_tablespace(users_tablespace)

    # Insert rows
    row1 = users_table.insert_row({"name": "Alice", "email": "alice@example.com"})
    row2 = users_table.insert_row({"name": "Bob", "email": "bob@example.com"})

    # Create physical structure
    segment = Segment()
    extent = Extent()
    page = Page()

    page.add_row(row1)
    page.add_row(row2)
    extent.add_page(page)
    segment.add_extent(extent)
    users_tablespace.add_segment(segment)

    # Print structure
    print(
        f"MySQL Instance (Port: {mysql_instance.port}, Max Connections: {mysql_instance.max_connections})"
    )
    for db_name, database in mysql_instance.databases.items():
        print(f"  Database '{db_name}':")
        for table_name, table in database.tables.items():
            print(f"    Table '{table_name}':")
            print(f"      Columns: {', '.join(table.columns)}")
            print(f"      Primary Key: {table.primary_key}")
            print(f"      Indexes: {', '.join(idx.name for idx in table.indexes)}")
        for ts_name, tablespace in database.tablespaces.items():
            print(f"    Tablespace '{ts_name}' (ID: {tablespace.tablespace_id}):")
            for segment in tablespace.segments:
                print(f"      Segment (ID: {segment.segment_id}):")
                for extent in segment.extents:
                    print(f"        Extent (ID: {extent.extent_id}):")
                    for page in extent.pages:
                        print(
                            f"          Page (ID: {page.page_id}, Free Space: {page.free_space}):"
                        )
                        for row in page.rows:
                            print(f"            Row (ID: {row.row_id}): {row.data}")


if __name__ == "__main__":
    main()
