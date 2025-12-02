# Test Data – Antique Bookstore

This document defines controlled datasets used for executing test cases. Data is consistent with FR requirements and SRS constraints.


## 1. Authors

| AuthorID | FirstName   | LastName        | BirthYear | DeathYear | Bio                        |
|----------|-------------|-----------------|-----------|-----------|----------------------------|
| 1        | Arthur      | Conan Doyle     | 1859      | 1930      | British writer             |
| 2        | Murasaki    | Shikibu         | 978       | 1016      | Japanese novelist and poet |
| 3        | Lu          | Xun             | 1881      | 1936      | Chinese writer             |
| 4        | Naguib      | Mahfouz         | 1911      | 2006      | Egyptian writer            |
| 5        | Chinua      | Achebe          | 1930      | 2013      | Nigerian novelist          |
| 6        | Jorge Luis  | Borges          | 1899      | 1986      | Argentine writer           |
| 7        | Mikhail     | Bulgakov        | 1891      | 1940      | Russian writer             |
| 8        | James       | Joyce           | 1882      | 1941      | Irish writer               |
| 9        | Gabriel     | García Márquez  | 1927      | 2014      | Colombian novelist         |
|10        | Umberto     | Eco             | 1932      | 2016      | Italian novelist           |
|11        | Rabindranath| Tagore          | 1861      | 1941      | Bengali polymath           |


## 2. Books

| BookID | Title                           | Publisher                            | Year | PurchasePrice  | Rec.Price | Condition | Status    |
|--------|---------------------------------|--------------------------------------|------|----------------|-----------|-----------|-----------|
| 1      | A Study in Scarlet              | Ward Lock & Co                       | 1887 | 150.00         | 750.00    | Good      | Reserved  |
| 2      | The Tale of Genji               | Imperial Court of Japan              | 1021 | 3500.00        | 12000.00  | VeryGood  | Available |
| 3      | A Madman's Diary                | New Youth Magazine                   | 1918 | 800.00         | 2500.00   | Excellent | Available |
| 4      | The Cairo Trilogy: Palace Walk  | American University in Cairo Press   | 1956 | 450.00         | 1800.00   | VeryGood  | Available |
| 5      | Things Fall Apart               | William Heinemann Ltd.               | 1958 | 1200.00        | 4500.00   | Good      | Available |
| 6      | Ficciones                       | Editorial Sur                        | 1944 | 900.00         | 3200.00   | Excellent | Available |
| 7      | The Master and Margarita        | YMCA Press                           | 1967 | 700.00         | 3000.00   | VeryGood  | Available |
| 8      | Ulysses                         | Shakespeare and Company              | 1922 | 1100.00        | 3900.00   | Good      | Available |
| 9      | One Hundred Years of Solitude   | Harper & Row                         | 1967 | 1400.00        | 5000.00   | Excellent | Available |
|10      | The Name of the Rose            | Bompiani                             | 1980 | 600.00         | 2500.00   | Fair      | Available |
|11      | Gitanjali                       | Macmillan                            | 1910 | 300.00         | 900.00    | Good      | Available |


## 3. Book–Author Links (BookAuthor)

BookID matches AuthorID one-to-one in seeds:

| BookID | AuthorID |
|--------|----------|
| 1      | 1        |
| 2      | 2        |
| 3      | 3        |
| 4      | 4        |
| 5      | 5        |
| 6      | 6        |
| 7      | 7        |
| 8      | 8        |
| 9      | 9        |
|10      | 10       |
|11      | 11       |


## 4. Customers

| CustomerID | FirstName | LastName   | Email                          | Active |
|------------|-----------|------------|--------------------------------|--------|
| 1          | Hans      | Müller     | hans.muller@example.de         | true   |
| 2          | Sophie    | Dubois     | sophie.dubois@example.fr       | true   |
| 3          | Haruki    | Tanaka     | haruki.tanaka@example.jp       | true   |
| 4          | Thabo     | Ndlovu     | thabo.ndlovu@example.za        | true   |
| 5          | Isabella  | Fernandez  | isabella.fernandez@example.ar  | true   |


## 5. Delivery Addresses

| AddressID | CustomerID | Country       | City        | AddressLine1                    | PostalCode |
|-----------|-------------|--------------|-------------|---------------------------------|------------|
| 1         | 1           | Germany      | Berlin      | Unter den Linden 77             | 10117      |
| 2         | 2           | France       | Paris       | 15 Avenue des Champs-Élysées    | 75008      |
| 3         | 3           | Japan        | Tokyo       | 4-2-8 Shinjuku, Shinjuku-ku     | 160-0022   |
| 4         | 4           | South Africa | Cape Town   | 123 Nelson Mandela Boulevard    | 8001       |
| 5         | 5           | Argentina    | Buenos Aires| 789 Avenida 9 de Julio          | C1043      |


## 6. Employees

| EmployeeID | FirstName | LastName | HireDate       | Active |
|------------|-----------|----------|----------------|--------|
| 1          | Jane      | Smith    | 2023-01-15     | true   |
| 2          | Bob       | Williams | 2023-03-10     | true   |
| 3          | New       | Unlinked | 2023-05-01     | false  |


## 7. Positions & Levels

### Levels

| LevelID | Name    |
|---------|---------|
| 1       | Manager |
| 2       | Sales   |

### Positions

| PositionID | Title           | Level |
|------------|-----------------|-------|
| 1          | Store Manager   | 1     |
| 2          | Sales Associate | 2     |


## 8. Position History

| PromotionID | EmployeeID | PositionID | StartDate   | Active |
|-------------|------------|------------|-------------|--------|
| 1           | 1          | 1          | 2023-01-15  | true   |
| 2           | 2          | 2          | 2023-03-10  | true   |
| 3           | 3          | 2          | 2023-03-10  | true   |


## 9. Order Statuses

| StatusID | Name             |
|----------|------------------|
| 1        | New              |
| 2        | Processing       |
| 3        | Shipped          |
| 4        | Delivered        |
| 5        | Cancelled        |
| 6        | Payment Pending  |
| 7        | Paid             |


## 10. Payment Methods

| MethodID | Name          | Active |
|----------|---------------|--------|
| 1        | Credit Card   | true   |
| 2        | Cash          | true   |
| 3        | PayPal        | false  |
| 4        | Bank Transfer | false  |


## 11. Orders

| OrderID | Customer | Employee |      StatusID      | PaymentMethod  | AddressID |
|---------|----------|----------|--------------------|----------------|-----------|
| 1       | 1        | 2        | 1 (New)            | 2 (Cash)       | null      |
| 2       | 3        | 2        | 6 (PaymentPending) | 1 (CreditCard) | 3         |


## 12. Sales

| SaleID | OrderID | BookID | Price   |
|--------|---------|--------|---------|
| 1      | 1       | 1      | 750.00  |
| 2      | 2       | 2      | 1200.00 |
| 3      | 2       | 8      | 950.00  |



## 6. Boundary Data

### Publication Years

- Valid: 1600, 1700, 1999, 2099
- Invalid: 1599, 2100, non-numeric

### BookID 

- Valid: “AB12CD34”
- Invalid: “1234567”, “###BADID”, empty string

### Other
