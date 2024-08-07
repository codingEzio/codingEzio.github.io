class Table:
    def __init__(self, name, data):
        self.name = name
        self.data = data


class Database:
    def __init__(self):
        self.tables = {}

    def add_table(self, table):
        self.tables[table.name] = table

    def inner_join(self, table1, table2, condition):
        result = []
        for row1 in self.tables[table1].data:
            for row2 in self.tables[table2].data:
                if condition(row1, row2):
                    result.append({**row1, **row2})
        return result

    def left_join(self, table1, table2, condition):
        result = []
        for row1 in self.tables[table1].data:
            matched = False
            for row2 in self.tables[table2].data:
                if condition(row1, row2):
                    result.append({**row1, **row2})
                    matched = True
            if not matched:
                result.append(
                    {**row1, **{k: None for k in self.tables[table2].data[0].keys()}}
                )
        return result

    def right_join(self, table1, table2, condition):
        return self.left_join(table2, table1, lambda x, y: condition(y, x))

    def full_join(self, table1, table2, condition):
        left = self.left_join(table1, table2, condition)
        right = self.right_join(table1, table2, condition)
        return left + [r for r in right if r not in left]

    def cross_join(self, table1, table2):
        return [
            {**row1, **row2}
            for row1 in self.tables[table1].data
            for row2 in self.tables[table2].data
        ]

    def self_join(self, table, condition):
        return self.inner_join(table, table, condition)


# Usage
db = Database()
db.add_table(
    Table("A", [{"id": 1, "val": "a"}, {"id": 2, "val": "b"}, {"id": 3, "val": "c"}])
)
db.add_table(
    Table("B", [{"id": 1, "val": "x"}, {"id": 2, "val": "y"}, {"id": 4, "val": "z"}])
)

inner = db.inner_join("A", "B", lambda x, y: x["id"] == y["id"])
left = db.left_join("A", "B", lambda x, y: x["id"] == y["id"])
right = db.right_join("A", "B", lambda x, y: x["id"] == y["id"])
full = db.full_join("A", "B", lambda x, y: x["id"] == y["id"])
cross = db.cross_join("A", "B")
self_join = db.self_join("A", lambda x, y: x["id"] < y["id"])

print("Inner Join:", inner)
print("Left Join:", left)
print("Right Join:", right)
print("Full Join:", full)
print("Cross Join:", cross)
print("Self Join:", self_join)
